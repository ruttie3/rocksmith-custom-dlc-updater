namespace Rocksmith_Custom_DLC_Updater
{
    partial class HiddenSongsForm
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
            this.hiddensongstable = new System.Windows.Forms.DataGridView();
            this.restoreselectedBtn = new System.Windows.Forms.Button();
            this.restoreallBtn = new System.Windows.Forms.Button();
            this.selectallLbl = new System.Windows.Forms.LinkLabel();
            this.selectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forgeidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.hiddensongstable)).BeginInit();
            this.SuspendLayout();
            // 
            // hiddensongstable
            // 
            this.hiddensongstable.AllowUserToAddRows = false;
            this.hiddensongstable.AllowUserToDeleteRows = false;
            this.hiddensongstable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.hiddensongstable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hiddensongstable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectColumn,
            this.nameColumn,
            this.forgeidColumn});
            this.hiddensongstable.Dock = System.Windows.Forms.DockStyle.Top;
            this.hiddensongstable.Location = new System.Drawing.Point(0, 0);
            this.hiddensongstable.Name = "hiddensongstable";
            this.hiddensongstable.Size = new System.Drawing.Size(864, 415);
            this.hiddensongstable.TabIndex = 1;
            // 
            // restoreselectedBtn
            // 
            this.restoreselectedBtn.Location = new System.Drawing.Point(132, 421);
            this.restoreselectedBtn.Name = "restoreselectedBtn";
            this.restoreselectedBtn.Size = new System.Drawing.Size(114, 23);
            this.restoreselectedBtn.TabIndex = 2;
            this.restoreselectedBtn.Text = "Restore selected";
            this.restoreselectedBtn.UseVisualStyleBackColor = true;
            this.restoreselectedBtn.Click += new System.EventHandler(this.restoreselectedBtn_Click);
            // 
            // restoreallBtn
            // 
            this.restoreallBtn.Location = new System.Drawing.Point(12, 421);
            this.restoreallBtn.Name = "restoreallBtn";
            this.restoreallBtn.Size = new System.Drawing.Size(114, 23);
            this.restoreallBtn.TabIndex = 3;
            this.restoreallBtn.Text = "Restore all";
            this.restoreallBtn.UseVisualStyleBackColor = true;
            this.restoreallBtn.Click += new System.EventHandler(this.restoreallBtn_Click);
            // 
            // selectallLbl
            // 
            this.selectallLbl.AutoSize = true;
            this.selectallLbl.Location = new System.Drawing.Point(252, 426);
            this.selectallLbl.Name = "selectallLbl";
            this.selectallLbl.Size = new System.Drawing.Size(103, 13);
            this.selectallLbl.TabIndex = 4;
            this.selectallLbl.TabStop = true;
            this.selectallLbl.Text = "Select / Deselect all";
            this.selectallLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.selectallLbl_LinkClicked);
            // 
            // selectColumn
            // 
            this.selectColumn.HeaderText = "Select";
            this.selectColumn.Name = "selectColumn";
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // forgeidColumn
            // 
            this.forgeidColumn.HeaderText = "CustomsForge ID";
            this.forgeidColumn.Name = "forgeidColumn";
            this.forgeidColumn.ReadOnly = true;
            // 
            // HiddenSongsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 454);
            this.Controls.Add(this.selectallLbl);
            this.Controls.Add(this.restoreallBtn);
            this.Controls.Add(this.restoreselectedBtn);
            this.Controls.Add(this.hiddensongstable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HiddenSongsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hidden songs";
            ((System.ComponentModel.ISupportInitialize)(this.hiddensongstable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView hiddensongstable;
        private System.Windows.Forms.Button restoreselectedBtn;
        private System.Windows.Forms.Button restoreallBtn;
        private System.Windows.Forms.LinkLabel selectallLbl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn forgeidColumn;

    }
}