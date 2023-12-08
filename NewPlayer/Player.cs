using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;

namespace NewPlayer
{
    class Player
    {
        /// <summary>
        /// List of all songs in current playlist
        /// </summary>
        private List<SongProperties> Playlist = new List<SongProperties>();
        /// <summary>
        /// list of all songsin current playlist, in a random/shuffled order
        /// </summary>
        private List<SongProperties> ShuffledPlaylist = new List<SongProperties>();
        /// <summary>
        /// list of all sweepers in current playlist
        /// </summary>
        private List<SongProperties> Sweepers = new List<SongProperties>();
        /// <summary>
        /// list of all folders in current playlist
        /// </summary>
        private List<string> SweepersFolder = new List<string>();
        /// <summary>
        /// Reader to read file from server
        /// </summary>
        private MediaFoundationReader mf;
        /// <summary>
        /// wave out event to play song from server
        /// </summary>
        private WaveOutEvent wo;
        /// <summary>
        /// keeps track of current location in playlist
        /// </summary>
        private int CurrentIndex = 0;
        /// <summary>
        /// keeps track of whether the payer is switching songs or actively playling
        /// </summary>
        private bool Switching = true;
        /// <summary>
        /// location to server; IP address
        /// </summary>
        private string ServerLocation;
        /// <summary>
        /// server controller used to read files from server location
        /// </summary>
        ServerController Controller;
        /// <summary>
        /// event handler that triggers when song changes
        /// </summary>
        public event EventHandler Changed;
        /// <summary>
        /// Format all Error Messages to look alike
        /// </summary>
        /// <param name="ErrorCode">Error Code, can be looked up at end of Form1.cs</param>
        /// <param name="LineNumber">LineNumber of where the error occured</param>
        private void ErrorMessage(Exception a, string ErrorCode, [CallerLineNumber] int LineNumber = 0)
        {
            try
            {
                showMessage(a.Message + "\n" +
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
        /// Asynchronous show messagebox
        /// </summary>
        private void showMessage(string Message) {
            var thread = new Thread(() =>
            {
                MessageBox.Show(Message);
            });
            thread.Start();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ServerLocation">location to the server</param>
        public Player(string ServerLocation) {
            try
            {
                this.ServerLocation = ServerLocation;
                wo = new WaveOutEvent();
                
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }

        }
        /// <summary>
        /// play/pause the current song
        /// if playing, pauise
        /// if paused, play
        /// </summary>
        public void PlayPause() {
            try
            {
                Switching = true;

                mf = new MediaFoundationReader(ShuffledPlaylist[CurrentIndex].URL);
                if (wo.PlaybackState == PlaybackState.Paused)
                {
                    wo.Play();
                    
                }
                else if (wo.PlaybackState == PlaybackState.Playing)
                {
                    wo.Pause();
                    
                }
                else
                {
                    wo.Init(mf);
                    wo.Play();
                    
                }
                Switching = false;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// play the next song in the playlist
        /// </summary>
        public void Next() {

            try
            {
                Switching = true;
                if ((CurrentIndex + 1) >= ShuffledPlaylist.Count)
                {
                    CurrentIndex = -1;
                    RefreshPlaylist();
                }
                wo.Stop();
                mf = new MediaFoundationReader(ShuffledPlaylist[++CurrentIndex].URL);
                wo.Init(mf);
                wo.Play();
                Switching = false;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception err)
            {
                Next();
            }
        }
        /// <summary>
        /// play the previous song in the playlist
        /// </summary>
        public void Previous() {
            try
            {
                Switching = true;
                wo.Stop();
                if ((CurrentIndex - 1) < 0) 
                    CurrentIndex = ShuffledPlaylist.Count() - 1;
                mf = new MediaFoundationReader(ShuffledPlaylist[--CurrentIndex].URL);
                wo.Init(mf);
                wo.Play();
                Switching = false;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// change current playlist
        /// this is called when user selects a new playlist to play
        /// </summary>
        /// <param name="Playlist"></param>
        public void setPlaylist(List<SongProperties> Playlist) {
            try
            {
                // Keep Current Playlist
                Switching = true;
                wo.Stop();
                this.Playlist = Playlist;

                // Refresh Playlist
                RefreshPlaylist();
                BurgInYourSpace.ShuffledPlaylist.Clear();
                BurgInYourSpace.ShuffledPlaylist = ShuffledPlaylist.ToList();
                if (ShuffledPlaylist.Count <= 0) {
                    showMessage("This Playlist is Empty (Or Doesn't Exist)... Please Select a Different Playlist");
                    return;
                }
                // Play First Index
                mf = new MediaFoundationReader(ShuffledPlaylist[CurrentIndex].URL);
                wo.Init(mf);
                wo.Play();
                Switching = false;
                Changed?.Invoke(this, EventArgs.Empty);
            }
            //catch (ArgumentOutOfRangeException err) { 
                // Index Out Of Range, No Songs in Playlist
            //}
            catch (Exception err)
            {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// gets all sweepers from server
        /// </summary>
        /// <param name="PlaylistLocation">swepers location</param>
        public void setSweepers(string PlaylistLocation) {
            try
            {
                Controller = new ServerController(ServerLocation +"/"+ PlaylistLocation);
                SweepersFolder = Controller.GetSweepersFolder();
                if (SweepersFolder.Count > 0) {
                    Sweepers = Controller.GetPlaylist(SweepersFolder[0]);
                }
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// Reset and Shuffle new Playlist
        /// </summary>
        private void RefreshPlaylist() {
            try
            {
                // Refreshing Playlist
                List<SongProperties> temp = Playlist.ToList();
                ShuffledPlaylist.Clear();

                int n = temp.Count;
                Random rand = new Random();
                while (n > 0)
                {
                    n--;
                    int k = rand.Next(n + 1);
                    ShuffledPlaylist.Add(temp[k]);
                    temp.RemoveAt(k);
                }
                AddSweepers();
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// Add sweepers to shuffled playlist
        /// </summary>
        private void AddSweepers() {
            try
            {
                int sourceindex = 0;
                int insertIndex = 0;
                int totalInsert = Sweepers.Count;
                int step = (int)Settings.sweeperFreq;
                List<SongProperties> temp = ShuffledPlaylist.ToList(); // We need a temp because you cannot modify list when using it in foreach statement
                SongProperties insertSong;
                foreach (SongProperties song in ShuffledPlaylist)
                {
                    // Every 'step' song
                    if (sourceindex % step == 0)
                    {
                        // Loop back to begining
                        if (insertIndex == totalInsert)
                            insertIndex = 0;
                        // insert song at index
                        insertSong = new SongProperties { Title = Sweepers[insertIndex].Title, URL = Sweepers[insertIndex++].URL };
                        temp.Insert(sourceindex++, insertSong);
                    }
                    sourceindex++;
                }
                // Clear and add playlist
                ShuffledPlaylist.Clear();
                foreach (SongProperties song in temp)
                {
                    ShuffledPlaylist.Add(song);
                }
            }
            catch (IndexOutOfRangeException err) { 
                // No sweepers or sweeper folder, skip and play playlist without sweepers
            }
            catch (Exception err)
            {
            }
        }
        /// <summary>
        /// Clear all lists as new ones have been selected
        /// </summary>
        public void ClearPlaylists() {
            try
            {
                CurrentIndex = 0;
                this.ShuffledPlaylist.Clear();
                this.SweepersFolder.Clear();
                this.Sweepers.Clear();
                this.Playlist.Clear();
            }
            catch (Exception err) {
                ErrorMessage(err, "1");
            }
        }
        /// <summary>
        /// get the index of the currently playing song
        /// </summary>
        /// <returns></returns>
        public int getCurrentIndex() {
            return this.CurrentIndex;
        }
        /// <summary>
        /// check if the player is currently playing
        /// </summary>
        /// <returns>true if playing, false if paused</returns>
        public bool isPlaying()
        {
            if (wo.PlaybackState == PlaybackState.Playing) return true;
            return false;
        }
        /// <summary>
        /// check if the player is currently paused
        /// </summary>
        /// <returns>true if paused, false if playing</returns>
        public bool isPaused()
        {
            if (wo.PlaybackState == PlaybackState.Paused) return true;
            return false;
        }
        /// <summary>
        /// check if the player is stopped
        /// </summary>
        /// <returns>true if stopped, false if playing/paused</returns>
        public bool isStopped()
        {
            if (wo.PlaybackState == PlaybackState.Stopped) return true;
            return false;
        }
        /// <summary>
        /// check if the player is switching songs
        /// </summary>
        /// <returns>true if switching, false if playing/pause/stopped</returns>
        public bool isSwitching()
        {
            return Switching;
        }
    }
}