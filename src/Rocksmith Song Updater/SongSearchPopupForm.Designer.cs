namespace Rocksmith_Custom_DLC_Updater
{
    partial class SongSearchPopupForm
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
            this.searchingForLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.doneBtn = new System.Windows.Forms.Button();
            this.askagainChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchingForLbl
            // 
            this.searchingForLbl.AutoSize = true;
            this.searchingForLbl.Location = new System.Drawing.Point(12, 9);
            this.searchingForLbl.Name = "searchingForLbl";
            this.searchingForLbl.Size = new System.Drawing.Size(73, 13);
            this.searchingForLbl.TabIndex = 0;
            this.searchingForLbl.Text = "Searching for:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search for:";
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(88, 37);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(207, 20);
            this.searchTxt.TabIndex = 2;
            // 
            // doneBtn
            // 
            this.doneBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.doneBtn.Location = new System.Drawing.Point(192, 85);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(75, 23);
            this.doneBtn.TabIndex = 3;
            this.doneBtn.Text = "Done";
            this.doneBtn.UseVisualStyleBackColor = true;
            // 
            // askagainChk
            // 
            this.askagainChk.AutoSize = true;
            this.askagainChk.Location = new System.Drawing.Point(23, 63);
            this.askagainChk.Name = "askagainChk";
            this.askagainChk.Size = new System.Drawing.Size(272, 17);
            this.askagainChk.TabIndex = 4;
            this.askagainChk.Text = "Don\'t ask me again (can be changed in the settings)";
            this.askagainChk.UseVisualStyleBackColor = true;
            // 
            // SongSearchPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 112);
            this.ControlBox = false;
            this.Controls.Add(this.askagainChk);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchingForLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SongSearchPopupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search for this text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button doneBtn;
        public System.Windows.Forms.TextBox searchTxt;
        public System.Windows.Forms.Label searchingForLbl;
        public System.Windows.Forms.CheckBox askagainChk;
    }
}