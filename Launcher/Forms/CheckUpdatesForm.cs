using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Main;
using Core.Models;
using Launcher.Properties;
using Newtonsoft.Json;

namespace Launcher.Forms
{
    public partial class CheckUpdatesForm : Form
    {
        Updater _updater;

        private string ConfigFileName => "Config.json";

        Config _launcherConfig;

        public CheckUpdatesForm()
        {
            InitializeComponent();


            labelTop.Text = Resources.Searching_updates;
            Text = Resources.Checking_updates;
            labelUpdating.Text = Resources.Updating_to_version;
            buttonClose.Text = Resources.Close;


        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!File.Exists(ConfigFileName))
            {
                MessageBox.Show($"{ConfigFileName} not found in working directory");
                Close();
                return;
            }

            _launcherConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigFileName));

            if (!string.IsNullOrWhiteSpace(_launcherConfig.AppName))
            Text = _launcherConfig.AppName + " - " + Text;

            var config = new UpdaterConfig
            {
                VersionProvider = new DefaultVersionProvider(),
                WebsiteUrl = _launcherConfig.WebsiteUrl
            };

            if (!string.IsNullOrWhiteSpace(_launcherConfig.WorkingDir))
                config.WorkingDir = _launcherConfig.WorkingDir;

            if (!string.IsNullOrWhiteSpace(_launcherConfig.UpdateTempDirectory))
                config.UpdateTempDirectory = _launcherConfig.UpdateTempDirectory;

            _updater = new Updater(config);


            _updater.SearchingPatchCompleted += Updater_SearchingPatchCompleted;
            _updater.SearchingPatchFailed += Updater_SearchingPatchFailed;

            _updater.PatchingCompleted += Updater_PatchingCompleted;
            _updater.PatchingFailed += Updater_PatchingFailed;

            _updater.UpdateProgress += Updater_UpdateProgress;

            Task.Run(() => _updater.CheckForUpdates());
        }

        private void Updater_PatchingFailed(Exception exception)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                MessageBox.Show(exception.ToString());

                panelUpdating.Hide();

                Thread.Sleep(1000);

                Task.Run(() => _updater.CheckForUpdates());
            }));



        }

        private async void Updater_PatchingCompleted(PatchModel patch)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                panelUpdating.Hide();
            }));
            await _updater.CheckForUpdates();
        }

        private void Updater_SearchingPatchFailed(Exception exception)
        {
            if (exception != null)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    MessageBox.Show(exception.ToString());
                    Close();
                }));

            }
        }

        private void RunApp()
        {
            System.Diagnostics.Process.Start(_launcherConfig.RunFileName);
        }

        private async void Updater_SearchingPatchCompleted(VersionModel newVersion)
        {
            if (newVersion != null)
            {

                BeginInvoke(new MethodInvoker(() =>
                {
                    labelVersion.Text = newVersion.Version;

                    labelUpdateState.Text = labelDownloadProgress.Text = "";

                    panelUpdating.Show();

                    labelUpdateState.Text = "";
                }));

                await _updater.ApplyPatch(newVersion);
            }
            else
            {
                RunApp();
                BeginInvoke(new MethodInvoker(Close));
            }
        }

        private void Updater_UpdateProgress(UpdateProgressModel model)
        {

            if (model.State == UpdateState.ApplyingPatch || model.State == UpdateState.DownloadingPatch)
            {




                BeginInvoke(new MethodInvoker(() =>
                {

                    var completedKibs = model.CompletedBytes / 1024.0;
                    var totalKibs = model.TotalBytes / 1024.0;

                    var completedMibs = completedKibs / 1024.0;
                    var totalMibs = totalKibs / 1024.0;

                    if (totalMibs > 1)
                        labelDownloadProgress.Text = $"{completedMibs:F1}/{totalMibs:F1} MiB";
                    else
                        labelDownloadProgress.Text = $"{completedKibs:F1}/{totalKibs:F1} KiB";
                    progressBarUpdating.Maximum = Convert.ToInt32(totalKibs);
                    progressBarUpdating.Value = Convert.ToInt32(completedKibs);

                    labelUpdateState.Text = model.State == UpdateState.DownloadingPatch
                        ? Resources.Loading_data
                        : Resources.Installing_Updates;
                }));
            }


        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                Resources.Close_window_alert_text,
                Resources.Close,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                _updater.Rollback();
                Close();
            }
        }
    }
}
