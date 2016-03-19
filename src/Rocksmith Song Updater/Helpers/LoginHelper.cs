using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocksmith_Custom_DLC_Updater.Helpers
{
    static class LoginHelper
    {
        // LoginForm object
        private static LoginForm loginForm;

        public static bool DoLogin()
        {
            // Ask the user if they want to log in
            System.Windows.Forms.DialogResult askLogin = MessageBox.Show("It's necessary to log into your customsforge account. Want to do so now? Please tick the 'remember me' checkbox.", "Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            // Check if the user pressed yes
            if (askLogin == System.Windows.Forms.DialogResult.Yes)
            {
                // Check if we already have a login form
                if (LoginHelper.loginForm == null || LoginHelper.loginForm.IsDisposed)
                {
                    LoginHelper.loginForm = new LoginForm();
                }

                // Show the login form
                FormHelper.BringToFront(LoginHelper.loginForm);

                // Start the login process on the form
                LoginHelper.loginForm.StartLogin();

                // Create a variable telling us the user has logged in or not
                bool didLogIn = false;

                // Create a delegate event handler for the logged in event (see LoginForm.cs)
                LoginHelper.loginForm.LoggedIn += delegate(object sender, EventArgs e)
                {
                    // The user has loggedin. Set the logged in setting to 1
                    SettingsHelper.SetLoggedIn(true);

                    // Close the form
                    LoginHelper.loginForm.Close();
            
                    // Set didLogin to true
                    didLogIn = true;
                };

                // Check if we logged in. If so, return true
                if (didLogIn)
                {
                    return true;
                }
            }
            else
            {
                // User doesn't want to log in
                MessageBox.Show("Without logging in you will not be able to update your songs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
