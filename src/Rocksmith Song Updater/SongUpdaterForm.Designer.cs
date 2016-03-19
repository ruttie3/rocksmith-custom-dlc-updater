namespace Rocksmith_Custom_DLC_Updater
{
    partial class SongUpdaterForm
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
            this.songsUpdater = new System.ComponentModel.BackgroundWorker();
            this.updatingProgress = new System.Windows.Forms.ProgressBar();
            this.updatingLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updatingProgress
            // 
            this.updatingProgress.Location = new System.Drawing.Point(12, 34);
            this.updatingProgress.Name = "updatingProgress";
            this.updatingProgress.Size = new System.Drawing.Size(323, 23);
            this.updatingProgress.TabIndex = 0;
            // 
            // updatingLbl
            // 
            this.updatingLbl.AutoSize = true;
            this.updatingLbl.Location = new System.Drawing.Point(12, 9);
            this.updatingLbl.Name = "updatingLbl";
            this.updatingLbl.Size = new System.Drawing.Size(58, 13);
            this.updatingLbl.TabIndex = 1;
            this.updatingLbl.Text = "Searching:";
            // 
            // SongUpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 73);
            this.Controls.Add(this.updatingLbl);
            this.Controls.Add(this.updatingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SongUpdaterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Searching for updates...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.ComponentModel.BackgroundWorker songsUpdater;
        private System.Windows.Forms.ProgressBar updatingProgress;
        private System.Windows.Forms.Label updatingLbl;
    }
}