namespace JMCMediaPLayer
{
    partial class JMCAudioPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JMCAudioPlayer));
            this.topPanel = new System.Windows.Forms.Panel();
            this.lbJMCMediaPlayer = new System.Windows.Forms.Label();
            this.LbxMusics = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroVolumBar = new MetroFramework.Controls.MetroTrackBar();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.PlaylistMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSavePlaylist = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnplay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnVolum = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            this.PlaylistMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.topPanel.Controls.Add(this.lbJMCMediaPlayer);
            this.topPanel.Controls.Add(this.btnCloseForm);
            resources.ApplyResources(this.topPanel, "topPanel");
            this.topPanel.Name = "topPanel";
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // lbJMCMediaPlayer
            // 
            resources.ApplyResources(this.lbJMCMediaPlayer, "lbJMCMediaPlayer");
            this.lbJMCMediaPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lbJMCMediaPlayer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbJMCMediaPlayer.Name = "lbJMCMediaPlayer";
            // 
            // LbxMusics
            // 
            this.LbxMusics.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LbxMusics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbxMusics.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.LbxMusics.FormattingEnabled = true;
            resources.ApplyResources(this.LbxMusics, "LbxMusics");
            this.LbxMusics.Name = "LbxMusics";
            this.LbxMusics.SelectedIndexChanged += new System.EventHandler(this.LbxMusics_SelectedIndexChanged);
            this.LbxMusics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbxMusics_MouseDoubleClick);
            this.LbxMusics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbxMusics_MouseDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Name = "label1";
            // 
            // TrackBar
            // 
            this.TrackBar.BackColor = System.Drawing.Color.Transparent;
            this.TrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrackBar.CustomBackground = true;
            resources.ApplyResources(this.TrackBar, "TrackBar");
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.SmallChange = 12;
            this.TrackBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TrackBar.Value = 0;
            this.TrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackBar_MouseDown);
            this.TrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBar_MouseUp);
            // 
            // axWindowsMediaPlayer
            // 
            resources.ApplyResources(this.axWindowsMediaPlayer, "axWindowsMediaPlayer");
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer_PlayStateChange);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ofd
            // 
            resources.ApplyResources(this.ofd, "ofd");
            this.ofd.Multiselect = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.metroVolumBar);
            this.panel1.Controls.Add(this.btnplay);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnVolum);
            this.panel1.Name = "panel1";
            // 
            // metroVolumBar
            // 
            this.metroVolumBar.BackColor = System.Drawing.Color.Black;
            this.metroVolumBar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.metroVolumBar, "metroVolumBar");
            this.metroVolumBar.Name = "metroVolumBar";
            this.metroVolumBar.SmallChange = 11;
            this.metroVolumBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.metroVolumBar, resources.GetString("metroVolumBar.ToolTip"));
            this.metroVolumBar.Value = 20;
            this.metroVolumBar.ValueChanged += new System.EventHandler(this.metroVolumBar_ValueChanged);
            // 
            // tbxSearch
            // 
            this.tbxSearch.BackColor = System.Drawing.Color.DimGray;
            this.tbxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSearch.ForeColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tbxSearch, "tbxSearch");
            this.tbxSearch.Name = "tbxSearch";
            this.toolTip.SetToolTip(this.tbxSearch, resources.GetString("tbxSearch.ToolTip"));
            this.tbxSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TbxSearch_MouseClick);
            // 
            // PlaylistMenuStrip
            // 
            this.PlaylistMenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PlaylistMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.PlaylistMenuStrip.Name = "PlaylistMenuStrip";
            resources.ApplyResources(this.PlaylistMenuStrip, "PlaylistMenuStrip");
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnSavePlaylist
            // 
            this.btnSavePlaylist.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnSavePlaylist, "btnSavePlaylist");
            this.btnSavePlaylist.FlatAppearance.BorderSize = 0;
            this.btnSavePlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSavePlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSavePlaylist.Name = "btnSavePlaylist";
            this.toolTip.SetToolTip(this.btnSavePlaylist, resources.GetString("btnSavePlaylist.ToolTip"));
            this.btnSavePlaylist.UseVisualStyleBackColor = false;
            this.btnSavePlaylist.Click += new System.EventHandler(this.btnSavePlaylist_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.Name = "btnSearch";
            this.toolTip.SetToolTip(this.btnSearch, resources.GetString("btnSearch.ToolTip"));
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrevious.Name = "btnPrevious";
            this.toolTip.SetToolTip(this.btnPrevious, resources.GetString("btnPrevious.ToolTip"));
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Name = "btnNext";
            this.toolTip.SetToolTip(this.btnNext, resources.GetString("btnNext.ToolTip"));
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnplay
            // 
            this.btnplay.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnplay, "btnplay");
            this.btnplay.FlatAppearance.BorderSize = 0;
            this.btnplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnplay.Name = "btnplay";
            this.toolTip.SetToolTip(this.btnplay, resources.GetString("btnplay.ToolTip"));
            this.btnplay.UseVisualStyleBackColor = false;
            this.btnplay.Click += new System.EventHandler(this.play_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = global::JMCMediaPLayer.Properties.Resources.stop;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStop.Name = "btnStop";
            this.toolTip.SetToolTip(this.btnStop, resources.GetString("btnStop.ToolTip"));
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnVolum
            // 
            resources.ApplyResources(this.btnVolum, "btnVolum");
            this.btnVolum.FlatAppearance.BorderSize = 0;
            this.btnVolum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVolum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVolum.Name = "btnVolum";
            this.toolTip.SetToolTip(this.btnVolum, resources.GetString("btnVolum.ToolTip"));
            this.btnVolum.UseVisualStyleBackColor = true;
            this.btnVolum.Click += new System.EventHandler(this.BtnVolum_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.btnCloseForm, "btnCloseForm");
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpen.Name = "btnOpen";
            this.toolTip.SetToolTip(this.btnOpen, resources.GetString("btnOpen.ToolTip"));
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // JMCAudioPlayer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ControlBox = false;
            this.Controls.Add(this.btnSavePlaylist);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.TrackBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.LbxMusics);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JMCAudioPlayer";
            this.Load += new System.EventHandler(this.JMCAudioPlayer_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PlaylistMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.ListBox LbxMusics;
        private System.Windows.Forms.Button btnVolum;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTrackBar TrackBar;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnplay;
        private MetroFramework.Controls.MetroTrackBar metroVolumBar;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbJMCMediaPlayer;
        private System.Windows.Forms.ContextMenuStrip PlaylistMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSavePlaylist;
    }
}

