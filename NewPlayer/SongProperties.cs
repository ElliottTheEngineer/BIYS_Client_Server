using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlayer
{
    /// <summary>
    /// Stores metadata of songs
    /// </summary>
    public class SongProperties
    {
        /// <summary>
        /// Get and set the Title of a song
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Get and set the index value of a song in a playlist
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// Get and set the file location of a song to the server
        /// </summary>
        public string URL { get; set; }
    }
}
