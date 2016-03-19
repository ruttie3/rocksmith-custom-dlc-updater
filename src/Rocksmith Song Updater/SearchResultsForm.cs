using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rocksmith_Custom_DLC_Updater.Lib;
using Rocksmith_Custom_DLC_Updater.Models;
using Rocksmith_Custom_DLC_Updater.Helpers;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class SearchResultsForm : Form
    {
        // List of results
        public List<SongSearchResult> results = new List<SongSearchResult>();

        // Current result being viewed
        public SongSearchResult currentResult = new SongSearchResult();

        // Static current result id
        public static int currentId = 0;

        // String that was searched for
        public string searchedFor = "";

        public SearchResultsForm()
        {
            InitializeComponent();
        }

        private void SearchResultsForm_Load(object sender, EventArgs e)
        {
            // Check if there are any results
            if (this.results.Count == 0)
            {
                // Change the info label and hide the buttons and results box
                this.infoLbl.Text = "No results were found after searching for \"" + this.searchedFor + "\"";
                this.webpageBtn.Hide();
                this.chooseBtn.Hide();
                this.resultsBox.Hide();
                return;
            }

            // Update the info label
            this.infoLbl.Text = "The following results were found after searching for \"" + this.searchedFor + "\"";

            // Loop through the results and add them to the results box
            foreach (SongSearchResult result in this.results)
            {
                this.resultsBox.Items.Add(result.id + " - " + result.artist + " - " + result.title);
            }

            // Set our current result to the first result in the list
            this.currentResult = this.results[0];

            // Set the current id to the first result's id in the list
            Int32.TryParse(this.results[0].id, out SearchResultsForm.currentId);

            // Select the first item in the results box
            this.resultsBox.SelectedIndex = 0;

            // Check if there is only one result
            if (this.results.Count == 1)
            {
                // Disable the results box
                this.resultsBox.Enabled = false;

                // Change the info label
                this.infoLbl.Text = "The following result was found after searching for \"" + this.searchedFor + "\"";
            }

            // Update the info
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            // Update labels to the current result
            this.idLbl.Text = "ID: " + this.currentResult.id;
            this.artistLbl.Text = "Artist: " + this.currentResult.artist;
            this.titleLbl.Text = "Title: " + this.currentResult.title;
            this.albumLbl.Text = "Album: " + this.currentResult.album;
            this.tuningLbl.Text = "Tuning: " + this.currentResult.tuning;
            this.memberLbl.Text = "Member: " + this.currentResult.member;
            this.updatedLbl.Text = "Last updated: " + this.currentResult.updated;
            this.downloadsLbl.Text = "Downloads: " + this.currentResult.downloads;

            // Create the parts string
            string parts = "";
            if (this.currentResult.lead)
            {
                parts += "Lead, ";
            }
            if (this.currentResult.rhythm)
            {
                parts += "Rhythm, ";
            }
            if (this.currentResult.bass)
            {
                parts += "Bass, ";
            }
            if (this.currentResult.vocals)
            {
                parts += "Vocals, ";
            }

            // Remove the last ", " from the string if it's not empty
            if (parts != "")
            {
                parts = parts.Substring(0, parts.Length - 2);
            }

            this.partsLbl.Text = "Parts: " + parts;

            if (this.currentResult.dd)
            {
                this.ddLbl.Text = "Dynamic difficulty: Yes";
            }
            else
            {
                this.ddLbl.Text = "Dynamic difficulty: No";
            }
            
            // Create the platforms string
            string platforms = "";
            if (this.currentResult.pc)
            {
                platforms += "PC, ";
            }
            if (this.currentResult.mac)
            {
                platforms += "Mac, ";
            }
            if (this.currentResult.xbox)
            {
                platforms += "Xbox, ";
            }
            if (this.currentResult.playstation)
            {
                platforms += "Playstation, ";
            }

            // Remove the last ", " from the string if it's not empty
            if (platforms != "")
            {
                platforms = platforms.Substring(0, platforms.Length - 2);
            }

            this.platformsLbl.Text = "Platforms: " + platforms;
        }

        private void webpageBtn_Click(object sender, EventArgs e)
        {
            // Open the url for this song
            string url = "http://customsforge.com/page/customsforge_rs_2014_cdlc.html/_/pc-enabled-rs-2014-cdlc/update-r" + this.currentResult.id;
            System.Diagnostics.Process.Start(url);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
            this.Dispose();
        }

        private void resultsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set our current result to the selected result
            this.currentResult = this.results[this.resultsBox.SelectedIndex];

            // Set the current id to the selected result's id
            Int32.TryParse(this.results[this.resultsBox.SelectedIndex].id, out SearchResultsForm.currentId);

            // Update the info
            UpdateInfo();
        }
    }
}
