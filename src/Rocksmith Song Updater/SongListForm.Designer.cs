namespace Rocksmith_Custom_DLC_Updater
{
    partial class SongListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.songstable = new System.Windows.Forms.DataGridView();
            this.selectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forgeidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastsearchedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentversionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newversionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuningColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customtoneColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dynamicdifficultyColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.difficultylevelsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.riffrepeaterColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.releasenotesColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteselectedBtn = new System.Windows.Forms.Button();
            this.scansongsBtn = new System.Windows.Forms.Button();
            this.selectallLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.hideselectedBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.clearsearchLbl = new System.Windows.Forms.LinkLabel();
            this.pathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainprogressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainstatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.songFolderScanner = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.updateVersionNumber = new System.Windows.Forms.Button();
            this.searchSelectedBtn = new System.Windows.Forms.Button();
            this.searchAllBtn = new System.Windows.Forms.Button();
            this.downloadselectedBtn = new System.Windows.Forms.Button();
            this.updateselectedBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songstable)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.songstable);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 446);
            this.panel1.TabIndex = 1;
            // 
            // songstable
            // 
            this.songstable.AllowUserToAddRows = false;
            this.songstable.AllowUserToDeleteRows = false;
            this.songstable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.songstable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.songstable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectColumn,
            this.nameColumn,
            this.forgeidColumn,
            this.lastsearchedColumn,
            this.currentversionColumn,
            this.newversionColumn,
            this.instrumentsColumn,
            this.tuningColumn,
            this.customtoneColumn,
            this.dynamicdifficultyColumn,
            this.difficultylevelsColumn,
            this.riffrepeaterColumn,
            this.releasenotesColumn});
            this.songstable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songstable.Location = new System.Drawing.Point(0, 0);
            this.songstable.Name = "songstable";
            this.songstable.Size = new System.Drawing.Size(845, 446);
            this.songstable.TabIndex = 0;
            this.songstable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.songstable_CellBeginEdit);
            this.songstable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.songstable_CellEndEdit);
            this.songstable.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.songstable_CellMouseUp);
            this.songstable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.songstable_CellValueChanged);
            // 
            // selectColumn
            // 
            this.selectColumn.HeaderText = "Select";
            this.selectColumn.Name = "selectColumn";
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.MinimumWidth = 200;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 200;
            // 
            // forgeidColumn
            // 
            this.forgeidColumn.HeaderText = "CustomsForge ID";
            this.forgeidColumn.Name = "forgeidColumn";
            // 
            // lastsearchedColumn
            // 
            this.lastsearchedColumn.HeaderText = "Last searched";
            this.lastsearchedColumn.Name = "lastsearchedColumn";
            this.lastsearchedColumn.ReadOnly = true;
            // 
            // currentversionColumn
            // 
            this.currentversionColumn.HeaderText = "Current version";
            this.currentversionColumn.Name = "currentversionColumn";
            // 
            // newversionColumn
            // 
            this.newversionColumn.HeaderText = "New version";
            this.newversionColumn.Name = "newversionColumn";
            this.newversionColumn.ReadOnly = true;
            // 
            // instrumentsColumn
            // 
            this.instrumentsColumn.HeaderText = "Instruments";
            this.instrumentsColumn.Name = "instrumentsColumn";
            // 
            // tuningColumn
            // 
            this.tuningColumn.HeaderText = "Tuning";
            this.tuningColumn.Name = "tuningColumn";
            // 
            // customtoneColumn
            // 
            this.customtoneColumn.HeaderText = "Custom Tone";
            this.customtoneColumn.Name = "customtoneColumn";
            // 
            // dynamicdifficultyColumn
            // 
            this.dynamicdifficultyColumn.HeaderText = "Dynamic Difficulty";
            this.dynamicdifficultyColumn.Name = "dynamicdifficultyColumn";
            this.dynamicdifficultyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dynamicdifficultyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // difficultylevelsColumn
            // 
            this.difficultylevelsColumn.HeaderText = "Difficulty Levels";
            this.difficultylevelsColumn.Name = "difficultylevelsColumn";
            // 
            // riffrepeaterColumn
            // 
            this.riffrepeaterColumn.HeaderText = "Riff Repeater";
            this.riffrepeaterColumn.Name = "riffrepeaterColumn";
            this.riffrepeaterColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.riffrepeaterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // releasenotesColumn
            // 
            this.releasenotesColumn.HeaderText = "Release Notes";
            this.releasenotesColumn.Name = "releasenotesColumn";
            // 
            // deleteselectedBtn
            // 
            this.deleteselectedBtn.ForeColor = System.Drawing.Color.Red;
            this.deleteselectedBtn.Location = new System.Drawing.Point(742, 520);
            this.deleteselectedBtn.Name = "deleteselectedBtn";
            this.deleteselectedBtn.Size = new System.Drawing.Size(115, 23);
            this.deleteselectedBtn.TabIndex = 16;
            this.deleteselectedBtn.Text = "Delete selected";
            this.deleteselectedBtn.UseVisualStyleBackColor = true;
            this.deleteselectedBtn.Click += new System.EventHandler(this.deleteselectedBtn_Click);
            // 
            // scansongsBtn
            // 
            this.scansongsBtn.ForeColor = System.Drawing.Color.Green;
            this.scansongsBtn.Location = new System.Drawing.Point(12, 491);
            this.scansongsBtn.Name = "scansongsBtn";
            this.scansongsBtn.Size = new System.Drawing.Size(106, 23);
            this.scansongsBtn.TabIndex = 11;
            this.scansongsBtn.Text = "1. Scan for songs";
            this.scansongsBtn.UseVisualStyleBackColor = true;
            this.scansongsBtn.Click += new System.EventHandler(this.scansongsBtn_Click);
            // 
            // selectallLink
            // 
            this.selectallLink.AutoSize = true;
            this.selectallLink.Location = new System.Drawing.Point(12, 15);
            this.selectallLink.Name = "selectallLink";
            this.selectallLink.Size = new System.Drawing.Size(103, 13);
            this.selectallLink.TabIndex = 17;
            this.selectallLink.TabStop = true;
            this.selectallLink.Text = "Select / Deselect all";
            this.selectallLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.selectallLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search:";
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(171, 12);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(319, 20);
            this.searchTxt.TabIndex = 19;
            this.searchTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTxt_KeyUp);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(496, 10);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 20;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // hideselectedBtn
            // 
            this.hideselectedBtn.Location = new System.Drawing.Point(742, 491);
            this.hideselectedBtn.Name = "hideselectedBtn";
            this.hideselectedBtn.Size = new System.Drawing.Size(115, 23);
            this.hideselectedBtn.TabIndex = 21;
            this.hideselectedBtn.Text = "Hide selected";
            this.hideselectedBtn.UseVisualStyleBackColor = true;
            this.hideselectedBtn.Click += new System.EventHandler(this.hideselectedBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(780, 10);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 22;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // clearsearchLbl
            // 
            this.clearsearchLbl.AutoSize = true;
            this.clearsearchLbl.Location = new System.Drawing.Point(577, 15);
            this.clearsearchLbl.Name = "clearsearchLbl";
            this.clearsearchLbl.Size = new System.Drawing.Size(66, 13);
            this.clearsearchLbl.TabIndex = 23;
            this.clearsearchLbl.TabStop = true;
            this.clearsearchLbl.Text = "Clear search";
            this.clearsearchLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearsearchLbl_LinkClicked);
            // 
            // pathDialog
            // 
            this.pathDialog.Description = "Select your Rocksmith 2014 dlc folder.";
            this.pathDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(12, 520);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(106, 23);
            this.refreshBtn.TabIndex = 24;
            this.refreshBtn.Text = "Refresh list";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainprogressBar,
            this.mainstatusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mainprogressBar
            // 
            this.mainprogressBar.Name = "mainprogressBar";
            this.mainprogressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // mainstatusLbl
            // 
            this.mainstatusLbl.Name = "mainstatusLbl";
            this.mainstatusLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // songFolderScanner
            // 
            this.songFolderScanner.WorkerReportsProgress = true;
            this.songFolderScanner.WorkerSupportsCancellation = true;
            this.songFolderScanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.songFolderScanner_DoWork);
            this.songFolderScanner.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.songFolderScanner_ProgressChanged);
            this.songFolderScanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.songFolderScanner_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Created by Rutger Speksnijder. Version 1.0.";
            // 
            // updateVersionNumber
            // 
            this.updateVersionNumber.Location = new System.Drawing.Point(521, 520);
            this.updateVersionNumber.Name = "updateVersionNumber";
            this.updateVersionNumber.Size = new System.Drawing.Size(215, 23);
            this.updateVersionNumber.TabIndex = 29;
            this.updateVersionNumber.Text = "5. Update selected version numbers";
            this.updateVersionNumber.UseVisualStyleBackColor = true;
            this.updateVersionNumber.Click += new System.EventHandler(this.updateVersionNumber_Click);
            // 
            // searchSelectedBtn
            // 
            this.searchSelectedBtn.ForeColor = System.Drawing.Color.Black;
            this.searchSelectedBtn.Location = new System.Drawing.Point(124, 520);
            this.searchSelectedBtn.Name = "searchSelectedBtn";
            this.searchSelectedBtn.Size = new System.Drawing.Size(132, 23);
            this.searchSelectedBtn.TabIndex = 31;
            this.searchSelectedBtn.Text = "Identify selected";
            this.searchSelectedBtn.UseVisualStyleBackColor = true;
            this.searchSelectedBtn.Click += new System.EventHandler(this.searchSelectedBtn_Click);
            // 
            // searchAllBtn
            // 
            this.searchAllBtn.ForeColor = System.Drawing.Color.Green;
            this.searchAllBtn.Location = new System.Drawing.Point(124, 491);
            this.searchAllBtn.Name = "searchAllBtn";
            this.searchAllBtn.Size = new System.Drawing.Size(132, 23);
            this.searchAllBtn.TabIndex = 30;
            this.searchAllBtn.Text = "2. Identify all";
            this.searchAllBtn.UseVisualStyleBackColor = true;
            this.searchAllBtn.Click += new System.EventHandler(this.searchAllBtn_Click);
            // 
            // downloadselectedBtn
            // 
            this.downloadselectedBtn.Location = new System.Drawing.Point(383, 520);
            this.downloadselectedBtn.Name = "downloadselectedBtn";
            this.downloadselectedBtn.Size = new System.Drawing.Size(132, 23);
            this.downloadselectedBtn.TabIndex = 35;
            this.downloadselectedBtn.Text = "Download selected";
            this.downloadselectedBtn.UseVisualStyleBackColor = true;
            this.downloadselectedBtn.Click += new System.EventHandler(this.downloadselectedBtn_Click);
            // 
            // updateselectedBtn
            // 
            this.updateselectedBtn.Location = new System.Drawing.Point(262, 520);
            this.updateselectedBtn.Name = "updateselectedBtn";
            this.updateselectedBtn.Size = new System.Drawing.Size(115, 23);
            this.updateselectedBtn.TabIndex = 33;
            this.updateselectedBtn.Text = "Check selected";
            this.updateselectedBtn.UseVisualStyleBackColor = true;
            this.updateselectedBtn.Click += new System.EventHandler(this.updateselectedBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.ForeColor = System.Drawing.Color.Green;
            this.updateBtn.Location = new System.Drawing.Point(262, 491);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(115, 23);
            this.updateBtn.TabIndex = 32;
            this.updateBtn.Text = "3. Check all";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // downloadBtn
            // 
            this.downloadBtn.ForeColor = System.Drawing.Color.Green;
            this.downloadBtn.Location = new System.Drawing.Point(383, 491);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(132, 23);
            this.downloadBtn.TabIndex = 36;
            this.downloadBtn.Text = "4. Download all";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // SongListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 573);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.downloadselectedBtn);
            this.Controls.Add(this.updateselectedBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.searchSelectedBtn);
            this.Controls.Add(this.searchAllBtn);
            this.Controls.Add(this.updateVersionNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.clearsearchLbl);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.hideselectedBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectallLink);
            this.Controls.Add(this.deleteselectedBtn);
            this.Controls.Add(this.scansongsBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SongListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rocksmith Custom DLC Updater";
            this.Activated += new System.EventHandler(this.SongListForm_Activated);
            this.Load += new System.EventHandler(this.SongListForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songstable)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView songstable;
        private System.Windows.Forms.Button deleteselectedBtn;
        private System.Windows.Forms.Button scansongsBtn;
        private System.Windows.Forms.LinkLabel selectallLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button hideselectedBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.LinkLabel clearsearchLbl;
        private System.Windows.Forms.FolderBrowserDialog pathDialog;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar mainprogressBar;
        private System.Windows.Forms.ToolStripStatusLabel mainstatusLbl;
        public System.ComponentModel.BackgroundWorker songFolderScanner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn forgeidColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastsearchedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentversionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newversionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuningColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn customtoneColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dynamicdifficultyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficultylevelsColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn riffrepeaterColumn;
        private System.Windows.Forms.DataGridViewButtonColumn releasenotesColumn;
        private System.Windows.Forms.Button updateVersionNumber;
        private System.Windows.Forms.Button searchSelectedBtn;
        private System.Windows.Forms.Button searchAllBtn;
        private System.Windows.Forms.Button downloadselectedBtn;
        private System.Windows.Forms.Button updateselectedBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button downloadBtn;


    }
}

