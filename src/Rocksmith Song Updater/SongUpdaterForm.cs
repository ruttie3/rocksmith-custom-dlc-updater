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
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Net;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class SongUpdaterForm : Form
    {
        // Updater web browser form object
        public UpdaterWebBrowserForm webBrowserForm;

        // List to hold all songs
        public List<object> songs = new List<object>();

        // Integer to store current song number
        public int currentSong = 0;

        // Integer to store total number of songs
        public int totalSongs = 0;

        public SongUpdaterForm()
        {
            InitializeComponent();
        }

        public void StartUpdating(List<object> songs = null)
        {
            // Find all custom songs. If songs is not null, use it as the updater's song list
            if (songs != null)
            {
                this.songs = songs;
            }
            else
            {
                Song baseSong = new Song();
                this.songs = baseSong.FindAll(new string[,] { { "hidden", "=", "0" }, { "customsforge_id", "!=", "0" } }, "ORDER BY name");
            }

            // Create a variable to keep track of the current song and a total of songs to update
            this.currentSong = 0;
            this.totalSongs = this.songs.Count;

            // Check if total songs isn't 0
            if (this.totalSongs == 0)
            {
                MessageBox.Show("You don't have any songs to update. Please check if you have custom songs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnUpdatingFinished(EventArgs.Empty);
                this.Close();
                return;
            }

            // Set our progressbar
            this.updatingProgress.Maximum = this.totalSongs;

            // Call updateNextSong() to start updating
            this.updateNextSong();
        }

        public void updateNextSong()
        {
            // If there are no songs left to update, trigger the onupdatingfinished event.
            if (this.songs.Count == 0)
            {
                OnUpdatingFinished(EventArgs.Empty);
                this.Close();
                return;
            }

            // Increment current song number
            this.currentSong++;

            // Get the first song from the list
            Song song = (Song)this.songs[0];

            // Set the song's last_searched to the current date and clear certain update fields
            DateTime today = DateTime.Today;
            song.last_searched = today.ToString("dd-MM-yyyy");
            song.failed_update = 0;
            song.uptodate = 0;
            song.new_version = "";
            song.Update();

            // Set the progress bar and status label
            this.updatingProgress.Value = this.currentSong;
            this.updatingLbl.Text = "Searching: " + song.name;

            // If the song has no customsforge id, we can't update it so we skip it.
            if (song.customsforge_id == 0)
            {
                // Set the song's failed_update to 1
                song.failed_update = 1;
                song.Update();

                // Call the update next song
                this.songs.RemoveAt(0);
                this.updateNextSong();
                return;
            }

            // If we DO have a customsforge id, we can create the link
            // This functionality will break if customsforge ever updates their urls
            string link = "http://customsforge.com/page/customsforge_rs_2014_cdlc.html/_/pc-enabled-rs-2014-cdlc/update-r" + song.customsforge_id.ToString();

            // Delete the webbrowser form if it still exists
            if (this.webBrowserForm != null)
            {
                this.webBrowserForm.Close();
                this.webBrowserForm.Dispose();
            }

            // Create a new webbrowser form
            this.webBrowserForm = new UpdaterWebBrowserForm();

            // Use our webbrowser form to navigate to the link
            this.webBrowserForm.updaterWebBrowser.Navigate(link);

            // Apparently the browser is opening links to certain facebook pages with "#channel" in the url.
            // - Canceling the navigating event when the url contains "#channel" seems to work.
            // Create an event handler for the navigating event of the webbrowser
            WebBrowserNavigatingEventHandler navigatingHandler = null;
            navigatingHandler = (navigatingSnd, navigatingArgs) =>
            {
                // Check if the url contains "#channel"
                if (navigatingArgs.Url.AbsoluteUri.Contains("#channel"))
                {
                    // Cancel the navigating event
                    navigatingArgs.Cancel = true;
                }
            };

            // Bind the handler to the webbrowser
            this.webBrowserForm.updaterWebBrowser.Navigating += navigatingHandler;

            // Create an event handler for the document completed event of the webbrowser
            WebBrowserDocumentCompletedEventHandler completedHandler = null;
            completedHandler = (snd, args) =>
            {
                // Unsubscribe the event handler, otherwise the event will be fired around 5 times because of external scripts.
                this.webBrowserForm.updaterWebBrowser.DocumentCompleted -= completedHandler;

                // Customsforge website's document titles usually start with error if there's an error (404 for example).
                if (this.webBrowserForm.updaterWebBrowser.DocumentTitle.ToString().ToLower().StartsWith("error"))
                {
                    // Set the song's failed_update to 1
                    song.failed_update = 1;
                    song.Update();

                    // Call the update next song
                    this.songs.RemoveAt(0);
                    this.updateNextSong();
                    return;
                }
                else
                {
                    // Create an HTMLDocument object for the webpage, so we can begin searching for html parts
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

                    // Load the html from the updater webbrowser
                    htmlDocument.LoadHtml(this.webBrowserForm.updaterWebBrowser.Document.Body.OuterHtml);

                    // Create an HtmlNode object from the DocumentNode of this html document
                    HtmlNode documentNode = htmlDocument.DocumentNode;

                    // Some information about the html:
                    // - We're searching for a table with a class of "ipb_table"
                    // - Data is always in the second td of the tr
                    // - Instruments is the 9th tr of the table
                    // - Tuning is the 11th tr of the table
                    // - Song version is the 12th tr of the table
                    // - Custom tone is the 13th tr of the table
                    // - Dynamic Difficulty is the 14th tr of the table
                    // - Difficulty levels is the 15th tr of the table
                    // - Riff Repeater is the 16th tr of the table
                    // - Release notes is the 21st tr of the table
                    // - Download link is the 22nd tr of the table

                    // Catch exceptions. If an exception occurs, it probably means that we've navigated to a page without the song table.
                    try
                    {
                        // Retrieve instruments
                        string instruments = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(9) td:nth-child(2)").First<HtmlNode>().InnerText;
                        song.instruments = instruments;

                        // Retrieve tuning
                        string tuning = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(11) td:nth-child(2)").First<HtmlNode>().InnerText;
                        song.tuning = tuning;

                        // Retrieve custom tone
                        string customtone = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(13) td:nth-child(2)").First<HtmlNode>().InnerText;
                        if (customtone.ToLower() == "yes")
                        {
                            song.custom_tone = 1;
                        }
                        else
                        {
                            song.custom_tone = 0;
                        }

                        // Retrieve dynamic difficulty
                        string dynamic_difficulty = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(14) td:nth-child(2)").First<HtmlNode>().InnerText;
                        if (dynamic_difficulty.ToLower() == "yes")
                        {
                            song.dynamic_difficulty = 1;
                        }
                        else
                        {
                            song.dynamic_difficulty = 0;
                        }

                        // Retrieve difficulty levels
                        string difficulty_levels = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(15) td:nth-child(2)").First<HtmlNode>().InnerText;
                        int difficulty_levels_int = 0;
                        int.TryParse(difficulty_levels, out difficulty_levels_int);
                        song.difficulty_levels = difficulty_levels_int;

                        // Retrieve riff repeater
                        string riff_repeater = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(16) td:nth-child(2)").First<HtmlNode>().InnerText;
                        if (riff_repeater.ToLower() == "yes")
                        {
                            song.riff_repeater = 1;
                        }
                        else
                        {
                            song.riff_repeater = 0;
                        }

                        // Retrieve release notes
                        string release_notes = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(21) td:nth-child(2)").First<HtmlNode>().InnerHtml;
                        song.release_notes = release_notes;

                        // Retrieve the version of the song
                        string newVersion = documentNode.QuerySelectorAll("table.ipb_table tbody tr:nth-child(12) td:nth-child(2)").First<HtmlNode>().InnerText;

                        // Check if the version is different from the current version
                        if (song.current_version != newVersion)
                        {
                            // Set the song's new version to the new found version
                            song.new_version = newVersion;

                            // If the song has no customsforge id, try to get it now from the url
                            if (song.customsforge_id == 0)
                            {
                                string url = this.webBrowserForm.updaterWebBrowser.Url.AbsoluteUri;
                                int idPart = url.LastIndexOf("-r");
                                string songId = url.Substring(idPart + 2);
                                int newId = 0;

                                try
                                {
                                    Int32.TryParse(songId, out newId);
                                }
                                catch (Exception ex2){}

                                song.customsforge_id = newId;
                            }
                            
                            // Save the song id on the song object
                            song.Update();

                            // Call the update next song
                            this.songs.RemoveAt(0);
                            this.updateNextSong();
                            return;
                        }
                        else
                        {
                            // Set the song's uptodate to 1
                            song.uptodate = 1;
                            song.Update();

                            // Call the update next song
                            this.songs.RemoveAt(0);
                            this.updateNextSong();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Set the song's failed_update to 1
                        song.failed_update = 1;
                        song.Update();

                        // Call the update next song
                        this.songs.RemoveAt(0);
                        this.updateNextSong();
                        return;
                    }
                }
            };

            // Bind the handler to the document completed event of our updater webbrowser
            this.webBrowserForm.updaterWebBrowser.DocumentCompleted += completedHandler;
        }

        protected virtual void OnUpdatingFinished(EventArgs e)
        {
            EventHandler handler = UpdatingFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler UpdatingFinished;
    }
}
