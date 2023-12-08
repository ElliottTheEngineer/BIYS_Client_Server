using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NewPlayer
{
    public partial class BurgInYourSpace : Form
    {
        /// <summary>
        /// Server Controller to Read files from server directory
        /// </summary>
        private ServerController Controller = new ServerController("http://72.233.201.136/Music");
        //private ServerController Controller = new ServerController("http://96.126.117.25/Music");
        /// <summary>
        /// Player to play songs that exists on remote server
        /// </summary>
        private Player player = new Player("http://72.233.201.136/Music");
        //private Player player = new Player("http://96.126.117.25/Music");
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
        /// Locations of all playlists on remote server
        /// </summary>
        private List<string> AllPlaylists = new List<string>();
        /// <summary>
        /// Stores all songs in a playlist in alphabetical order
        /// </summary>
        private List<SongProperties> Playlist = new List<SongProperties>();
        /// <summary>
        /// Stores all songs in a playlist in a random order
        /// gets refreshed every time the user completes the playlist
        /// </summary>
        public static List<SongProperties> ShuffledPlaylist = new List<SongProperties>();
        /// <summary>
        /// Format all Error Messages to look alike
        /// </summary>
        /// <param name="ErrorCode">Error Code, can be looked up at end of Form1.cs</param>
        /// <param name="LineNumber">LineNumber of where the error occured</param>
        private void ErrorMessage(Exception a, string ErrorCode, [CallerLineNumber] int LineNumber = 0)
        {
            try
            {
                MessageBox.Show(a.Message + "\n" +
                                "Error Code: " + ErrorCode + "\n" +
                                "Line: " + LineNumber +
                                a.ToString());
                player.Next();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Initialize Form Components
        /// Addes Song Chagned Event Listener
        /// </summary>
        public BurgInYourSpace()
        {
            InitializeComponent();
            player.Changed += ChangedEventHandler; // setup player change event - fired when the player changes songs
        }
        /// <summary>
        /// Gets called when form has finished loading
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AllPlaylists = Controller.GetAllPlaylists(); // gets all playlists created on server
                foreach (string Playlist in AllPlaylists) // foreach playlist in list
                {
                    PlaylistDropDown.Items.Add(Playlist); // add playlist to dropdown
                }
                PlaylistDropDown.SelectedIndex = 0; // selete first playlist in list

            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("Player Found No Playlists on Server, Shutting Down...");
                this.Close();
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
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
        /// This function gets called when the settings button is pressed.
        /// This function shows the settings page
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e) {
            
            FrmSettings settings = new FrmSettings();
            settings.Show(); // shows settings form
            if (settings.DialogResult == DialogResult.OK) // if result is OK
            {
                PlaylistDropDown.SelectedIndex = PlaylistDropDown.SelectedIndex; // settings have changed, refresh playlist
            }
            else if (settings.DialogResult == DialogResult.Cancel) { // if result is Cancel
                // settings have not been changed, continue playing
            }
        }
        /// <summary>
        /// This function gets called when the close button is pressed
        /// This function closes all open forms
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // close form
        }
        /// <summary>
        /// This function gets called when the 'Previous song' button is pressed
        /// This function plays the previous song in the playlist
        /// </summary>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                player.Previous(); // plays previous song in playlist
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// This functio gets called when the play/pause button is pressed
        /// This function plays/pauses the current song
        /// </summary>
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (player.isPlaying()) // if player is currently playling
                {
                    var bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject("play"); // get play image
                    btnPlayPause.Image = bmp; // update button image
                }
                else {
                    var bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject("pause"); // get pause image
                    btnPlayPause.Image = bmp; // update buttom image
                }
                player.PlayPause(); // handles play/pause
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// This function gets called when the 'Next song' button is pressed
        /// This function plays the next song in the playlist
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                player.Next(); // play next song in playlist
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /**************************
              Playlist changed
         **************************/
        /// <summary>
        /// When a new playlist is selected from the drop down this function updates the playlist
        /// and gets all the songs from the selected playlist
        /// </summary>
        private void PlaylistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                player.ClearPlaylists(); // clears all playlists (sweepers, songs, and shuffle)
                Playlist = Controller.GetPlaylist(PlaylistDropDown.SelectedItem.ToString()); // gets all songs from current playlist
                player.setSweepers(PlaylistDropDown.SelectedItem.ToString()); // add sweepers to player
                
                player.setPlaylist(Playlist); // add playlist to player
                
                if (!BackgroundLog.IsBusy) {
                    BackgroundLog.RunWorkerAsync();
                }
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /*****************************
             Update User Interface
         *****************************/
        /// <summary>
        /// Event Handler for when player switches song to
        /// Updates Title label on form
        /// </summary>
        public void ChangedEventHandler(object sender, EventArgs e)
        {
            try
            {
                
                // It must be done this way because this function is called from outside the UI thread preventing us from updating txtTitle
                this.txtTitle.BeginInvoke((MethodInvoker)delegate() {
                    // All code in here is ran asynchronously on the UI thread (the thread txtTitle was created on)
                    this.txtTitle.Text = ShuffledPlaylist[player.getCurrentIndex()].Title; 
                
                }); 
            }
            catch (Exception err)
            {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// Check when player finishes a song
        /// </summary>
        private void BackgroundLog_DoWork(object sender, DoWorkEventArgs e)
        {
            // player is playing, paused, or not stopped
            while (!player.isStopped() || player.isPaused() || player.isPlaying() || player.isSwitching())
            {
                if (this.BackgroundLog.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        /// <summary>
        /// After player finishes a song update the user interface
        /// </summary>
        private void BackgroundLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                BackgroundLog.RunWorkerAsync();
                return;
            }
            player.Next();
            BackgroundLog.RunWorkerAsync();
        }
    }
}
