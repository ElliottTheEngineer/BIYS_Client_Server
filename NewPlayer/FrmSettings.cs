using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NewPlayer
{
    public partial class FrmSettings : Form
    {
        /// <summary>
        /// This is used to keep track of if the user has saved any changes
        /// </summary>
        private bool saved = false;
        /// <summary>
        /// Keeps track of whether or not the user is pressing down on the application
        /// used to move the form when user presses down
        /// </summary>
        private bool mouseDown;
        /// <summary>
        /// Keeps track of the last position the form was in.
        /// used to move the form when user presses down
        /// </summary>
        private Point lastLocation;
        /// <summary>
        /// Format all Error Messages to look alike
        /// </summary>
        /// <param name="ErrorCode">Error Code, can be looked up at end of Form1.cs</param>
        /// <param name="LineNumber">LineNumber of where the error occured</param>
        public void ErrorMessage(Exception a, string ErrorCode, [CallerLineNumber] int LineNumber = 0)
        {
            try
            {

                MessageBox.Show(a.Message + "\n" +
                                "Error Code: " + ErrorCode + "\n" +
                                "Line: " + LineNumber +
                                a.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmSettings()
        {
            InitializeComponent();
            numFreq.Value = Settings.sweeperFreq; // gets current settings
        }
        /*************************
               Drag and Drop
         *************************/
        /// <summary>
        /// When User presses down with the mouse on the form, this function keeps track of the mouse location and moves the form
        /// </summary>
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                mouseDown = true;// Mouse is pressed down: start moving form
                lastLocation = e.Location; // get location of mouse
            }
            catch (Exception a)
            {
                ErrorMessage(a, "480 \nCould Not Move Window");
            }
        }
        /// <summary>
        /// When User lifts up with the mouse on the form, this function tells the program to stop moving the form
        /// </summary>
        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                mouseDown = false;// Mouse is no longer pressed down: stop moving form
            }
            catch (Exception a)
            {
                ErrorMessage(a, "480 \nCould Not Move Window");
            }
        }
        /// <summary>
        /// When User presses down with the mouse on the form, this function keeps track of the mouse location and moves the form
        /// </summary>
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mouseDown) // Mouse is pressed down: when mouse starts moving
                {

                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);// set new location of mouse

                    this.Update();// Moves form locatio to mouse location
                }
            }
            catch (Exception a)
            {
                ErrorMessage(a, "480 \nCould Not Move Window");
            }
        }
        /***********************
                 Buttons
        ************************/
        /// <summary>
        /// Closes the form
        /// Asks user if they'd like to save changes
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!saved) { // if user has not saved the application
                DialogResult result = MessageBox.Show("Exit Without Saving?", "Wait", MessageBoxButtons.YesNo); // ask user if they wish to exit without saving
                if (result == DialogResult.Yes) // if yes
                {
                    this.DialogResult = DialogResult.Cancel; // exit without saving
                }
                else // if no
                {
                    Settings.sweeperFreq = numFreq.Value; // save value
                    this.DialogResult = DialogResult.OK; // exit
                }
            }
            this.Close(); // close current form
        }
        /// <summary>
        /// Saves Settings to static class
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.sweeperFreq = numFreq.Value; // save value
            MessageBox.Show("Saved!"); // display message to user
            saved = true; // update saved value
            this.DialogResult = DialogResult.OK; // update dialog result so main form knows what to do when settings is closed
        }
        /// <summary>
        /// Shows Information Form
        /// </summary>
        private void btnInfo_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.Show(); // shows information form
        }
        /***********************
             Settings Changed
        ************************/
        /// <summary>
        /// Settings have been changed, update saved bool
        /// </summary>
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            saved = false;
        }
        /// <summary>
        /// Settings have been changed, update saved bool
        /// </summary>
        private void numFreq_Click(object sender, EventArgs e)
        {
            saved = false;
        }
        
    }
}
