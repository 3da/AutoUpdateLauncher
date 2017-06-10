using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BsDiff;
using Core;
using Core.Models;
using Core.Utils;
using MakeFolderPatch.Utils;
using Newtonsoft.Json;

namespace MakeFolderPatch.Core
{
    public class PatchMaker
    {

        private void BuildPatchFile(MyFileInfo oldFile, MyFileInfo newFile, string patchFile)
        {
            using (var outputStream = File.OpenWrite(patchFile))
                BinaryPatchUtility.Create(oldFile.ReadBytes(), newFile.ReadBytes(), outputStream);
        }

        public void Build(string oldDirectory, string newDirectory, string patchDirectory, string version)
        {
            var oldDir = new DirectoryInfo(oldDirectory);

            var newDir = new DirectoryInfo(newDirectory);

            var patchDir = new DirectoryInfo(Path.Combine(patchDirectory, version));

            var oldFiles = oldDir.EnumerateFiles("*", SearchOption.AllDirectories)
                .Select(fileInfo => new MyFileInfo(oldDir, fileInfo)).ToList();

            var newFiles = newDir.EnumerateFiles("*", SearchOption.AllDirectories)
                .Select(fileInfo => new MyFileInfo(newDir, fileInfo)).ToList();

            var updatedFiles = newFiles.Join(oldFiles,
                    nf => nf.RelativePath,
                    of => of.RelativePath,
                    (nf, of) => new ChangedFileInfo(of, nf))
                .Where(q => !FileUtils.FilesAreEqual(q.OldFile, q.NewFile)).ToList();

            var addedFiles = newFiles.Where(q => oldFiles.All(w => w.RelativePath != q.RelativePath)).ToList();

            var deletedFiles = oldFiles.Where(q => newFiles.All(w => w.RelativePath != q.RelativePath)).ToList();

            if (!patchDir.Exists)
                patchDir.Create();
            else
            {
                patchDir.Delete(true);
                patchDir.Refresh();
                patchDir.Create();
            }

            var patchContentDir = patchDir.FullName + @"\Data";

            var patchModel = new PatchModel();
            patchModel.UpdatedFiles = new List<PatchFileInfo>();

            foreach (var fileInfo in updatedFiles)
            {
                var targetFilePatch = new FileInfo(patchContentDir + fileInfo.RelativePath + ".patch");
                if (!targetFilePatch.Directory.Exists)
                    targetFilePatch.Directory.Create();

                BuildPatchFile(fileInfo.OldFile, fileInfo.NewFile, targetFilePatch.FullName);

                targetFilePatch.Refresh();

                var fileHash = HashUtility.GetFileHash(fileInfo.NewFile.FullPath);

                string patchFilePath;
                long fileSize = fileInfo.NewFile.Size;
                bool isPatch;

                if (targetFilePatch.Length >= fileInfo.NewFile.Size)
                {
                    targetFilePatch.Delete();
                    File.Copy(fileInfo.NewFile.FullPath, patchContentDir + fileInfo.RelativePath);

                    patchFilePath = fileInfo.RelativePath;
                    isPatch = false;
                }
                else
                {
                    patchFilePath = fileInfo.RelativePath + ".patch";
                    isPatch = true;
                }

                patchModel.UpdatedFiles.Add(new PatchFileInfo
                {
                    RelativePath = patchFilePath,
                    Size = fileSize,
                    Hash = fileHash,
                    IsPatch = isPatch
                });

            }

            foreach (var patchFileInfo in addedFiles)
            {
                var targetFilePatch = new FileInfo(patchContentDir + patchFileInfo.RelativePath);
                if (!targetFilePatch.Directory.Exists)
                    targetFilePatch.Directory.Create();

                File.Copy(patchFileInfo.FullPath, patchContentDir + patchFileInfo.RelativePath);
            }




            patchModel.Version = version;
            patchModel.DeletedFiles = deletedFiles.Select(q => q.RelativePath).ToList();
            patchModel.NewFiles = addedFiles.Select(q => new PatchFileInfo
            {
                RelativePath = q.RelativePath,
                Size = q.Size,
                Hash = HashUtility.GetFileHash(q.FullPath),
                IsPatch = false
            }).ToList();

            patchModel.ReleaseDateTime = DateTime.UtcNow;


            File.WriteAllText(patchDir.FullName + @"\Info.json", JsonConvert.SerializeObject(patchModel, Formatting.Indented));

            var zipPath = new FileInfo(Path.Combine(patchDirectory, version + ".zip"));

            if (zipPath.Exists)
                zipPath.Delete();

            ZipFile.CreateFromDirectory(patchDir.FullName, zipPath.FullName, CompressionLevel.Optimal, false, Encoding.UTF8);


            zipPath.Refresh();

            patchDir.Delete(true);

            var patchesInfoFile = new FileInfo(Path.Combine(patchDirectory, "Info.json"));

            UpdateInfoModel updateModel;

            if (patchesInfoFile.Exists)
            {
                updateModel = JsonConvert.DeserializeObject<UpdateInfoModel>(File.ReadAllText(patchesInfoFile.FullName));
            }
            else
            {
                updateModel = new UpdateInfoModel()
                {
                    Patches = new List<VersionModel>()
                };
            }

            if (updateModel.Patches.All(q => q.Version != version))
            {
                updateModel.Patches.Add(new VersionModel()
                {
                    Version = version,
                    ReleaseDateTime = DateTime.UtcNow,
                    Size = zipPath.Length
                });

                File.WriteAllText(patchesInfoFile.FullName, JsonConvert.SerializeObject(updateModel, Formatting.Indented));
            }

            MessageBox.Show("Patch created!");
        }
    }
}
