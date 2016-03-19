namespace Rocksmith_Custom_DLC_Updater
{
    partial class SearcherWebBrowserForm
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
            this.searcherWebBrowser = new Gecko.GeckoWebBrowser();
            this.SuspendLayout();
            // 
            // searcherWebBrowser
            // 
            this.searcherWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searcherWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.searcherWebBrowser.Name = "searcherWebBrowser";
            this.searcherWebBrowser.Size = new System.Drawing.Size(1644, 861);
            this.searcherWebBrowser.TabIndex = 0;
            this.searcherWebBrowser.UseHttpActivityObserver = false;
            // 
            // SearcherWebBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 861);
            this.Controls.Add(this.searcherWebBrowser);
            this.Name = "SearcherWebBrowserForm";
            this.Text = "SearcherWebBrowserForm";
            this.ResumeLayout(false);

        }

        #endregion

        public Gecko.GeckoWebBrowser searcherWebBrowser;

    }
}