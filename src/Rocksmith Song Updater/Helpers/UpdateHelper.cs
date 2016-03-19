using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using Rocksmith_Custom_DLC_Updater.Lib;
using Rocksmith_Custom_DLC_Updater.Models;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Rocksmith_Custom_DLC_Updater.Helpers
{
    static class UpdateHelper
    {
        // Variables for searching for songs
        public static int totalNewSongs = 0;
        public static int totalRemoved = 0;
        public static string currentFile = "";

        // Keep a songUpdaterForm as a static field
        private static SongUpdaterForm songUpdaterForm;

        // Keep a songSearcherForm as a static field
        private static SongSearcherForm songSearcherForm;

        public static List<string> ScanSongsFolder()
        {
            // Create a list to hold all file names
            List<string> fileNames = new List<string>();

            // Check if the path exists
            if (SettingsHelper.GetPath() == "" || !Directory.Exists(SettingsHelper.GetPath()))
            {
                // Return the empty list
                return fileNames;
            }

            // Search the directory for songs
            string[] songs = Directory.GetFiles(SettingsHelper.GetPath(), "*_p.psarc");

            // Loop through all found files matching our pattern
            for (int i = 0; i < songs.Length; i++)
            {
                // Split the file on backslashes and get the last part
                string fileName = songs[i].Split('\\').Last<string>();

                // Remove the '_p.psarc' part from the file name
                fileName = fileName.Replace("_p.psarc", "");

                // Add the file name to the list
                fileNames.Add(fileName);
            }

            // Return the list of file names
            return fileNames;
        }

        public static void SearchSongs(List<object> songs = null)
        {
            // Check if we're logged in
            if (SettingsHelper.GetLoggedIn() || LoginHelper.DoLogin())
            {
                // Keep track if we actually created a new instance of the search form.
                // - If so, we also need to start the searching for songs after showing the form
                bool createdForm = false;

                // Creates a new instance of the song searcher form if it doesn't exist. Otherwise will show the current updater form
                if (UpdateHelper.songSearcherForm == null || UpdateHelper.songSearcherForm.IsDisposed)
                {
                    UpdateHelper.songSearcherForm = new SongSearcherForm();
                    createdForm = true;
                }

                // Check if we should ask for song names
                UpdateHelper.songSearcherForm.askForSongName = !SettingsHelper.GetDontAskForSongName();

                // Show the form
                FormHelper.BringToFront(UpdateHelper.songSearcherForm);

                // Check if the form is created
                if (createdForm)
                {
                    UpdateHelper.songSearcherForm.StartSearching(songs);
                    UpdateHelper.songSearcherForm.SearchingFinished += new EventHandler(UpdateHelper.FindingFinished);
                }
            }
        }

        public static void UpdateSongs(List<object> songs = null)
        {
            // If we should update, start the song updater.
            if (SettingsHelper.GetLoggedIn() || LoginHelper.DoLogin())
            {
                // Keep track of if we actually created a new instance. If so, we also need to start the update after showing the form
                bool createdForm = false;
                
                // Creates a new instance of the song updater form if it doesn't exist. Otherwise will show the current updater form
                if (UpdateHelper.songUpdaterForm == null || UpdateHelper.songUpdaterForm.IsDisposed)
                {
                    UpdateHelper.songUpdaterForm = new SongUpdaterForm();
                    createdForm = true;
                }

                // Show the form
                FormHelper.BringToFront(UpdateHelper.songUpdaterForm);

                // If the form is created, start updating
                if (createdForm)
                {
                    UpdateHelper.songUpdaterForm.StartUpdating(songs);
                    UpdateHelper.songUpdaterForm.UpdatingFinished += new EventHandler(UpdateHelper.UpdatingFinished);
                }
            }
        }

        private static void OnSearchingFinished(RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompletedEventHandler handler = SearchingFinished;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        public static event RunWorkerCompletedEventHandler SearchingFinished;

        private static void UpdatingFinished(object sender, EventArgs e)
        {
            // Call OnSearchingFinished
            OnSearchingFinished(null);
        }

        private static void OnFindingSongsFinished(RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompletedEventHandler handler = FindingSongsFinished;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        public static event RunWorkerCompletedEventHandler FindingSongsFinished;

        private static void FindingFinished(object sender, EventArgs e)
        {
            // Call OnFindingSongsFinished
            OnFindingSongsFinished(null);
        }
    }
}
