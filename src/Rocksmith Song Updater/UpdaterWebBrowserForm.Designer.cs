namespace Rocksmith_Custom_DLC_Updater
{
    partial class UpdaterWebBrowserForm
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
            this.updaterWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // updaterWebBrowser
            // 
            this.updaterWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updaterWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.updaterWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.updaterWebBrowser.Name = "updaterWebBrowser";
            this.updaterWebBrowser.ScriptErrorsSuppressed = true;
            this.updaterWebBrowser.Size = new System.Drawing.Size(267, 189);
            this.updaterWebBrowser.TabIndex = 0;
            // 
            // UpdaterWebBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 189);
            this.Controls.Add(this.updaterWebBrowser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterWebBrowserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Updater";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser updaterWebBrowser;

    }
}