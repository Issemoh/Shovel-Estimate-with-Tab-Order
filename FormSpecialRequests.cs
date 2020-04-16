using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snow_Shovel_Estimate
{
    public partial class FormSpecialRequests : Form
    {
        private bool saved = false; // has the user saved their changes?

        public FormSpecialRequests()
        {
            InitializeComponent();
        }

        private void FormSpecialRequests_Load(object sender, EventArgs e)
        {
            txtRequests.Text = Tag.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Store the user's special requests in this from's Tag property
            // The form thatcreated this form will be able to access the data
            Tag = txtRequests.Text;
            // set the saved boolean, when the form is closed, we'll know the data is saved
            saved = true;
            // Indicate the user successfully interacted with this form
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); // Initiate from close process
        }

        private void frmSpecialRequests_Close(object sender, FormClosingEventArgs e)
        {
            bool userMadeChanges = Tag.ToString() != txtRequests.Text;

            //if not saved, and has user made changes, confirm they do
            // want to close this window and lose their changes
            if (!saved && userMadeChanges)
            {
                DialogResult closeResult = MessageBox.Show("Your changes are not saved, close anyway?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (closeResult == DialogResult.No)
                {
                    e.Cancel = true; //prevent from closing 
                }
            }
            // if changes are saved, or user has not made changes,
            // let close event proceed to close the form
        }
    }
}
