using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Rocksmith_Custom_DLC_Updater.Lib;
using Rocksmith_Custom_DLC_Updater.Models;
using Rocksmith_Custom_DLC_Updater.Helpers;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class SongListForm : Form
    {
        // Boolean to keep track if we need to select all or not
        private bool selectAll = true;

        // Boolean to set if the list should refresh on focus
        public static bool shouldRefreshList = false;

        // Song object to keep track of the current song being edited
        private Song editingSong = null;

        // String to keep track of the current search
        private string currentSearch = "";

        // List of editable columns
        private int[] editableColumns = new int[] { 1, 2, 4, 6, 7, 10 };

        // List of clickable columns
        private int[] clickableColumns = new int[] { 8, 9, 11, 12 };

        public SongListForm()
        {
            InitializeComponent();
        }

        private void SongListForm_Load(object sender, EventArgs e)
        {
            int result = ApplicationHelper.InitializeApplication();
            bool shouldSearch = false;

            // Check if we should show the disclaimer
            if (result > 0 && SettingsHelper.GetDisclaimer())
            {
                System.Windows.Forms.DialogResult disclaimerResult = MessageBox.Show("Use this program at your own risk. The creator of this application and this application itself is not affiliated with customsforge in any way.", "Disclaimer", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (disclaimerResult == System.Windows.Forms.DialogResult.Yes)
                {
                    SettingsHelper.SetDisclaimer(false);
                }
                else
                {
                    Application.Exit();
                }            
            }

            switch (result)
            {
                case 0:
                    MessageBox.Show("The database file could not be created. Try running the application as administrator. Error code: 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    if (MessageBox.Show("You haven't set your path yet. Want to do that now?", "Rocksmith 2014 DLC path", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (pathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            SettingsHelper.SetPath(pathDialog.SelectedPath);
                            shouldSearch = true;
                        }
                    }
                    break;
                case 2:
                    if (MessageBox.Show("The path you selected could not be found. Do you want to set a different path?", "Rocksmith 2014 DLC path", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (pathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            SettingsHelper.SetPath(pathDialog.SelectedPath);
                            shouldSearch = true;
                        }
                    }
                    break;
                case 3:
                    shouldSearch = true;
                    break;
            }

            if (shouldSearch)
            {
                this.ScanForSongs();
            }
        }

        private void scansongsBtn_Click(object sender, EventArgs e)
        {
            this.ScanForSongs();
        }

        private void ScanForSongs()
        {
            // Start our songFolderScanner in the background
            this.songFolderScanner.RunWorkerAsync();
        }

        private void songFolderScanner_DoWork(object sender, DoWorkEventArgs e)
        {
            // Set all found to 0 for every song
            Song.SetFoundZero();

            // Find all songs on the disk
            List<string> files = UpdateHelper.ScanSongsFolder();
            int totalFiles = files.Count;
            int currentSong = 0;

            // Counter for new songs
            int totalNewSongs = 0;

            // Check if every song on the disk exists in the database
            foreach (string file in files)
            {
                Song song = new Song();
                song.Find(new string[] { "name", "=", file });
                if ((long)song.id != 0)
                {
                    // Exists, so set found to 1
                    song.found = 1;
                    song.Update();
                }
                else
                {
                    // Doesn't exist, create
                    song.name = file;
                    song.found = 1;
                    song.Insert();
                    totalNewSongs++;
                }
                currentSong++;

                // Figure out the current percentage.
                UpdateHelper.currentFile = file;
                double currentPercentage = ((double)currentSong / (double)totalFiles) * 100;
                songFolderScanner.ReportProgress((int)currentPercentage);
            }

            // Retrieve the total of songs that are not found and remove them from the database
            int totalRemoved = Song.RemoveFoundZero();

            // Set the results as static fields on this form
            UpdateHelper.totalNewSongs = totalNewSongs;
            UpdateHelper.totalRemoved = totalRemoved;
        }

        private void songFolderScanner_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update the progress bar
            this.mainprogressBar.Value = e.ProgressPercentage;
            this.mainstatusLbl.Text = "Scanning file: " + UpdateHelper.currentFile + "...";
        }

        private void songFolderScanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Show a message box with a total of songs added and removed
            MessageBox.Show(UpdateHelper.totalNewSongs + " new song(s) added and " + UpdateHelper.totalRemoved + " song(s) removed!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh the list
            this.RefreshList(null, null);

            // Set status label to how many we added
            this.mainstatusLbl.Text = UpdateHelper.totalNewSongs + " new song(s) added and " + UpdateHelper.totalRemoved + " song(s) removed!";

            // Create a timer to clear the status label
            Timer myTimer = new Timer();
            myTimer.Interval = 3000;
            myTimer.Tick += (snd, ev) =>
            {
                this.mainstatusLbl.Text = "";
                myTimer.Stop();
            };
            myTimer.Start();

            // Empty the progress bar
            this.mainprogressBar.Value = 0;
        }

        public void RefreshList(object sender, RunWorkerCompletedEventArgs e)
        {
            // Create a new list of songs
            Song baseSong = new Song();
            List<object> songs = new List<object>();

            // Check if we have a search
            if (this.currentSearch != "")
            {
                songs = baseSong.FindAll(new string[,] { { "hidden", "=", "0" }, { "name", "LIKE", "%" + this.currentSearch + "%" } }, "ORDER BY name");
            }
            else
            {
                songs = baseSong.FindAll(new string[] { "hidden", "=", "0" }, "ORDER BY name");
            }

            // Clear the table
            songstable.Rows.Clear();

            // Loop through all the songs and add them to the table
            foreach (Song song in songs)
            {
                // Find data and create booleans
                bool custom_tone = false;
                if (song.custom_tone == 1)
                {
                    custom_tone = true;
                }

                bool dynamic_difficulty = false;
                if (song.dynamic_difficulty == 1)
                {
                    dynamic_difficulty = true;
                }

                bool riff_repeater = false;
                if (song.riff_repeater == 1)
                {
                    riff_repeater = true;
                }

                int index = songstable.Rows.Add(false, song.name, song.customsforge_id, song.last_searched, song.current_version, song.new_version, song.instruments, song.tuning, custom_tone, dynamic_difficulty, song.difficulty_levels, riff_repeater, "View");

                // Check if there is a new version availabe for this song. If so, change the forecolor of each cell to green and add the download button
                if (song.new_version != song.current_version && song.new_version != "")
                {
                    foreach (DataGridViewCell cell in songstable.Rows[index].Cells)
                    {
                        cell.Style.ForeColor = Color.Green;
                    }
                }

                // Check if this song's update check failed. If so, change the forecolor of each cell to red
                if (song.failed_update == 1)
                {
                    foreach (DataGridViewCell cell in songstable.Rows[index].Cells)
                    {
                        cell.Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            // Show the path dialog and update the path
            if (pathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Update the path to the selected path
                SettingsHelper.SetPath(pathDialog.SelectedPath);
            }
        }

        private void songstable_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (songstable.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex > -1 && this.clickableColumns.Contains(e.ColumnIndex))
            {
                songstable.EndEdit();
            }

            // If it's a button check if it's the release notes button
            if (songstable.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1 && this.clickableColumns.Contains(e.ColumnIndex))
            {
                // Find the row
                DataGridViewRow row = songstable.Rows[e.RowIndex];

                // Find the song
                Song song = new Song();
                song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                if (song.name == null) {
                    // Show an error
                    MessageBox.Show("The song could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Show the release notes
                FormHelper.ShowReleaseNotesForm(song.name, song.release_notes);
            }
        }

        private void songstable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(songstable.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) || e.RowIndex < 0 || !this.clickableColumns.Contains(e.ColumnIndex))
            {
                return;
            }

            // Find the row
            DataGridViewRow row = songstable.Rows[e.RowIndex];

            // Find the song
            Song theSong = new Song();
            theSong.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
            if (theSong.name == null)
            {
                // Show an error
                MessageBox.Show("Editing this song will not work as it could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the new value
            bool newCheckboxValue = false;
            if (row.Cells[e.ColumnIndex] != null && row.Cells[e.ColumnIndex].Value != null)
            {
                newCheckboxValue = (bool)row.Cells[e.ColumnIndex].Value;
            }

            // Change data based on column index
            switch (e.ColumnIndex)
            {
                case 8: // Custom Tone
                    // Update the song
                    if ((bool)newCheckboxValue)
                    {
                        theSong.custom_tone = 1;
                    }
                    else
                    {
                        theSong.custom_tone = 0;
                    }
                    theSong.Update();
                    break;
                case 9: // Dynamic Difficulty
                    // Update the song
                    if ((bool)newCheckboxValue)
                    {
                        theSong.dynamic_difficulty = 1;
                    }
                    else
                    {
                        theSong.dynamic_difficulty = 0;
                    }
                    theSong.Update();
                    break;
                case 11: // Riff Repeater
                    // Update the song
                    if ((bool)newCheckboxValue)
                    {
                        theSong.riff_repeater = 1;
                    }
                    else
                    {
                        theSong.riff_repeater = 0;
                    }
                    theSong.Update();
                    break;
            }
        }

        private void songstable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) || e.RowIndex < 0 || !this.editableColumns.Contains(e.ColumnIndex)) 
            {
                return;
            }

            // Find the song
            DataGridViewRow row = songstable.Rows[e.RowIndex];
            Song song = new Song();
            song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
            if (song.name == null)
            {
                // Show an error
                MessageBox.Show("Editing this song will not work as it could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set our current editing song
            this.editingSong = song;
        }

        private void songstable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) || e.RowIndex < 0 || !this.editableColumns.Contains(e.ColumnIndex))
            {
                return;
            }

            // Find the current row
            DataGridViewRow row = songstable.Rows[e.RowIndex];

            // Check if we have a song
            Song song = this.editingSong;
            if (song == null)
            {
                MessageBox.Show("This song could not be edited as it could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the new value
            string newValue = "";
            if (row.Cells[e.ColumnIndex].Value != null)
            {
                newValue = row.Cells[e.ColumnIndex].Value.ToString();
            }

            // Edit song properties based on column number
            switch (e.ColumnIndex)
            {
                case 1: // Name
                    // Save the old value
                    string oldValue = song.name;

                    // Check if the name isn't empty
                    if (newValue == "")
                    {
                        // Set EditingSong to null
                        this.editingSong = null;

                        // Change back to the old value
                        row.Cells[e.ColumnIndex].Value = oldValue;

                        // Show an error
                        MessageBox.Show("The song name can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // If the song name is the same, ignore
                    if (newValue == song.name)
                    {
                        // Set EditingSong to null
                        this.editingSong = null;
                        return;
                    }

                    // Check if the song doesn't already exist
                    Song findSong = new Song();
                    findSong.Find(new string[] { "name", "=", newValue });
                    if (findSong.name != null)
                    {
                        // Set EditingSong to null
                        this.editingSong = null;

                        // Change back to the old value
                        row.Cells[e.ColumnIndex].Value = oldValue;

                        // Show an error
                        MessageBox.Show("This song already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Rename the song
                    song.name = newValue;
                    song.Update();

                    // Ask if the user also wants to update the song name on disk
                    if (SettingsHelper.GetAlwaysRename() || MessageBox.Show("Would you like the song name to be updated on the disk as well? You can turn this check off in the settings", "Rename on disk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string songFolderPath = SettingsHelper.GetPath();
                        string currentSongPath = songFolderPath + "\\" + oldValue + "_p.psarc";
                        string newSongPath = songFolderPath + "\\" + newValue + "_p.psarc";
                        try
                        {
                            // Move to the new location
                            File.Move(currentSongPath, newSongPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while renaming the file. Please check manually.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case 2: // Customsforge id
                    // Try to parse the customs forge id as an integer. If it fails, show an error message but still continue. It will set the id to 0

                    // If the new value is empty, set it to 0
                    if (newValue == "")
                    {
                        newValue = "0";
                    }

                    // Try to parse the value
                    int intId = 0;
                    if (!int.TryParse(newValue, out intId))
                    {
                        // Show a warning
                        MessageBox.Show("You entered a string as the customsforge id. Keep in mind that these should be numbers. The id will be 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        // Set the value to 0
                        row.Cells[e.ColumnIndex].Value = "0";
                    }
                    
                    // Update the song
                    song.customsforge_id = intId;
                    song.Update();
                    break;
                case 4: // Current version
                    // Update the song
                    song.current_version = newValue;
                    song.Update();

                    // If the new version is different from the current version, show the row with green color
                    if (song.new_version != song.current_version && song.new_version != "")
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // Set the fore color of the cell to green
                            cell.Style.ForeColor = Color.Green;
                        }
                    }

                    // If the new version is the same, show the row with a black color
                    if (song.new_version == song.current_version)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // Set the fore color of the cell to black
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                    break;
                case 6: // Instruments
                    // Update the song
                    song.instruments = newValue;
                    song.Update();
                    break;
                case 7: // Tuning
                    // Update the song
                    song.tuning = newValue;
                    song.Update();
                    break;
                case 10: // Difficulty Levels
                    // Cast the value to int
                    int difficulty_levels = 0;
                    int.TryParse(newValue, out difficulty_levels);
                    song.difficulty_levels = difficulty_levels;
                    song.Update();
                    break;
            }

            // Set EditingSong to null
            this.editingSong = null;
        }

        private void selectallLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Loop through all rows and set selected to the selectall value
            foreach (DataGridViewRow row in songstable.Rows) {
                ((DataGridViewCheckBoxCell)row.Cells[0]).Value = this.selectAll;
            }
            this.selectAll = !this.selectAll;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            // Show the settings window
            FormHelper.ShowSettingsForm();
        }

        private void hideselectedBtn_Click(object sender, EventArgs e)
        {
            // Show a message box
            if (MessageBox.Show("Are you sure you want to hide these songs?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            foreach (DataGridViewRow row in songstable.Rows)
            {
                if ((bool)row.Cells[0].Value == true)
                {
                    // Find the song
                    Song song = new Song();
                    song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                    if (song.name != null)
                    {
                        // Change hidden to 1 and update the song
                        song.hidden = 1;
                        song.Update();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong while hiding the song. The song could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Refresh the list
            this.RefreshList(null, null);
        }

        private void SongListForm_Activated(object sender, EventArgs e)
        {
            // Check if we should refresh the list
            if (SongListForm.shouldRefreshList)
            {
                this.RefreshList(null, null);
                SongListForm.shouldRefreshList = false;
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // Refresh list
            this.RefreshList(null, null);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Load the updater
            UpdateHelper.UpdateSongs();
            UpdateHelper.SearchingFinished += new RunWorkerCompletedEventHandler(this.RefreshList);
        }

        private void updateselectedBtn_Click(object sender, EventArgs e)
        {
            // Create a list of all checked songs
            List<object> songs = new List<object>();

            // Loop through all rows and check if they're checked
            foreach (DataGridViewRow row in songstable.Rows)
            {
                if ((bool)row.Cells[0].Value == true)
                {
                    // Find the song by name and not hidden
                    Song song = new Song();
                    song.Find(new string[,] { { "name", "=", (string)row.Cells[1].Value }, { "hidden", "=", "0" } });
                    if (song.name != null)
                    {
                        songs.Add(song);
                    }
                }
            }

            // Start the update process with the list of songs
            UpdateHelper.UpdateSongs(songs);
            UpdateHelper.SearchingFinished += new RunWorkerCompletedEventHandler(this.RefreshList);
        }

        private void deleteselectedBtn_Click(object sender, EventArgs e)
        {
            // Ask the user if they are sure
            System.Windows.Forms.DialogResult result = MessageBox.Show("Are you sure you want to delete these songs?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // Should we delete from disk
            bool deleteFromDisk = false;
            string songFolderPath = "";

            // Show a messagebox to ask the user if they want to remove the songs from the disk as well
            if (SettingsHelper.GetAlwaysDelete() || MessageBox.Show("Do you want to delete the songs from the disk as well? You can turn this check off in the settings.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                deleteFromDisk = true;
                songFolderPath = SettingsHelper.GetPath();
            }

            // Delete the songs from the database
            foreach (DataGridViewRow row in songstable.Rows)
            {
                if ((bool)row.Cells[0].Value == false)
                {
                    continue;
                }

                // Find the song by name
                Song song = new Song();
                song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                if (song.name == null)
                {
                    continue;
                }

                // Delete the song
                song.Delete();

                // Check if we have to remove from the disk as well
                if (!deleteFromDisk)
                {
                    continue;
                }

                // Try to delete the file
                string songPath = songFolderPath + "\\" + song.name + "_p.psarc";
                try
                {
                    File.Delete(songPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting the file. Detailed error message: " + ex.Message);
                }
            }

            // Refresh the list
            this.RefreshList(null, null);

            // Show a message box
            MessageBox.Show("The songs have been removed. If you have only removed them from the list, they will be added again when you scan for songs.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearsearchLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Set the CurrentSearch to empty
            this.currentSearch = "";

            // Clear the textbox
            this.searchTxt.Text = "";

            // Refresh the list
            this.RefreshList(null, null);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Set the currentSearch to the searchTxt's text
            this.currentSearch = this.searchTxt.Text;

            // Refresh the list
            this.RefreshList(null, null);
        }

        private void searchTxt_KeyUp(object sender, KeyEventArgs e)
        {
            // Execute search button press
            this.searchBtn.PerformClick();
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            // Show a message box
            if (MessageBox.Show("Are you sure you want to open all the download links?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // Loop through all files that can be updated and start a process for their download link
            Song baseSong = new Song();
            List<object> songs = baseSong.FindAll(new string[] { "hidden", "=", "0" }, "ORDER BY name ASC");
            foreach (Song song in songs)
            {
                // Check if the song has a new version and the customsforge id is not 0
                if (song.new_version != song.current_version && song.new_version != "" && song.customsforge_id != 0)
                {
                    // Open the link
                    string link = "http://customsforge.com/process.php?id=" + song.customsforge_id.ToString();
                    System.Diagnostics.Process.Start(link);
                }
            }
        }

        private void downloadselectedBtn_Click(object sender, EventArgs e)
        {
            // Show a message box
            if (MessageBox.Show("Are you sure you want to open the selected download links?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // Loop through every row and find out if they're selected
            foreach (DataGridViewRow row in songstable.Rows)
            {
                // Continue if they're not selected
                if ((bool)row.Cells[0].Value == false)
                {
                    continue;
                }

                // Find the song
                Song song = new Song();
                song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                if (song.name != null && song.customsforge_id != 0)
                {
                    // Open the link
                    string link = "http://customsforge.com/process.php?id=" + song.customsforge_id.ToString();
                    System.Diagnostics.Process.Start(link);
                }
            }
        }

        private void updateVersionNumber_Click(object sender, EventArgs e)
        {
            // Show a message box
            if (MessageBox.Show("Are you sure you want to update the selected songs version numbers?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            // Loop through every row and find out if the row is selected
            foreach (DataGridViewRow row in songstable.Rows)
            {
                // Continue if the row isn't selected
                if ((bool)row.Cells[0].Value == false)
                {
                    continue;
                }

                // Find the song
                Song song = new Song();
                song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                if (song.name != null && song.new_version != null && song.new_version != "")
                {
                    // Update the song's current version to the new version
                    song.current_version = song.new_version;
                    song.Update();
                }
            }

            // Refresh the list
            this.RefreshList(null, null);
        }

        private void searchAllBtn_Click(object sender, EventArgs e)
        {
            // Load the searcher
            UpdateHelper.SearchSongs();
            UpdateHelper.FindingSongsFinished += new RunWorkerCompletedEventHandler(this.RefreshList);
        }

        private void searchSelectedBtn_Click(object sender, EventArgs e)
        {
            // Create a list of all checked songs
            List<object> songs = new List<object>();

            // Loop through all rows and check if they're checked
            foreach (DataGridViewRow row in songstable.Rows)
            {
                if ((bool)row.Cells[0].Value == true)
                {
                    // Find the song by name and not hidden
                    Song song = new Song();
                    song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                    if (song.name != null)
                    {
                        songs.Add(song);
                    }
                }
            }

            // Start the search process with the list of songs
            UpdateHelper.SearchSongs(songs);
            UpdateHelper.FindingSongsFinished += new RunWorkerCompletedEventHandler(this.RefreshList);
        }
    }
}
