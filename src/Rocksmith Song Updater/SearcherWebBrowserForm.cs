using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;
using Gecko.DOM;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class SearcherWebBrowserForm : Form
    {
        public SearcherWebBrowserForm()
        {
            InitializeComponent();

            // Initialize the gecko xpcom component
            Gecko.Xpcom.Initialize("xulrunner");
        }
    }
}
