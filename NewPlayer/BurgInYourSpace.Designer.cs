﻿namespace NewPlayer
{
    partial class BurgInYourSpace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BurgInYourSpace));
            this.txtTitle = new System.Windows.Forms.Label();
            this.PlaylistDropDown = new System.Windows.Forms.ComboBox();
            this.BackgroundLog = new System.ComponentModel.BackgroundWorker();
            this.btnClose = new ePOSOne.btnProduct.Button_WOC();
            this.btnSettings = new ePOSOne.btnProduct.Button_WOC();
            this.btnPlayPause = new ePOSOne.btnProduct.Button_WOC();
            this.circularPicture1 = new _881TheBurg.CircularPicture();
            this.btnNext = new ePOSOne.btnProduct.Button_WOC();
            this.btnPrevious = new ePOSOne.btnProduct.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.circularPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(15, 275);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(213, 31);
            this.txtTitle.TabIndex = 17;
            this.txtTitle.Text = "{Title}";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlaylistDropDown
            // 
            this.PlaylistDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaylistDropDown.FormattingEnabled = true;
            this.PlaylistDropDown.Location = new System.Drawing.Point(12, 30);
            this.PlaylistDropDown.Name = "PlaylistDropDown";
            this.PlaylistDropDown.Size = new System.Drawing.Size(216, 21);
            this.PlaylistDropDown.TabIndex = 19;
            this.PlaylistDropDown.SelectedIndexChanged += new System.EventHandler(this.PlaylistDropDown_SelectedIndexChanged);
            // 
            // BackgroundLog
            // 
            this.BackgroundLog.WorkerReportsProgress = true;
            this.BackgroundLog.WorkerSupportsCancellation = true;
            this.BackgroundLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundLog_DoWork);
            this.BackgroundLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundLog_RunWorkerCompleted);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.BorderColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Image = global::NewPlayer.Properties.Resources.power;
            this.btnClose.Location = new System.Drawing.Point(206, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnClose.OnHoverButtonColor = System.Drawing.Color.Transparent;
            this.btnClose.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 21;
            this.btnClose.TextColor = System.Drawing.Color.Transparent;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.BorderColor = System.Drawing.Color.Transparent;
            this.btnSettings.ButtonColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.Image = global::NewPlayer.Properties.Resources.Settings;
            this.btnSettings.Location = new System.Drawing.Point(9, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSettings.OnHoverButtonColor = System.Drawing.Color.Transparent;
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnSettings.Size = new System.Drawing.Size(20, 20);
            this.btnSettings.TabIndex = 20;
            this.btnSettings.TextColor = System.Drawing.Color.Transparent;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlayPause.BorderColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.ButtonColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlayPause.Image = global::NewPlayer.Properties.Resources.pause;
            this.btnPlayPause.Location = new System.Drawing.Point(100, 262);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.OnHoverButtonColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.Size = new System.Drawing.Size(40, 40);
            this.btnPlayPause.TabIndex = 16;
            this.btnPlayPause.TextColor = System.Drawing.Color.Transparent;
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // circularPicture1
            // 
            this.circularPicture1.BackgroundImage = global::NewPlayer.Properties.Resources.Default;
            this.circularPicture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.circularPicture1.Location = new System.Drawing.Point(12, 42);
            this.circularPicture1.Name = "circularPicture1";
            this.circularPicture1.Size = new System.Drawing.Size(216, 176);
            this.circularPicture1.TabIndex = 15;
            this.circularPicture1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.BorderColor = System.Drawing.Color.Transparent;
            this.btnNext.ButtonColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Image = global::NewPlayer.Properties.Resources.chevron_right;
            this.btnNext.Location = new System.Drawing.Point(188, 262);
            this.btnNext.Name = "btnNext";
            this.btnNext.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnNext.OnHoverButtonColor = System.Drawing.Color.Transparent;
            this.btnNext.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 14;
            this.btnNext.TextColor = System.Drawing.Color.Transparent;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrevious.BorderColor = System.Drawing.Color.Transparent;
            this.btnPrevious.ButtonColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrevious.Image = global::NewPlayer.Properties.Resources.chevron_left;
            this.btnPrevious.Location = new System.Drawing.Point(12, 262);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnPrevious.OnHoverButtonColor = System.Drawing.Color.Transparent;
            this.btnPrevious.OnHoverTextColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Size = new System.Drawing.Size(40, 40);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.TextColor = System.Drawing.Color.Transparent;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // BurgInYourSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(240, 315);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.PlaylistDropDown);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.circularPicture1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BurgInYourSpace";
            this.Text = "Burg In Your Space";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.circularPicture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ePOSOne.btnProduct.Button_WOC btnPrevious;
        private ePOSOne.btnProduct.Button_WOC btnNext;
        private _881TheBurg.CircularPicture circularPicture1;
        private ePOSOne.btnProduct.Button_WOC btnPlayPause;
        private System.Windows.Forms.ComboBox PlaylistDropDown;
        private ePOSOne.btnProduct.Button_WOC btnSettings;
        private ePOSOne.btnProduct.Button_WOC btnClose;
        public System.Windows.Forms.Label txtTitle;
        private System.ComponentModel.BackgroundWorker BackgroundLog;
    }
}

