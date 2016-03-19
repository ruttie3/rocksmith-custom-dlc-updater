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
    public partial class HiddenSongsForm : Form
    {
        // Boolean to keep track if we need to select all or not
        private bool selectAll = false;

        public HiddenSongsForm()
        {
            InitializeComponent();
        }

        public void LoadList()
        {
            // Fill the list
            Song baseSong = new Song();
            List<object> songs = baseSong.FindAll(new string[] { "hidden", "=", "1" }, "ORDER BY name");

            // Clear the list
            hiddensongstable.Rows.Clear();

            // Loop through all the songs and add them to the list
            foreach (Song song in songs)
            {
                hiddensongstable.Rows.Add(true, song.name, song.customsforge_id);
            }
        }

        private void restoreallBtn_Click(object sender, EventArgs e)
        {
            // Set all hidden songs to 0
            Song.UnhideAllSongs();

            // Clear the list
            hiddensongstable.Rows.Clear();

            // Set ShouldUpdateList to true on the SongListForm
            SongListForm.shouldRefreshList = true;
        }

        private void restoreselectedBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in hiddensongstable.Rows)
            {
                if ((bool)row.Cells[0].Value == true) {
                    Song song = new Song();
                    song.Find(new string[] { "name", "=", (string)row.Cells[1].Value });
                    if (song.name != "")
                    {
                        // Change hidden to 0 and update the song
                        song.hidden = 0;
                        song.Update();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong while restoring the song. The song could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Reload the list
            this.LoadList();

            // Set ShouldUpdateList to true on the SongListForm
            SongListForm.shouldRefreshList = true;
        }

        private void selectallLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Loop through all rows and set selected to the selectall value
            foreach (DataGridViewRow row in hiddensongstable.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells[0]).Value = this.selectAll;
            }
            this.selectAll = !this.selectAll;
        }
    }
}
