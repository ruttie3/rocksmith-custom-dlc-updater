using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocksmith_Custom_DLC_Updater.Models;
using System.Data.SQLite;

namespace Rocksmith_Custom_DLC_Updater.Helpers
{
    static class ApplicationHelper
    {
        public static int InitializeApplication()
        {
            // Check if the database is set up properly
            if (!ApplicationHelper.CheckDatabase())
            {
                return 0;
            }

            // Initialize our SettingsHelper
            SettingsHelper.Initialize();

            // Check if we have a path set
            if (SettingsHelper.GetPath() == "")
            {
                return 1;
            }

            // Check if the path exists
            if (!Directory.Exists(SettingsHelper.GetPath()))
            {
                return 2;
            }

            return 3;
        }

        public static bool CheckDatabase()
        {
            // We need to check if the table for every model exists.
            // Wish I had a better way for this but haven't thought of one yet

            // Check if the database file exists
            if (!File.Exists("updater.sqlite") && !ApplicationHelper.CreateDatabase())
            {
                return false;
            }

            // Check the song table
            Song song = new Song();
            if (!song.TableExists())
            {
                song.CreateTable();
            }

            // Check the setting table
            Setting setting = new Setting();
            if (!setting.TableExists())
            {
                setting.CreateTable();
            }

            // Check if we succeeded creating the tables
            if (!song.TableExists() || !setting.TableExists())
            {
                return false;
            }

            return true;
        }

        public static bool CreateDatabase(bool overwrite = false)
        {
            // If the file exists and overwrite is true, delete the file
            if (File.Exists("updater.sqlite") && overwrite == true)
            {
                File.Delete("updater.sqlite");
            }

            // Create a new database file
            SQLiteConnection.CreateFile("updater.sqlite");

            // Couldn't be created. Probably need administrator rights
            if (!File.Exists("updater.sqlite"))
            {
                return false;
            }
            return true;
        }
    }
}
