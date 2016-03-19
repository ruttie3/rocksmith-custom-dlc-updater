using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using Rocksmith_Custom_DLC_Updater.Lib;
using Rocksmith_Custom_DLC_Updater.Helpers;
using Rocksmith_Custom_DLC_Updater.Models;
using Gecko;
using Gecko.DOM;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class SongSearcherForm : Form
    {
        // Searcher web browser form object
        public SearcherWebBrowserForm webBrowserForm;

        // List to hold all the songs
        public List<object> songs = new List<object>();

        // Integer to store the current song number
        public int currentSong = 0;

        // Integer to store the total number of songs
        public int totalSongs = 0;

        // GeckoDocument to hold the current document
        public GeckoDocument document = null;

        // GeckoInputElement to hold the search input
        public GeckoInputElement searchInput = null;

        // Bool whether to ask for the name of the song or not
        public bool askForSongName = true;

        public SongSearcherForm()
        {
            InitializeComponent();
        }

        public void StartSearching(List<object> songs = null)
        {
            // Check if the songs parameter is null
            if (songs == null)
            {
                Song baseSong = new Song();
                this.songs = baseSong.FindAll(new string[] { "hidden", "=", "0" }, "ORDER BY name");
            }
            else
            {
                this.songs = songs;
            }

            // Create a variable to keep track of the current song and a total of songs to search for
            this.currentSong = 0;
            this.totalSongs = this.songs.Count;

            // Check if total songs isn't 0
            if (this.totalSongs == 0)
            {
                MessageBox.Show("You don't have any songs to search for. Please check if you have custom songs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnSearchingFinished(EventArgs.Empty);
                this.Close();
                return;
            }

            // Set our progressbar
            this.searchingProgress.Maximum = this.totalSongs;

            // Create a new webbrowser form
            this.webBrowserForm = new SearcherWebBrowserForm();

            // Navigate to the ignition page of customsforge.
            this.webBrowserForm.searcherWebBrowser.Navigate("http://ignition.customsforge.com/");

            // Create an event handler for the document completed event of the gecko webbrowser
            EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs> documentCompletedHandler = null;
            documentCompletedHandler = (snd, args) =>
            {
                // Unsubscribe the handler
                this.webBrowserForm.searcherWebBrowser.DocumentCompleted -= documentCompletedHandler;

                // Check if this is the top level
                if (!args.IsTopLevel)
                {
                    return;
                }

                // Store the document
                this.document = this.webBrowserForm.searcherWebBrowser.Document;

                // Store the search input element
                this.searchInput = new GeckoInputElement(document.GetElementById("search_input").DomObject);

                // Create a timer of 1 second after which to start searching
                Timer changeValueInterval = new Timer();
                changeValueInterval.Interval = 1000;

                // Create an event handler for the timer's tick event
                EventHandler timerHandler = null;
                timerHandler = (tmrSnd, tmrArgs) =>
                {
                    // Stop the timer and unsubscribe this handler from the timer's tick event
                    changeValueInterval.Stop();
                    changeValueInterval.Tick -= timerHandler;

                    // Call SearchNextSong() to start searching
                    this.SearchNextSong();
                };

                // Subscribe the handler to the timer's tick event
                changeValueInterval.Tick += timerHandler;

                // Start the timer
                changeValueInterval.Start();
            };

            // Bind the event handler
            this.webBrowserForm.searcherWebBrowser.DocumentCompleted += documentCompletedHandler;
        }

        public void SearchNextSong()
        {
            // If there are no songs left to search, trigger the OnSearchingFinished event.
            if (this.songs.Count == 0)
            {
                OnSearchingFinished(EventArgs.Empty);
                this.Close();
                return;
            }

            // Increment current song number
            this.currentSong++;

            // Get the first song from the list
            Song song = (Song)this.songs[0];

            // Set the progress bar and status label
            this.searchingProgress.Value = this.currentSong;
            this.searchingLbl.Text = "Searching: " + song.name;

            // Create a string variable to store what to search for
            string searchFor = song.name;

            // Check if we should ask for the song name
            if (this.askForSongName)
            {
                // Create a dialog out of the search popup form
                SongSearchPopupForm searchDialog = new SongSearchPopupForm();
                searchDialog.searchTxt.Text = song.name;
                searchDialog.searchingForLbl.Text = "Searching for: " + song.name;

                // Check if the user pressed done
                if (searchDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Set searchfor to the dialog's textbox
                    searchFor = searchDialog.searchTxt.Text;

                    // Check if we have an ask again setting
                    Setting askagainSetting = new Setting();
                    askagainSetting.Find(new string[] { "name", "=", "ask_song_name" });
                    if (askagainSetting.value == null)
                    {
                        // Create a new setting
                        askagainSetting.name = "ask_song_name";
                        askagainSetting.value = "1";
                        askagainSetting.Insert();
                    }

                    // Check if the checkbox was set
                    if (searchDialog.askagainChk.Checked)
                    {
                        // Update the setting
                        askagainSetting.value = "0";
                        askagainSetting.Update();

                        // Set askforsongname to fals on our object
                        this.askForSongName = false;
                    }
                }
            }

            // Change the textbox' value
            this.searchInput.Value = searchFor;

            // Invoke the onchange event for the search input
            nsAStringBase eventType = (nsAStringBase)new nsAString("change");
            var ev = this.document.CreateEvent("HTMLEvents");
            ev.DomEvent.InitEvent(eventType, false, false);
            this.searchInput.GetEventTarget().DispatchEvent(ev);

            // Create a timer of 3 seconds after which to read through the data
            // - We need this timer of 3 seconds, otherwise the datatable might not be updated yet on the website.
            Timer updatedValueInterval = new Timer();
            updatedValueInterval.Interval = 3000;

            // Create an event handler for the timer's tick event
            EventHandler timerHandler = null;
            timerHandler = (tmrSnd, tmrArgs) =>
            {
                // Stop the timer and unsubscribe this handler from the timer's tick event
                updatedValueInterval.Stop();
                updatedValueInterval.Tick -= timerHandler;

                // Create an HTMLDocument object for the webpage, so we can begin searching for html parts
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

                // Load the html from the webbrowser
                htmlDocument.LoadHtml(this.document.Body.OuterHtml);

                // Create an HtmlNode object from the DocumentNode of this html document
                HtmlNode documentNode = htmlDocument.DocumentNode;

                // Get all table rows in the tbody of the #search_table table
                List<HtmlNode> tableRows = documentNode.QuerySelectorAll("table#search_table tbody tr").ToList<HtmlNode>();

                // Check if there are any rows
                if (tableRows.Count == 0)
                {
                    // Show a messagebox that nothing was found
                    if (MessageBox.Show("The song could not be found. Would you like to search again with a different name?", "No results", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Set ask for song name to true so that we show a popup asking for the song name
                        this.askForSongName = true;

                        // Decrement current song number
                        this.currentSong--;

                        // Search again
                        this.SearchNextSong();
                        return;
                    }

                    // Remove the song from the list and start searching the next song
                    this.songs.RemoveAt(0);
                    this.SearchNextSong();
                    return;
                }

                // Check if the first row's first td has a colspan, meaning there are no results
                HtmlNode firstRowTd = tableRows.First<HtmlNode>().QuerySelectorAll("td").First<HtmlNode>();
                if (firstRowTd.GetAttributeValue("colspan", "") != "")
                {
                    // Show a messagebox that nothing was found
                    if (MessageBox.Show("The song could not be found. Would you like to search again with a different name?", "No results", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Set ask for song name to true so that we show a popup asking for the song name
                        this.askForSongName = true;

                        // Decrement current song number
                        this.currentSong--;

                        // Search again
                        this.SearchNextSong();
                        return;
                    }

                    // Remove the song from the list and start searching the next song
                    this.songs.RemoveAt(0);
                    this.SearchNextSong();
                    return;
                }

                // Create a list for the search results
                List<SongSearchResult> results = new List<SongSearchResult>();

                // Loop through every row
                foreach (HtmlNode row in tableRows)
                {
                    // Create a new search result object
                    SongSearchResult result = new SongSearchResult();

                    // Get the id for this song
                    string id = row.QuerySelectorAll("td.add").First<HtmlNode>().Id;

                    // Check if we have an id
                    if (id == "")
                    {
                        // Skip this song, without an id we can't do anything.
                        continue;
                    }

                    // Set the id
                    result.id = id;

                    // Get all the standard text data
                    string artist = row.QuerySelectorAll("td.artist").First<HtmlNode>().InnerText;
                    result.artist = artist == "" ? "Unknown" : artist;

                    string title = row.QuerySelectorAll("td.title").First<HtmlNode>().InnerText;
                    result.title = title == "" ? "Unknown" : title;

                    string album = row.QuerySelectorAll("td.album").First<HtmlNode>().InnerText;
                    result.album = album == "" ? "Unknown" : album;

                    string tuning = row.QuerySelectorAll("td.tuning").First<HtmlNode>().InnerText;
                    result.tuning = tuning == "" ? "Unknown" : tuning;

                    string member = row.QuerySelectorAll("td.member").First<HtmlNode>().InnerText;
                    result.member = member == "" ? "Unknown" : member;

                    string updated = row.QuerySelectorAll("td.updated").First<HtmlNode>().InnerText;
                    result.updated = updated == "" ? "Unknown" : updated;

                    string downloads = row.QuerySelectorAll("td.downloads").First<HtmlNode>().InnerText;
                    result.downloads = downloads == "" ? "Unknown" : downloads;

                    // Get the parts for this song
                    HtmlNode partsTd = row.QuerySelectorAll("td.parts").First<HtmlNode>();
                    IEnumerable<HtmlNode> icons = partsTd.QuerySelectorAll("i.fa-circle");

                    // Loop through the icons
                    foreach (HtmlNode icon in icons)
                    {
                        // Get the parent span
                        HtmlNode parentSpan = icon.ParentNode;

                        // Check if the current part is active
                        bool isActive = false;
                        if (parentSpan.Attributes["class"].Value.IndexOf("inactive") == -1)
                        {
                            isActive = true;
                        }

                        // Check what part this is and set it to the value of isActive accordingly
                        if (icon.Attributes["class"].Value.IndexOf("lead") > -1)
                        {
                            result.lead = isActive;
                        }
                        else if (icon.Attributes["class"].Value.IndexOf("rhythm") > -1)
                        {
                            result.rhythm = isActive;
                        }
                        else if (icon.Attributes["class"].Value.IndexOf("bass") > -1)
                        {
                            result.bass = isActive;
                        }
                        else if (icon.Attributes["class"].Value.IndexOf("vocals") > -1)
                        {
                            result.vocals = isActive;
                        }
                    }

                    // Get the dynamic difficulty for this song
                    HtmlNode ddIcon = row.QuerySelectorAll("td.dd i.dd").First<HtmlNode>();

                    // Check if the icon has the inactive class
                    if (ddIcon.Attributes["class"].Value.IndexOf("inactive") == -1)
                    {
                        result.dd = true;
                    }

                    // Get the platforms for this song
                    HtmlNode platformsTd = row.QuerySelectorAll("td.platforms").First<HtmlNode>();
                    icons = platformsTd.QuerySelectorAll("i.fa-square");

                    // Loop through the icons
                    foreach (HtmlNode icon in icons)
                    {
                        // Get the parent span
                        HtmlNode parentSpan = icon.ParentNode;

                        // Check if the current platform is active
                        bool isActive = false;
                        if (parentSpan.Attributes["class"].Value.IndexOf("inactive") == -1)
                        {
                            isActive = true;
                        }

                        // Check what platform this is and set it to the value of isActive accordingly
                        if (icon.Attributes["class"].Value.IndexOf("pc") > -1)
                        {
                            result.pc = isActive;
                        }
                        else if (icon.Attributes["class"].Value.IndexOf("mac") > -1)
                        {
                            result.mac = isActive;
                        }
                        else if (icon.Attributes["class"].Value.IndexOf("xbox") > -1)
                        {
                            result.xbox = isActive;
                        }
                        else if (icon.Attributes["class"].Value.IndexOf("playstation") > -1)
                        {
                            result.playstation = isActive;
                        }
                    }

                    // Add the result to the list
                    results.Add(result);
                }

                // Show the search results dialog
                SearchResultsForm resultsDialog = new SearchResultsForm();
                resultsDialog.results = results;
                resultsDialog.searchedFor = this.searchInput.Value;
                System.Windows.Forms.DialogResult resultsDialogResult = resultsDialog.ShowDialog(this);

                // Check if the result of the dialog is OK
                if (resultsDialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    // Update the song's customsforge id
                    song.customsforge_id = SearchResultsForm.currentId;
                    song.Update();
                }
                // Check if the result of the dialog is retry
                else if (resultsDialogResult == System.Windows.Forms.DialogResult.Retry)
                {
                    // Set ask for song name to true so that we show a popup asking for the song name
                    this.askForSongName = true;

                    // Decrement current song number
                    this.currentSong--;

                    // Search again
                    this.SearchNextSong();
                    return;
                }

                // We dun
                this.songs.RemoveAt(0);
                this.SearchNextSong();
                return;
            };

            // Subscribe the handler to the timer's tick event
            updatedValueInterval.Tick += timerHandler;

            // Start the timer
            updatedValueInterval.Start();
        }

        protected virtual void OnSearchingFinished(EventArgs e)
        {
            EventHandler handler = SearchingFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler SearchingFinished;
    }
}
