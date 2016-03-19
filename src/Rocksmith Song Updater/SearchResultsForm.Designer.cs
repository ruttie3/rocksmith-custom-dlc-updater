namespace Rocksmith_Custom_DLC_Updater
{
    partial class SearchResultsForm
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
            this.infoLbl = new System.Windows.Forms.Label();
            this.resultsBox = new System.Windows.Forms.ComboBox();
            this.idLbl = new System.Windows.Forms.Label();
            this.memberLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.artistLbl = new System.Windows.Forms.Label();
            this.albumLbl = new System.Windows.Forms.Label();
            this.tuningLbl = new System.Windows.Forms.Label();
            this.updatedLbl = new System.Windows.Forms.Label();
            this.downloadsLbl = new System.Windows.Forms.Label();
            this.partsLbl = new System.Windows.Forms.Label();
            this.ddLbl = new System.Windows.Forms.Label();
            this.platformsLbl = new System.Windows.Forms.Label();
            this.chooseBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.webpageBtn = new System.Windows.Forms.Button();
            this.searchAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.infoLbl.Location = new System.Drawing.Point(12, 9);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(259, 13);
            this.infoLbl.TabIndex = 0;
            this.infoLbl.Text = "The following results were found after searching for ...";
            // 
            // resultsBox
            // 
            this.resultsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resultsBox.FormattingEnabled = true;
            this.resultsBox.Location = new System.Drawing.Point(15, 44);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(520, 21);
            this.resultsBox.TabIndex = 1;
            this.resultsBox.SelectedIndexChanged += new System.EventHandler(this.resultsBox_SelectedIndexChanged);
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(80, 79);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(24, 13);
            this.idLbl.TabIndex = 2;
            this.idLbl.Text = "ID: ";
            // 
            // memberLbl
            // 
            this.memberLbl.AutoSize = true;
            this.memberLbl.Location = new System.Drawing.Point(56, 108);
            this.memberLbl.Name = "memberLbl";
            this.memberLbl.Size = new System.Drawing.Size(48, 13);
            this.memberLbl.TabIndex = 3;
            this.memberLbl.Text = "Member:";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(74, 139);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(30, 13);
            this.titleLbl.TabIndex = 4;
            this.titleLbl.Text = "Title:";
            // 
            // artistLbl
            // 
            this.artistLbl.AutoSize = true;
            this.artistLbl.Location = new System.Drawing.Point(71, 170);
            this.artistLbl.Name = "artistLbl";
            this.artistLbl.Size = new System.Drawing.Size(33, 13);
            this.artistLbl.TabIndex = 5;
            this.artistLbl.Text = "Artist:";
            // 
            // albumLbl
            // 
            this.albumLbl.AutoSize = true;
            this.albumLbl.Location = new System.Drawing.Point(65, 203);
            this.albumLbl.Name = "albumLbl";
            this.albumLbl.Size = new System.Drawing.Size(39, 13);
            this.albumLbl.TabIndex = 6;
            this.albumLbl.Text = "Album:";
            // 
            // tuningLbl
            // 
            this.tuningLbl.AutoSize = true;
            this.tuningLbl.Location = new System.Drawing.Point(61, 231);
            this.tuningLbl.Name = "tuningLbl";
            this.tuningLbl.Size = new System.Drawing.Size(43, 13);
            this.tuningLbl.TabIndex = 7;
            this.tuningLbl.Text = "Tuning:";
            // 
            // updatedLbl
            // 
            this.updatedLbl.AutoSize = true;
            this.updatedLbl.Location = new System.Drawing.Point(32, 261);
            this.updatedLbl.Name = "updatedLbl";
            this.updatedLbl.Size = new System.Drawing.Size(72, 13);
            this.updatedLbl.TabIndex = 8;
            this.updatedLbl.Text = "Last updated:";
            // 
            // downloadsLbl
            // 
            this.downloadsLbl.AutoSize = true;
            this.downloadsLbl.Location = new System.Drawing.Point(41, 292);
            this.downloadsLbl.Name = "downloadsLbl";
            this.downloadsLbl.Size = new System.Drawing.Size(63, 13);
            this.downloadsLbl.TabIndex = 9;
            this.downloadsLbl.Text = "Downloads:";
            // 
            // partsLbl
            // 
            this.partsLbl.AutoSize = true;
            this.partsLbl.Location = new System.Drawing.Point(70, 322);
            this.partsLbl.Name = "partsLbl";
            this.partsLbl.Size = new System.Drawing.Size(34, 13);
            this.partsLbl.TabIndex = 10;
            this.partsLbl.Text = "Parts:";
            // 
            // ddLbl
            // 
            this.ddLbl.AutoSize = true;
            this.ddLbl.Location = new System.Drawing.Point(12, 355);
            this.ddLbl.Name = "ddLbl";
            this.ddLbl.Size = new System.Drawing.Size(92, 13);
            this.ddLbl.TabIndex = 11;
            this.ddLbl.Text = "Dynamic difficulty:";
            // 
            // platformsLbl
            // 
            this.platformsLbl.AutoSize = true;
            this.platformsLbl.Location = new System.Drawing.Point(51, 386);
            this.platformsLbl.Name = "platformsLbl";
            this.platformsLbl.Size = new System.Drawing.Size(53, 13);
            this.platformsLbl.TabIndex = 12;
            this.platformsLbl.Text = "Platforms:";
            // 
            // chooseBtn
            // 
            this.chooseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.chooseBtn.Location = new System.Drawing.Point(460, 437);
            this.chooseBtn.Name = "chooseBtn";
            this.chooseBtn.Size = new System.Drawing.Size(75, 23);
            this.chooseBtn.TabIndex = 13;
            this.chooseBtn.Text = "Choose";
            this.chooseBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(379, 437);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // webpageBtn
            // 
            this.webpageBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.webpageBtn.Location = new System.Drawing.Point(249, 437);
            this.webpageBtn.Name = "webpageBtn";
            this.webpageBtn.Size = new System.Drawing.Size(124, 23);
            this.webpageBtn.TabIndex = 15;
            this.webpageBtn.Text = "Open webpage";
            this.webpageBtn.UseVisualStyleBackColor = true;
            this.webpageBtn.Click += new System.EventHandler(this.webpageBtn_Click);
            // 
            // searchAgain
            // 
            this.searchAgain.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.searchAgain.Location = new System.Drawing.Point(109, 437);
            this.searchAgain.Name = "searchAgain";
            this.searchAgain.Size = new System.Drawing.Size(134, 23);
            this.searchAgain.TabIndex = 16;
            this.searchAgain.Text = "Search again";
            this.searchAgain.UseVisualStyleBackColor = true;
            // 
            // SearchResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 472);
            this.Controls.Add(this.searchAgain);
            this.Controls.Add(this.webpageBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.chooseBtn);
            this.Controls.Add(this.platformsLbl);
            this.Controls.Add(this.ddLbl);
            this.Controls.Add(this.partsLbl);
            this.Controls.Add(this.downloadsLbl);
            this.Controls.Add(this.updatedLbl);
            this.Controls.Add(this.tuningLbl);
            this.Controls.Add(this.albumLbl);
            this.Controls.Add(this.artistLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.memberLbl);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.resultsBox);
            this.Controls.Add(this.infoLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchResultsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search results";
            this.Load += new System.EventHandler(this.SearchResultsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.ComboBox resultsBox;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label memberLbl;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label artistLbl;
        private System.Windows.Forms.Label albumLbl;
        private System.Windows.Forms.Label tuningLbl;
        private System.Windows.Forms.Label updatedLbl;
        private System.Windows.Forms.Label downloadsLbl;
        private System.Windows.Forms.Label partsLbl;
        private System.Windows.Forms.Label ddLbl;
        private System.Windows.Forms.Label platformsLbl;
        private System.Windows.Forms.Button chooseBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button webpageBtn;
        private System.Windows.Forms.Button searchAgain;
    }
}