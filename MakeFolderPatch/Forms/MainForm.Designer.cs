namespace MakeFolderPatch.Forms
{
    partial class MainForm
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
            this.textBoxOldDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPatchDir = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.buttonBrowseOld = new System.Windows.Forms.Button();
            this.buttonBrowseNew = new System.Windows.Forms.Button();
            this.buttonBrowsePatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxOldDir
            // 
            this.textBoxOldDir.Location = new System.Drawing.Point(184, 14);
            this.textBoxOldDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxOldDir.Name = "textBoxOldDir";
            this.textBoxOldDir.Size = new System.Drawing.Size(328, 29);
            this.textBoxOldDir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Old Build Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Build Directory";
            // 
            // textBoxNewDir
            // 
            this.textBoxNewDir.Location = new System.Drawing.Point(184, 56);
            this.textBoxNewDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNewDir.Name = "textBoxNewDir";
            this.textBoxNewDir.Size = new System.Drawing.Size(328, 29);
            this.textBoxNewDir.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Patch Directory";
            // 
            // textBoxPatchDir
            // 
            this.textBoxPatchDir.Location = new System.Drawing.Point(184, 98);
            this.textBoxPatchDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPatchDir.Name = "textBoxPatchDir";
            this.textBoxPatchDir.Size = new System.Drawing.Size(328, 29);
            this.textBoxPatchDir.TabIndex = 4;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(400, 176);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(112, 37);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Version";
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Location = new System.Drawing.Point(184, 137);
            this.textBoxVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(328, 29);
            this.textBoxVersion.TabIndex = 7;
            this.textBoxVersion.Text = "1.0.1";
            // 
            // buttonBrowseOld
            // 
            this.buttonBrowseOld.Location = new System.Drawing.Point(519, 12);
            this.buttonBrowseOld.Name = "buttonBrowseOld";
            this.buttonBrowseOld.Size = new System.Drawing.Size(96, 31);
            this.buttonBrowseOld.TabIndex = 9;
            this.buttonBrowseOld.Text = "Browse";
            this.buttonBrowseOld.UseVisualStyleBackColor = true;
            this.buttonBrowseOld.Click += new System.EventHandler(this.buttonBrowseOld_Click);
            // 
            // buttonBrowseNew
            // 
            this.buttonBrowseNew.Location = new System.Drawing.Point(519, 54);
            this.buttonBrowseNew.Name = "buttonBrowseNew";
            this.buttonBrowseNew.Size = new System.Drawing.Size(96, 31);
            this.buttonBrowseNew.TabIndex = 10;
            this.buttonBrowseNew.Text = "Browse";
            this.buttonBrowseNew.UseVisualStyleBackColor = true;
            this.buttonBrowseNew.Click += new System.EventHandler(this.buttonBrowseNew_Click);
            // 
            // buttonBrowsePatch
            // 
            this.buttonBrowsePatch.Location = new System.Drawing.Point(519, 98);
            this.buttonBrowsePatch.Name = "buttonBrowsePatch";
            this.buttonBrowsePatch.Size = new System.Drawing.Size(96, 31);
            this.buttonBrowsePatch.TabIndex = 11;
            this.buttonBrowsePatch.Text = "Browse";
            this.buttonBrowsePatch.UseVisualStyleBackColor = true;
            this.buttonBrowsePatch.Click += new System.EventHandler(this.buttonBrowsePatch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 232);
            this.Controls.Add(this.textBoxVersion);
            this.Controls.Add(this.buttonBrowsePatch);
            this.Controls.Add(this.buttonBrowseNew);
            this.Controls.Add(this.buttonBrowseOld);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPatchDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOldDir);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Patch creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOldDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPatchDir;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Button buttonBrowseOld;
        private System.Windows.Forms.Button buttonBrowseNew;
        private System.Windows.Forms.Button buttonBrowsePatch;
    }
}

