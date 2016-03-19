namespace Rocksmith_Custom_DLC_Updater
{
    partial class SettingsForm
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
            this.pathBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.hiddensongsBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.pathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.renameChk = new System.Windows.Forms.CheckBox();
            this.deleteChk = new System.Windows.Forms.CheckBox();
            this.dontasksongChk = new System.Windows.Forms.CheckBox();
            this.dlcDir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathBtn
            // 
            this.pathBtn.Location = new System.Drawing.Point(15, 85);
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.Size = new System.Drawing.Size(213, 23);
            this.pathBtn.TabIndex = 0;
            this.pathBtn.Text = "Change rocksmith dlc directory";
            this.pathBtn.UseVisualStyleBackColor = true;
            this.pathBtn.Click += new System.EventHandler(this.pathBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(15, 114);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(213, 23);
            this.loginBtn.TabIndex = 1;
            this.loginBtn.Text = "Log into customsforge";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // hiddensongsBtn
            // 
            this.hiddensongsBtn.Location = new System.Drawing.Point(15, 143);
            this.hiddensongsBtn.Name = "hiddensongsBtn";
            this.hiddensongsBtn.Size = new System.Drawing.Size(213, 23);
            this.hiddensongsBtn.TabIndex = 2;
            this.hiddensongsBtn.Text = "Manage hidden songs";
            this.hiddensongsBtn.UseVisualStyleBackColor = true;
            this.hiddensongsBtn.Click += new System.EventHandler(this.hiddensongsBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.ForeColor = System.Drawing.Color.Red;
            this.resetBtn.Location = new System.Drawing.Point(15, 322);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(213, 23);
            this.resetBtn.TabIndex = 3;
            this.resetBtn.Text = "Reset application";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(15, 281);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(213, 23);
            this.aboutBtn.TabIndex = 4;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // pathDialog
            // 
            this.pathDialog.Description = "Select your Rocksmith 2014 dlc folder.";
            this.pathDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // renameChk
            // 
            this.renameChk.AutoSize = true;
            this.renameChk.Location = new System.Drawing.Point(15, 185);
            this.renameChk.Name = "renameChk";
            this.renameChk.Size = new System.Drawing.Size(134, 17);
            this.renameChk.TabIndex = 5;
            this.renameChk.Text = "Always rename on disk";
            this.renameChk.UseVisualStyleBackColor = true;
            this.renameChk.CheckedChanged += new System.EventHandler(this.renameChk_CheckedChanged);
            // 
            // deleteChk
            // 
            this.deleteChk.AutoSize = true;
            this.deleteChk.Location = new System.Drawing.Point(15, 208);
            this.deleteChk.Name = "deleteChk";
            this.deleteChk.Size = new System.Drawing.Size(136, 17);
            this.deleteChk.TabIndex = 6;
            this.deleteChk.Text = "Always delete from disk";
            this.deleteChk.UseVisualStyleBackColor = true;
            this.deleteChk.CheckedChanged += new System.EventHandler(this.deleteChk_CheckedChanged);
            // 
            // dontasksongChk
            // 
            this.dontasksongChk.AutoSize = true;
            this.dontasksongChk.Location = new System.Drawing.Point(15, 231);
            this.dontasksongChk.Name = "dontasksongChk";
            this.dontasksongChk.Size = new System.Drawing.Size(219, 17);
            this.dontasksongChk.TabIndex = 7;
            this.dontasksongChk.Text = "Don\'t ask for song name when searching";
            this.dontasksongChk.UseVisualStyleBackColor = true;
            this.dontasksongChk.CheckedChanged += new System.EventHandler(this.dontasksongChk_CheckedChanged);
            // 
            // dlcDir
            // 
            this.dlcDir.AutoSize = true;
            this.dlcDir.Location = new System.Drawing.Point(12, 9);
            this.dlcDir.MaximumSize = new System.Drawing.Size(225, 0);
            this.dlcDir.Name = "dlcDir";
            this.dlcDir.Size = new System.Drawing.Size(127, 13);
            this.dlcDir.TabIndex = 8;
            this.dlcDir.Text = "Rocksmith DLC directory:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 355);
            this.Controls.Add(this.dlcDir);
            this.Controls.Add(this.dontasksongChk);
            this.Controls.Add(this.deleteChk);
            this.Controls.Add(this.renameChk);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.hiddensongsBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pathBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button hiddensongsBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.FolderBrowserDialog pathDialog;
        private System.Windows.Forms.CheckBox renameChk;
        private System.Windows.Forms.CheckBox deleteChk;
        private System.Windows.Forms.CheckBox dontasksongChk;
        private System.Windows.Forms.Label dlcDir;
    }
}