using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocksmith_Custom_DLC_Updater.Lib;

namespace Rocksmith_Custom_DLC_Updater.Models
{
    public class Setting : Model
    {
        new public string table = "settings";
        new public string[] tableColumns = { "id INTEGER PRIMARY KEY, name VARCHAR(255), value VARCHAR(255)" };

        public long id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
