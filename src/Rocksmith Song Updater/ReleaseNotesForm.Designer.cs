namespace Rocksmith_Custom_DLC_Updater
{
    partial class ReleaseNotesForm
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
            this.releasenotesBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // releasenotesBrowser
            // 
            this.releasenotesBrowser.AllowWebBrowserDrop = false;
            this.releasenotesBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.releasenotesBrowser.IsWebBrowserContextMenuEnabled = false;
            this.releasenotesBrowser.Location = new System.Drawing.Point(0, 0);
            this.releasenotesBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.releasenotesBrowser.Name = "releasenotesBrowser";
            this.releasenotesBrowser.ScriptErrorsSuppressed = true;
            this.releasenotesBrowser.Size = new System.Drawing.Size(464, 370);
            this.releasenotesBrowser.TabIndex = 0;
            this.releasenotesBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // ReleaseNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 370);
            this.Controls.Add(this.releasenotesBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReleaseNotesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release notes";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser releasenotesBrowser;

    }
}