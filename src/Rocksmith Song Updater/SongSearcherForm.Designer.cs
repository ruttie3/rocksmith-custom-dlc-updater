namespace Rocksmith_Custom_DLC_Updater
{
    partial class SongSearcherForm
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
            this.searchingLbl = new System.Windows.Forms.Label();
            this.searchingProgress = new System.Windows.Forms.ProgressBar();
            this.songsUpdater = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // searchingLbl
            // 
            this.searchingLbl.AutoSize = true;
            this.searchingLbl.Location = new System.Drawing.Point(12, 12);
            this.searchingLbl.Name = "searchingLbl";
            this.searchingLbl.Size = new System.Drawing.Size(58, 13);
            this.searchingLbl.TabIndex = 3;
            this.searchingLbl.Text = "Searching:";
            // 
            // searchingProgress
            // 
            this.searchingProgress.Location = new System.Drawing.Point(12, 37);
            this.searchingProgress.Name = "searchingProgress";
            this.searchingProgress.Size = new System.Drawing.Size(323, 23);
            this.searchingProgress.TabIndex = 2;
            // 
            // SongSearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 73);
            this.Controls.Add(this.searchingLbl);
            this.Controls.Add(this.searchingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SongSearcherForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Searching for song...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchingLbl;
        private System.Windows.Forms.ProgressBar searchingProgress;
        public System.ComponentModel.BackgroundWorker songsUpdater;



    }
}