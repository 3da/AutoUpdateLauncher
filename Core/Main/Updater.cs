using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BsDiff;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Main
{
    public class Updater
    {
        private readonly UpdaterConfig _updaterConfig;
        private readonly string _websiteUrl;
        private readonly DirectoryInfo _workingDir;
        private readonly DirectoryInfo _updateFilesDir;


        public event SearchingPatchCompletedDelegate SearchingPatchCompleted;
        public event PatchingErrorDelegate SearchingPatchFailed;

        public event PatchingCompletedDelegate PatchingCompleted;
        public event PatchingErrorDelegate PatchingFailed;

        public delegate void UpdateProgressDelegate(UpdateProgressModel model);

        public delegate void PatchingCompletedDelegate(PatchModel patch);

        public delegate void PatchingErrorDelegate(Exception exception);

        public delegate void SearchingPatchCompletedDelegate(VersionModel newVersion);

        public event UpdateProgressDelegate UpdateProgress;

        public UpdateState CurrentState { get; private set; }

        public Updater(UpdaterConfig updaterConfig)
        {
            _updaterConfig = updaterConfig;
            _websiteUrl = updaterConfig.WebsiteUrl;
            _workingDir = new DirectoryInfo(updaterConfig.WorkingDir);
            _updateFilesDir = new DirectoryInfo(updaterConfig.UpdateTempDirectory);
        }


        private string LogPath => _workingDir + @"\update.log";

        public async Task CheckForUpdates()
        {
            CurrentState = UpdateState.SearchingUpdates;
            Rollback();

            try
            {


                using (var wc = new WebClient())
                {
                    var updates = JsonConvert.DeserializeObject(await wc.DownloadStringTaskAsync(_websiteUrl + "/Patches/Info.json"), typeof(UpdateInfoModel)) as UpdateInfoModel;

                    var currentPatch = updates.Patches.FirstOrDefault(q => q.Version == _updaterConfig.VersionProvider.GetVersion());

                    CurrentState = UpdateState.Idle;


                    int nextPatchIndex;


                    if (currentPatch == null)
                        nextPatchIndex = 0;
                    else
                        nextPatchIndex = updates.Patches.IndexOf(currentPatch) + 1;


                    if (updates.Patches.Count <= nextPatchIndex)
                        OnSearchingPatchCompleted(null);
                    else
                    {

                        var patchInfo = updates.Patches[nextPatchIndex];
                        OnSearchingPatchCompleted(patchInfo);
                    }
                }
            }
            catch (Exception e)
            {
                CurrentState = UpdateState.Idle;
                OnSearchingPatchFailed(e);
            }

        }


        public async Task ApplyPatch(VersionModel patchInfo)
        {

            try
            {
                CurrentState = UpdateState.DownloadingPatch;


                OnUpdateProgress(new UpdateProgressModel
                {
                    State = CurrentState,
                    TotalBytes = 1,
                    CompletedBytes = 0
                });

                if (!_updateFilesDir.Exists)
                    _updateFilesDir.Create();
                else
                {
                    _updateFilesDir.Delete(true);
                    _updateFilesDir.Create();
                }

                var patchZipFile = new FileInfo(_updateFilesDir + "\\patch.zip");

                var extractedDir = new DirectoryInfo(_updateFilesDir + "\\Patch");

                using (var wc = new WebClient())
                {

                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;

                    await wc.DownloadFileTaskAsync(_websiteUrl + $"/Patches/{patchInfo.Version}.zip", patchZipFile.FullName);
                }

                CurrentState = UpdateState.ApplyingPatch;

                ZipFile.ExtractToDirectory(patchZipFile.FullName, extractedDir.FullName);

                var patch = JsonConvert.DeserializeObject<PatchModel>(File.ReadAllText(extractedDir.FullName + "\\Info.json"));

                var totalBytes = patch.NewFiles.Sum(q => q.Size) + patch.UpdatedFiles.Sum(q => q.Size);
                long loadedBytes = 0;
                OnUpdateProgress(new UpdateProgressModel
                {
                    State = CurrentState,
                    TotalBytes = totalBytes,
                    CompletedBytes = loadedBytes
                });

                var patchContentDir = new DirectoryInfo(extractedDir.FullName + "\\Data");


                using (var log = new UpdaterLog(LogPath, true))
                {


                    if (patch.UpdatedFiles != null)
                    {
                        foreach (var updatedFileName in patch.UpdatedFiles)
                        {
                            var fi = new FileInfo(_workingDir.FullName + updatedFileName.RelativePath);
                            if (fi.Directory.Exists == false)
                                fi.Directory.Create();

                            string realFileName;

                            bool isPatch = false;

                            if (fi.FullName.EndsWith(".patch", StringComparison.InvariantCultureIgnoreCase))
                            {
                                realFileName = fi.FullName.Substring(0, fi.FullName.Length - 6);
                                isPatch = true;
                            }
                            else
                                realFileName = fi.FullName;

                            File.Delete(realFileName + ".bak");
                            File.Move(realFileName, realFileName + ".bak");

                            log.WriteUpdate(realFileName, realFileName + ".bak");

                            if (isPatch)
                            {


                                using (var input = File.OpenRead(realFileName + ".bak"))
                                using (var output = File.OpenWrite(realFileName))
                                {
                                    BinaryPatchUtility.Apply(input,
                                        () => File.Open(patchContentDir.FullName + updatedFileName.RelativePath, FileMode.Open, FileAccess.Read, FileShare.Read),
                                        output);
                                }


                                File.Delete(patchContentDir.FullName + updatedFileName.RelativePath);


                            }

                            loadedBytes += updatedFileName.Size;

                            OnUpdateProgress(new UpdateProgressModel
                            {
                                State = CurrentState,
                                TotalBytes = totalBytes,
                                CompletedBytes = loadedBytes
                            });
                            Thread.Sleep(1);

                        }
                    }

                    if (patch.NewFiles != null)
                    {
                        foreach (var newFileName in patch.NewFiles)
                        {
                            var fi = new FileInfo(_workingDir.FullName + newFileName.RelativePath);
                            if (fi.Directory.Exists == false)
                                fi.Directory.Create();

                            log.WriteAdd(fi.FullName);

                            if (fi.Exists)
                                fi.Delete();

                            File.Move(patchContentDir.FullName + newFileName.RelativePath, fi.FullName);

                            loadedBytes += newFileName.Size;
                            OnUpdateProgress(new UpdateProgressModel
                            {
                                State = CurrentState,
                                TotalBytes = totalBytes,
                                CompletedBytes = loadedBytes
                            });
                            Thread.Sleep(1);
                        }
                    }

                    if (patch.DeletedFiles != null)
                    {
                        foreach (var patchDeletedFile in patch.DeletedFiles)
                        {
                            var fi = new FileInfo(_workingDir + patchDeletedFile);

                            File.Delete(fi.FullName + ".bak");
                            File.Move(fi.FullName, fi.FullName + ".bak");

                            log.WriteDelete(fi.FullName, fi.FullName + ".bak");

                        }

                    }

                    log.Complete();

                }

                _updaterConfig.VersionProvider.SaveVersion(patch.Version);

                CurrentState = UpdateState.Idle;

                _updateFilesDir.Delete(true);

                OnPatchingCompleted(patch);



            }
            catch (Exception e)
            {
                CurrentState = UpdateState.Idle;
                OnPatchingError(e);

                Rollback();
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnUpdateProgress(new UpdateProgressModel
            {
                State = CurrentState,
                TotalBytes = e.TotalBytesToReceive,
                CompletedBytes = e.BytesReceived
            });
        }

        public void Rollback()
        {
            if (File.Exists(LogPath))
            {
                var updater = new UpdaterLog(LogPath, false);
                updater.Revert();


            }
        }

        protected virtual void OnUpdateProgress(UpdateProgressModel model)
        {
            UpdateProgress?.Invoke(model);
        }

        protected virtual void OnPatchingError(Exception exception)
        {
            PatchingFailed?.Invoke(exception);
        }

        protected virtual void OnPatchingCompleted(PatchModel patch)
        {
            PatchingCompleted?.Invoke(patch);
        }

        protected virtual void OnSearchingPatchCompleted(VersionModel newversion)
        {
            SearchingPatchCompleted?.Invoke(newversion);
        }

        protected virtual void OnSearchingPatchFailed(Exception exception)
        {
            SearchingPatchFailed?.Invoke(exception);
        }
    }
}
