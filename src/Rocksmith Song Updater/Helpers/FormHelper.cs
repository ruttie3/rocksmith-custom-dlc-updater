using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocksmith_Custom_DLC_Updater.Helpers
{
    static class FormHelper
    {
        // ReleaseNotesForm object
        private static ReleaseNotesForm releaseNotesForm;

        // SettingsForm object
        private static SettingsForm settingsForm;

        // HiddenSongsForm object
        private static HiddenSongsForm hiddenSongsForm;

        // Command used to unminimize a window
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_RESTORE = 0xF120;

        // Import the user32.dll to make use of the sendmessage function
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static void BringToFront(Form theForm)
        {
            // Show, activate and bring the form to the front
            theForm.Show();
            theForm.Activate();
            theForm.BringToFront();

            // Send the SC_RESTORE message to the form handle to try and unminimize it (if it's been minimized)
            SendMessage(theForm.Handle, WM_SYSCOMMAND, SC_RESTORE, 0);
        }

        public static void ShowReleaseNotesForm(string name = "unknown", string releaseNotes = "")
        {
            // Shows a new instance of the release notes form if it hasn't been created yet. Otherwise it will show the current release notes form.
            if (FormHelper.releaseNotesForm == null || FormHelper.releaseNotesForm.IsDisposed)
            {
                FormHelper.releaseNotesForm = new ReleaseNotesForm();
            }
            FormHelper.releaseNotesForm.Text = name + " release notes";
            FormHelper.releaseNotesForm.releasenotesBrowser.DocumentText = releaseNotes;
            FormHelper.BringToFront(FormHelper.releaseNotesForm);
        }

        public static void ShowSettingsForm()
        {
            // Shows a new instance of the settings form if it hasn't been created yet. Otherwise it will show the current settings form.
            if (FormHelper.settingsForm == null || FormHelper.settingsForm.IsDisposed)
            {
                FormHelper.settingsForm = new SettingsForm();
            }
            FormHelper.BringToFront(FormHelper.settingsForm);
        }

        public static void ShowHiddenSongsForm()
        {
            // Shows a new instance of the hidden songs form if it hasn't been created yet. Otherwise it will show the current hidden songs form.
            if (FormHelper.hiddenSongsForm == null || FormHelper.hiddenSongsForm.IsDisposed)
            {
                FormHelper.hiddenSongsForm = new HiddenSongsForm();
            }
            FormHelper.hiddenSongsForm.LoadList();
            FormHelper.BringToFront(FormHelper.hiddenSongsForm);
        }
    }
}
