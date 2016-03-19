using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocksmith_Custom_DLC_Updater.Models
{
    public class SongSearchResult
    {
        public string id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string album { get; set; }
        public string tuning { get; set; }
        public string member { get; set; }
        public string updated { get; set; }
        public string downloads { get; set; }
        public bool lead { get; set; }
        public bool rhythm { get; set; }
        public bool bass { get; set; }
        public bool vocals { get; set; }
        public bool dd { get; set; }
        public bool pc { get; set; }
        public bool mac { get; set; }
        public bool xbox { get; set; }
        public bool playstation { get; set; }

        public SongSearchResult()
        {
            this.lead = false;
            this.rhythm = false;
            this.bass = false;
            this.vocals = false;
            this.dd = false;
            this.pc = false;
            this.mac = false;
            this.xbox = false;
            this.playstation = false;
        }
    }
}
