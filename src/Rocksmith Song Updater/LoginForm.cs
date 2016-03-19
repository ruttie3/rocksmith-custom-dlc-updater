using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void StartLogin()
        {
            this.webBrowser.Navigate("http://customsforge.com/index.php");
        }

        protected virtual void OnLoggedIn(EventArgs e)
        {
            EventHandler handler = LoggedIn;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler LoggedIn;

        private void btnLoginDone_Click(object sender, EventArgs e)
        {
            OnLoggedIn(EventArgs.Empty);
        }
    }
}
