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
            this.progressBarSearching = new System.Windows.Forms.ProgressBar();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelUpdating = new System.Windows.Forms.Label();
            this.labelDownloadProgress = new System.Windows.Forms.Label();
            this.progressBarUpdating = new System.Windows.Forms.ProgressBar();
            this.panelUpdating = new System.Windows.Forms.Panel();
            this.labelUpdateState = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelUpdating.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarSearching
            // 
            this.progressBarSearching.Location = new System.Drawing.Point(18, 54);
            this.progressBarSearching.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarSearching.Name = "progressBarSearching";
            this.progressBarSearching.Size = new System.Drawing.Size(428, 86);
            this.progressBarSearching.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarSearching.TabIndex = 0;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(189, 7);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(55, 21);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "00000";
            // 
            // labelUpdating
            // 
            this.labelUpdating.AutoSize = true;
            this.labelUpdating.Location = new System.Drawing.Point(2, 7);
            this.labelUpdating.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUpdating.Name = "labelUpdating";
            this.labelUpdating.Size = new System.Drawing.Size(175, 21);
            this.labelUpdating.TabIndex = 6;
            this.labelUpdating.Text = "Обновление до версии";
            // 
            // labelDownloadProgress
            // 
            this.labelDownloadProgress.Location = new System.Drawing.Point(6, 134);
            this.labelDownloadProgress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDownloadProgress.Name = "labelDownloadProgress";
            this.labelDownloadProgress.Size = new System.Drawing.Size(416, 27);
            this.labelDownloadProgress.TabIndex = 5;
            this.labelDownloadProgress.Text = "label1";
            this.labelDownloadProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarUpdating
            // 
            this.progressBarUpdating.Location = new System.Drawing.Point(6, 66);
            this.progressBarUpdating.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.progressBarUpdating.Name = "progressBarUpdating";
            this.progressBarUpdating.Size = new System.Drawing.Size(416, 60);
            this.progressBarUpdating.TabIndex = 4;
            // 
            // panelUpdating
            // 
            this.panelUpdating.Controls.Add(this.labelUpdateState);
            this.panelUpdating.Controls.Add(this.progressBarUpdating);
            this.panelUpdating.Controls.Add(this.labelVersion);
            this.panelUpdating.Controls.Add(this.labelDownloadProgress);
            this.panelUpdating.Controls.Add(this.labelUpdating);
            this.panelUpdating.Location = new System.Drawing.Point(18, 160);
            this.panelUpdating.Name = "panelUpdating";
            this.panelUpdating.Size = new System.Drawing.Size(428, 168);
            this.panelUpdating.TabIndex = 8;
            this.panelUpdating.Visible = false;
            // 
            // labelUpdateState
            // 
            this.labelUpdateState.Location = new System.Drawing.Point(6, 35);
            this.labelUpdateState.Name = "labelUpdateState";
            this.labelUpdateState.Size = new System.Drawing.Size(416, 23);
            this.labelUpdateState.TabIndex = 8;
            // 
            // labelTop
            // 
            this.labelTop.Location = new System.Drawing.Point(18, 9);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(428, 40);
            this.labelTop.TabIndex = 9;
            this.labelTop.Text = "Поиск обновлений";
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(294, 334);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(152, 39);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CheckUpdatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 385);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.panelUpdating);
            this.Controls.Add(this.progressBarSearching);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CheckUpdatesForm";
            this.Text = "Проверка обновлений";
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