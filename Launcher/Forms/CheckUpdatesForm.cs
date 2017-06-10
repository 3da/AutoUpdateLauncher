using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Main;
using Core.Models;

namespace Launcher.Forms
{
    public partial class CheckUpdatesForm : Form
    {
        Updater updater;

        System.ComponentModel.ComponentResourceManager _resources;

        public CheckUpdatesForm()
        {
            InitializeComponent();


            _resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckUpdatesForm));




        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);



            //var workingDir = @"D:\Projects\OldBuild";

            var config = new UpdaterConfig
            {
                WebsiteUrl = "http://localhost:50826",
                VersionProvider = new DefaultVersionProvider()
                //WebsiteUrl = "https://itvtomske.ru/update",

            };

            updater = new Updater(config);


            updater.SearchingPatchCompleted += Updater_SearchingPatchCompleted;
            updater.SearchingPatchFailed += Updater_SearchingPatchFailed;

            updater.PatchingCompleted += Updater_PatchingCompleted;
            updater.PatchingFailed += Updater_PatchingFailed;

            updater.UpdateProgress += Updater_UpdateProgress;

            Task.Run(() => updater.CheckForUpdates());
        }

        private async void Updater_PatchingFailed(Exception exception)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                MessageBox.Show(exception.ToString());

                panelUpdating.Hide();
            }));


            Thread.Sleep(1000);

            await updater.CheckForUpdates();
        }

        private async void Updater_PatchingCompleted(PatchModel patch)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                panelUpdating.Hide();
            }));
            await updater.CheckForUpdates();
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

                await updater.ApplyPatch(newVersion);
            }
            else
            {
                System.Diagnostics.Process.Start("game.exe");
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
                        ? "Загрузка данных"
                        : "Установка обновлений";
                }));
            }


        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                _resources.GetString("Close_window_alert_text"),
                _resources.GetString("buttonClose.Text"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                updater.Rollback();
                Close();
            }
        }
    }
}
