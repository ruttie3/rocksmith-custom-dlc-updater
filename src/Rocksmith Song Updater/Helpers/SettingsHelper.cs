using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocksmith_Custom_DLC_Updater.Models;

namespace Rocksmith_Custom_DLC_Updater.Helpers
{
    static class SettingsHelper
    {
        // Initialized
        private static bool initialized = false;

        // LoggedIn setting
        private static Setting loggedIn = new Setting();

        // Path setting
        private static Setting path = new Setting();

        // Always rename setting
        private static Setting alwaysRename = new Setting();

        // Always delete setting
        private static Setting alwaysDelete = new Setting();

        // Dont ask for song name setting
        private static Setting dontAskForSongName = new Setting();

        // Disclaimer setting
        private static Setting disclaimer = new Setting();

        public static void Initialize()
        {
            // Initialize logged in setting
            SettingsHelper.loggedIn.Find(new string[] { "name", "=", "logged_in" });
            if (SettingsHelper.loggedIn.value == null)
            {
                SettingsHelper.loggedIn.name = "logged_in";
                SettingsHelper.loggedIn.value = "0";
                SettingsHelper.loggedIn.Insert();
            }

            // Initialize path setting
            SettingsHelper.path.Find(new string[] { "name", "=", "path" });
            if (SettingsHelper.path.value == null)
            {
                SettingsHelper.path.name = "path";
                SettingsHelper.path.value = "";
                SettingsHelper.path.Insert();
            }

            // Initialize the always rename setting
            SettingsHelper.alwaysRename.Find(new string[] { "name", "=", "always_rename" });
            if (SettingsHelper.alwaysRename.value == null)
            {
                SettingsHelper.alwaysRename.name = "always_rename";
                SettingsHelper.alwaysRename.value = "0";
                SettingsHelper.alwaysRename.Insert();
            }

            // Initialize the always delete setting
            SettingsHelper.alwaysDelete.Find(new string[] { "name", "=", "always_delete" });
            if (SettingsHelper.alwaysDelete.value == null)
            {
                SettingsHelper.alwaysDelete.name = "always_delete";
                SettingsHelper.alwaysDelete.value = "0";
                SettingsHelper.alwaysDelete.Insert();
            }

            // Initialize the dont ask for song name setting
            SettingsHelper.dontAskForSongName.Find(new string[] { "name", "=", "dont_ask_for_song_name" });
            if (SettingsHelper.dontAskForSongName.value == null)
            {
                SettingsHelper.dontAskForSongName.name = "dont_ask_for_song_name";
                SettingsHelper.dontAskForSongName.value = "0";
                SettingsHelper.dontAskForSongName.Insert();
            }

            // Initialize the disclaimer setting
            SettingsHelper.disclaimer.Find(new string[] { "name", "=", "disclaimer" });
            if (SettingsHelper.disclaimer.value == null)
            {
                SettingsHelper.disclaimer.name = "disclaimer";
                SettingsHelper.disclaimer.value = "1";
                SettingsHelper.disclaimer.Insert();
            }

            // Set initialized to true
            SettingsHelper.initialized = true;
        }

        public static void SetLoggedIn(bool state)
        {
            // Update the setting
            string newvalue = "1";
            if (!state)
            {
                newvalue = "0";
            }
            SettingsHelper.loggedIn.value = newvalue;
            SettingsHelper.loggedIn.Update();
        }

        public static bool GetLoggedIn()
        {
            // Return true if the setting's value is 1, false otherwise
            if (SettingsHelper.loggedIn.value == "1")
            {
                return true;
            }
            return false;
        }

        public static void SetPath(string value)
        {
            // Update the setting
            SettingsHelper.path.value = value;
            SettingsHelper.path.Update();
        }

        public static string GetPath()
        {
            // Return the path
            return SettingsHelper.path.value;
        }

        public static void SetAlwaysRename(bool state)
        {
            // Update the setting
            string newvalue = "1";
            if (!state)
            {
                newvalue = "0";
            }
            SettingsHelper.alwaysRename.value = newvalue;
            SettingsHelper.alwaysRename.Update();
        }

        public static bool GetAlwaysRename()
        {
            // Return true if the setting's value is 1, false otherwise
            if (SettingsHelper.alwaysRename.value == "1")
            {
                return true;
            }
            return false;
        }

        public static void SetAlwaysDelete(bool state)
        {
            // Update the setting
            string newvalue = "1";
            if (!state)
            {
                newvalue = "0";
            }
            SettingsHelper.alwaysDelete.value = newvalue;
            SettingsHelper.alwaysDelete.Update();
        }

        public static bool GetAlwaysDelete()
        {
            // Return true if the setting's value is 1, false otherwise
            if (SettingsHelper.alwaysDelete.value == "1")
            {
                return true;
            }
            return false;
        }

        public static void SetDontAskForSongName(bool state)
        {
            // Update the setting
            string newvalue = "1";
            if (!state)
            {
                newvalue = "0";
            }
            SettingsHelper.dontAskForSongName.value = newvalue;
            SettingsHelper.dontAskForSongName.Update();
        }

        public static bool GetDontAskForSongName()
        {
            // Return true if the setting's value is 1, false otherwise
            if (SettingsHelper.dontAskForSongName.value == "1")
            {
                return true;
            }
            return false;
        }

        public static void SetDisclaimer(bool state)
        {
            // Update the setting
            string newvalue = "0";
            if (state)
            {
                newvalue = "1";
            }
            SettingsHelper.disclaimer.value = newvalue;
            SettingsHelper.disclaimer.Update();
        }

        public static bool GetDisclaimer()
        {
            // Return true if the setting's value is 1, false otherwise
            if (SettingsHelper.disclaimer.value == "1")
            {
                return true;
            }
            return false;
        }
    }
}
