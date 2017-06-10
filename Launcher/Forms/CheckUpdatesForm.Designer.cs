namespace Launcher.Forms
{
    partial class CheckUpdatesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckUpdatesForm));
            this.progressBarSearching = new System.Windows.Forms.ProgressBar();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelUpdating = new System.Windows.Forms.Label();
            this.labelDownloadProgress = new System.Windows.Forms.Label();
            this.progressBarUpdating = new System.Windows.Forms.ProgressBar();
            this.panelUpdating = new System.Windows.Forms.Panel();
            this.labelTop = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelUpdateState = new System.Windows.Forms.Label();
            this.panelUpdating.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarSearching
            // 
            resources.ApplyResources(this.progressBarSearching, "progressBarSearching");
            this.progressBarSearching.Name = "progressBarSearching";
            this.progressBarSearching.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // labelUpdating
            // 
            resources.ApplyResources(this.labelUpdating, "labelUpdating");
            this.labelUpdating.Name = "labelUpdating";
            // 
            // labelDownloadProgress
            // 
            resources.ApplyResources(this.labelDownloadProgress, "labelDownloadProgress");
            this.labelDownloadProgress.Name = "labelDownloadProgress";
            // 
            // progressBarUpdating
            // 
            resources.ApplyResources(this.progressBarUpdating, "progressBarUpdating");
            this.progressBarUpdating.Name = "progressBarUpdating";
            // 
            // panelUpdating
            // 
            resources.ApplyResources(this.panelUpdating, "panelUpdating");
            this.panelUpdating.Controls.Add(this.labelUpdateState);
            this.panelUpdating.Controls.Add(this.progressBarUpdating);
            this.panelUpdating.Controls.Add(this.labelVersion);
            this.panelUpdating.Controls.Add(this.labelDownloadProgress);
            this.panelUpdating.Controls.Add(this.labelUpdating);
            this.panelUpdating.Name = "panelUpdating";
            // 
            // labelTop
            // 
            resources.ApplyResources(this.labelTop, "labelTop");
            this.labelTop.Name = "labelTop";
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelUpdateState
            // 
            resources.ApplyResources(this.labelUpdateState, "labelUpdateState");
            this.labelUpdateState.Name = "labelUpdateState";
            // 
            // CheckUpdatesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.panelUpdating);
            this.Controls.Add(this.progressBarSearching);
            this.Name = "CheckUpdatesForm";
            this.panelUpdating.ResumeLayout(false);
            this.panelUpdating.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarSearching;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelUpdating;
        private System.Windows.Forms.Label labelDownloadProgress;
        private System.Windows.Forms.ProgressBar progressBarUpdating;
        private System.Windows.Forms.Panel panelUpdating;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelUpdateState;
    }
}