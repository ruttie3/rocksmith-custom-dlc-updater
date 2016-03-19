using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Rocksmith_Custom_DLC_Updater.Lib;

namespace Rocksmith_Custom_DLC_Updater.Models
{
    public class Song : Model
    {
        new public string table = "songs";
        new public string[] tableColumns = { "id INTEGER PRIMARY KEY, name VARCHAR(255), customsforge_id INT, last_searched TEXT, current_version TEXT, new_version TEXT, uptodate INT, failed_update INT, found INT, hidden INT, instruments TEXT, tuning TEXT, custom_tone INT, dynamic_difficulty INT, difficulty_levels INT, riff_repeater INT, release_notes TEXT" };

        public long id { get; set; }
        public string name { get; set; }
        public int customsforge_id { get; set; }
        public string last_searched { get; set; }
        public string current_version { get; set; }
        public string new_version { get; set; }
        public int uptodate { get; set; }
        public int failed_update { get; set; }
        public int found { get; set; }
        public int hidden { get; set; }
        public string instruments { get; set; }
        public string tuning { get; set; }
        public int custom_tone { get; set; }
        public int dynamic_difficulty { get; set; }
        public int difficulty_levels { get; set; }
        public int riff_repeater { get; set; }
        public string release_notes { get; set; }
        
        public static void SetFoundZero()
        {
            string sql = "UPDATE songs SET found = 0";
            SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
            command.ExecuteNonQuery();
        }

        public static int RemoveFoundZero()
        {
            string sql = "DELETE FROM songs WHERE found = 0";
            SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
            return command.ExecuteNonQuery();
        }

        public static void UnhideAllSongs()
        {
            string sql = "UPDATE songs SET hidden = 0";
            SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
            command.ExecuteNonQuery();
        }
    }
}
