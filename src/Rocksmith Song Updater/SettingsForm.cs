using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rocksmith_Custom_DLC_Updater.Lib;
using Rocksmith_Custom_DLC_Updater.Models;
using Rocksmith_Custom_DLC_Updater.Helpers;

namespace Rocksmith_Custom_DLC_Updater
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Set the checkboxes to their values
            this.renameChk.Checked = SettingsHelper.GetAlwaysRename();
            this.deleteChk.Checked = SettingsHelper.GetAlwaysDelete();
            this.dontasksongChk.Checked = SettingsHelper.GetDontAskForSongName();
            this.dlcDir.Text = "Rocksmith DLC directory: \n" + SettingsHelper.GetPath().ToString();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            // Show an about message
            MessageBox.Show("This application is created by Rutger Speksnijder. Version: 1.0. Contact: rutgerspeksnijder@hotmail.com.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            // Show the path dialog
            if (pathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Update the path with the selected path
                SettingsHelper.SetPath(pathDialog.SelectedPath);
                this.dlcDir.Text = "Rocksmith DLC directory: \n" + pathDialog.SelectedPath;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Start the login process
            LoginHelper.DoLogin();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            // Show the user instructions on how to reset the application
            MessageBox.Show("To reset the application, close the application and delete the updater.sqlite file in the application's directory. Then start the application again.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void hiddensongsBtn_Click(object sender, EventArgs e)
        {
            // Show the hidden songs form
            FormHelper.ShowHiddenSongsForm();
        }

        private void renameChk_CheckedChanged(object sender, EventArgs e)
        {
            // Change the setting
            SettingsHelper.SetAlwaysRename(this.renameChk.Checked);
        }

        private void deleteChk_CheckedChanged(object sender, EventArgs e)
        {
            // Change the setting
            SettingsHelper.SetAlwaysDelete(this.deleteChk.Checked);
        }

        private void dontasksongChk_CheckedChanged(object sender, EventArgs e)
        {
            // Change the setting
            SettingsHelper.SetDontAskForSongName(this.dontasksongChk.Checked);
        }
    }
}
