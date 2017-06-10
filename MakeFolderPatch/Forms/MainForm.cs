using System;
using System.IO;
using System.Windows.Forms;
using MakeFolderPatch.Core;
using Newtonsoft.Json;

namespace MakeFolderPatch.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var settings = LoadSettings();
            if (settings != null)
            {
                textBoxOldDir.Text = settings.OldBuildDirectory;
                textBoxNewDir.Text = settings.NewBuildDirectory;
                textBoxPatchDir.Text = settings.PatchDirectory;
                textBoxVersion.Text = settings.Version;
            }
        }


        Settings LoadSettings()
        {
            if (File.Exists("settings.json"))
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json"));
            }
            return null;
        }

        void SaveSettings(Settings s)
        {
            File.WriteAllText("settings.json", JsonConvert.SerializeObject(s, Formatting.Indented));
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SaveSettings(new Settings()
            {
                Version = textBoxVersion.Text,
                PatchDirectory = textBoxPatchDir.Text,
                NewBuildDirectory = textBoxNewDir.Text,
                OldBuildDirectory = textBoxOldDir.Text
            });

            new PatchMaker().Build(textBoxOldDir.Text, textBoxNewDir.Text, textBoxPatchDir.Text, textBoxVersion.Text);
        }

        private void BrowsePath(TextBox tb)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb.Text = dialog.SelectedPath;
            }
        }

        private void buttonBrowseOld_Click(object sender, EventArgs e)
        {
            BrowsePath(textBoxOldDir);
        }

        private void buttonBrowseNew_Click(object sender, EventArgs e)
        {
            BrowsePath(textBoxNewDir);
        }

        private void buttonBrowsePatch_Click(object sender, EventArgs e)
        {
            BrowsePath(textBoxPatchDir);
        }
    }
}
