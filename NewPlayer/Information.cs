using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Windows.Forms;
using SharpUpdate;

namespace NewPlayer
{
    public partial class Information : Form, ISharpUpdatable
    {
        /*
            Update Information
         */
        /// <summary>
        /// Stores a SharpUpdater object to update the application on request
        /// </summary>
        private SharpUpdater s;
        /// <summary>
        /// Stores XML location on server
        /// </summary>
        private Uri xmlLocation = new Uri("http://72.233.201.136/update/update.xml");
        /// <summary>
        /// Stores the Application name
        /// </summary>
        public string ApplicationName
        {
            get { return "881TheBurg"; }
        }
        /// <summary>
        /// Stores the application ID
        /// </summary>
        public string ApplicationId
        {
            get { return "881TheBurg"; }
        }
        /// <summary>
        /// Stores the Assembly Version
        /// </summary>
        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetEntryAssembly(); }
        }
        /// <summary>
        /// Stores the Icon of the pgoram
        /// </summary>
        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }
        /// <summary>
        /// Stores the update.xml location on Server
        /// </summary>
        public Uri UpdateXmlLocaion
        {
            get { return new Uri("http://72.233.201.136/update/update.xml"); }
        }
        /// <summary>
        /// Stores the form itself
        /// </summary>
        public Form Context
        {
            get { return this; }
        }
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
        /// Initializes Form Components
        /// </summary>
        public Information()
        {
            InitializeComponent();
            this.lbVersion.Text = "Version " + this.ApplicationAssembly.GetName().Version.ToString();
            s = new SharpUpdater(this);
        }
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
        /// <summary>
        /// Gets called when the Close button is pressed
        /// Closes the information form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Gets called the the Update button is pressed
        /// Check if a new version is available on the server
        /// If it is, update the proram
        /// </summary>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    //MessageBox.Show("Admin Privileges Required to Update");
                    //return;
                }
            }
            Console.WriteLine("Checking for update");
            s.DoUpdate();
        }
    }
}
