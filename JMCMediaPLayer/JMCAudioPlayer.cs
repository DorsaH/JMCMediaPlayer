using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JMCMediaPLayer
{
    public partial class JMCAudioPlayer : Form
    {
        Database database = new Database();
        //properties for dragging the form without borders
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        //property for selected index method
        private string currentFilePath;

        int initialVolum;

        //temperory list to save the media files while the form is running
        BindingList<MediaFile> mediaFiles = new BindingList<MediaFile>();
        //doubly linked list for media paths
        LinkedList<string> linkedMediafilePaths = new LinkedList<string>();
       

        //index for pointing at an element in the mediafiles list and playlist list box
        public int listboxindex = 0;

        public JMCAudioPlayer()
        {
            InitializeComponent();
          
        }

        //Method to find a media file in the list and send out the object and index in the list
        public MediaFile GetMediaFile(string targetMediaPath, out int mediaFileIndex)
        {
            object file = mediaFiles.FirstOrDefault(m => m.Path == targetMediaPath);
            int index = mediaFiles.IndexOf((MediaFile)file); 
            if (file == null)
            {
                mediaFileIndex = 0;
                return null;
            }
            else
            {
                mediaFileIndex = index;
                return (MediaFile)file;
            }
        }

        //method to linear search for a media in the list
        public int SearchMedia(string name)
        {
            int index;
            
            for( index = 0 ; index < mediaFiles.Count ; index++)
            {
                if(mediaFiles[index].FileName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return index;
                }        
            }
            return -1;
        }

        //Insertion sort method
        public static BindingList<MediaFile> InsertionSort(BindingList<MediaFile> list)
        {
            for (int i = 1; i <= list.Count - 1; i++)
            {
                string compareValue = list[i].FileName;
                int comparePointer = i - 1;
                MediaFile temp = list[i];

                while (comparePointer >= 0 && String.CompareOrdinal(list[comparePointer].FileName , compareValue)>=0)
                {
                    
                    list[comparePointer + 1] = list[comparePointer];
                    comparePointer = comparePointer - 1;
                }
                list[comparePointer + 1] = temp;

            }
            return list;
        }

        //Method to populate the mediapaths linked list 
        public void populatelinkedMediafilePaths()
        {
            linkedMediafilePaths.Clear();
            foreach(MediaFile media in mediaFiles)
            {
                linkedMediafilePaths.AddLast(media.Path);
            }
        }

        //Method to read the Playlist text file
        public void ReadPlaylistFile()
        {
            try
            {

                TextReader reader = new StreamReader(@"Playlist.txt");
                string[] seperator = new string[] { ",," };
                // string array for file name and file path
                string[] mediaInfoArray;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    MediaFile tempMedia = new MediaFile();
                    mediaInfoArray = line.Split(seperator, StringSplitOptions.None);
                    tempMedia.FileName = mediaInfoArray[0];
                    tempMedia.Path = mediaInfoArray[1];
                    mediaFiles.Add(tempMedia);

                }
                populatelinkedMediafilePaths();
            }
            catch
            {
                MessageBox.Show("Could not load the playlist!");
            }
        }

        #region Form Methods
        //Method for loading the form
        private void JMCAudioPlayer_Load(object sender, EventArgs e)
        {
            LbxMusics.ValueMember = "Path";
            LbxMusics.DisplayMember = "FileName";
            if (database.Connect() != true)
            {
                MessageBox.Show("Could not connect to the server!");
            }
            TrackBar.Value = 0;
            ReadPlaylistFile();
            LbxMusics.DataSource = mediaFiles;
            
        }

        //Exit button to close the form
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    //Methods for moving the form by mouse
        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
       

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        //Method to open media files
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //   using (ofd = new OpenFileDialog() {Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv" })
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                foreach (string fileName in ofd.FileNames)
                {
                    FileInfo fi = new FileInfo(fileName);
                    MediaFile newMediaFile = new MediaFile(Path.GetFileNameWithoutExtension(fi.FullName), fi.FullName);
                    if (GetMediaFile(newMediaFile.Path, out listboxindex) == null)
                    {
                        //adding the files to the list with file name and the path
                        mediaFiles.Add(new MediaFile(Path.GetFileNameWithoutExtension(fi.FullName), fi.FullName)); 
                        mediaFiles =InsertionSort(mediaFiles);
                        populatelinkedMediafilePaths();
                    }
                    else
                    {
                        MessageBox.Show("Media file " + newMediaFile.FileName + " alredy exist in the playlist");
                    }
                }
            }
            
            LbxMusics.DataSource = mediaFiles;
            LbxMusics.Update();

        }
        //method gets the index of the selectedfile in the list 
        private void LbxMusics_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile selectedFile = LbxMusics.SelectedItem as MediaFile;
            if (selectedFile != null)
            {
                GetMediaFile(selectedFile.Path, out listboxindex);
                

                LinkedListNode<string> selectedMedia = linkedMediafilePaths.Find(selectedFile.Path);
                if(selectedMedia != null)
                currentFilePath = selectedMedia.Value;

            }
        }
        //Method for play Button Click
        private void play_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer.Ctlcontrols.play();  
            }
            else if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                axWindowsMediaPlayer.URL = currentFilePath;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else if(axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsUndefined )
            {
                axWindowsMediaPlayer.URL = currentFilePath;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else 
            {
                axWindowsMediaPlayer.Ctlcontrols.pause();
            }
            
        }
        //Method to stop the media
        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        //double clicking on an Item in the listbox will play the song
        private void LbxMusics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MediaFile selectedFile = LbxMusics.SelectedItem as MediaFile;
            if (selectedFile != null && selectedFile.Path != axWindowsMediaPlayer.URL)
            {
                axWindowsMediaPlayer.URL = selectedFile.Path;
                axWindowsMediaPlayer.Ctlcontrols.play();
                
            }
        }

        //Methods to allow the user to change the position of the media duration
        private void TrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
        }

        private void TrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            axWindowsMediaPlayer.Ctlcontrols.currentPosition = TrackBar.Value;
        }

        //media player control's playstate change event handler
        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                TrackBar.Maximum = (int)axWindowsMediaPlayer.Ctlcontrols.currentItem.duration;
                timer.Start();
                btnplay.BackgroundImage = Properties.Resources.pause;
                toolTip.SetToolTip(btnplay, "Pause");
            }
            else if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer.Stop();
                btnplay.BackgroundImage = Properties.Resources.play;
                toolTip.SetToolTip(btnplay, "Play");
            }
            else if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer.Stop();
                TrackBar.Value = 0;
                btnplay.BackgroundImage = Properties.Resources.play;
                toolTip.SetToolTip(btnplay, "Play");
            }
        }
        //Method to synchronize the trackbar with mediaplayer control 
        private void timer_Tick(object sender, EventArgs e)
        {
            TrackBar.Value = (int)axWindowsMediaPlayer.Ctlcontrols.currentPosition;
        }
        

        //Method to play the next media in the list
        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentFilePath = axWindowsMediaPlayer.URL;
            LinkedListNode<string> nextMedia = linkedMediafilePaths.Find(currentFilePath).Next;
            if (nextMedia == null)
                MessageBox.Show("End of list!");
            else
            {
                axWindowsMediaPlayer.URL = nextMedia.Value;
                GetMediaFile(nextMedia.Value, out listboxindex);
                axWindowsMediaPlayer.Ctlcontrols.play();
                LbxMusics.SetSelected(listboxindex, true);
            }
        }

        //Method to play the previous media in the list
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentFilePath = axWindowsMediaPlayer.URL;
            LinkedListNode<string> previousMedia = linkedMediafilePaths.Find(currentFilePath).Previous;
            if (previousMedia == null)
                MessageBox.Show("There is no previous media!");
            else
            {
                axWindowsMediaPlayer.URL = previousMedia.Value;
                GetMediaFile(previousMedia.Value, out listboxindex);
                axWindowsMediaPlayer.Ctlcontrols.play();
                LbxMusics.SetSelected(listboxindex, true);
            }
        }

        //Method for changing the volum of the media
        private void metroVolumBar_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.settings.volume = metroVolumBar.Value;
            if (metroVolumBar.Value != 0)
            {
                initialVolum = metroVolumBar.Value;
                btnVolum.BackgroundImage = Properties.Resources.voice;
            }
        }
        //Method to mute and unmute the media
        private void BtnVolum_Click(object sender, EventArgs e)
        {
            if (!axWindowsMediaPlayer.settings.mute)
            {
                metroVolumBar.Value = 0;
                btnVolum.BackgroundImage = Properties.Resources.mute;
                axWindowsMediaPlayer.settings.mute = true;  
            }
            else
            {
                axWindowsMediaPlayer.settings.mute = false;
                btnVolum.BackgroundImage = Properties.Resources.voice;
                metroVolumBar.Value = initialVolum;
            }
        }

        //  Method to remove the text in the search text box once client clicks 
        private void TbxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbxSearch.Text.Equals("Enter a media name to search"))
            {
                tbxSearch.Clear();
            }
        }

        //Search button method to search for a media in the list
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxSearch.Text)|| tbxSearch.Text == "Enter a media name to search")
                MessageBox.Show("Enter a name to search");
            else
            {
                string targetMedia = tbxSearch.Text;
                int index = SearchMedia(targetMedia);
                if (index >= 0)
                {
                    listboxindex = index;
                    LbxMusics.SetSelected(listboxindex, true);
                    tbxSearch.Clear();
                }
                else
                {
                    MessageBox.Show("Media not found.");
                }
            }
        }



        #endregion
        //Method to delete a media from playlist by rigth clicking and choosing delete
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaFile selectedFile = LbxMusics.SelectedItem as MediaFile;
            if (selectedFile != null)
            {
                //gets the index of the file in the list
                GetMediaFile(selectedFile.Path, out listboxindex);
                //finds the node containing the target media to delete
                LinkedListNode<string> selectedMedia = linkedMediafilePaths.Find(selectedFile.Path);
                mediaFiles.RemoveAt(listboxindex);
                linkedMediafilePaths.Remove(selectedMedia);
                mediaFiles = InsertionSort(mediaFiles);
                populatelinkedMediafilePaths();

            }
            else
            {
                deleteToolStripMenuItem.Enabled = false;
            }
        }

        //Method to check if user rigth clicks on an item in the listbox
        private void LbxMusics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //gets the index of the right clicked item
                listboxindex = LbxMusics.IndexFromPoint(e.Location);
                {
                    if (listboxindex != -1)
                    {
                        LbxMusics.SetSelected(listboxindex, true);
                        PlaylistMenuStrip.Show(LbxMusics,e.Location);
                    }
                }
            }
        }

        //Method to save the playlist
        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            try
            {
                if (mediaFiles != null)
                {
                    StreamWriter sw = File.CreateText("Playlist.txt");
                    foreach (MediaFile media in mediaFiles)
                    {
                        sw.WriteLine(media.FileName + ",," + media.Path);
                    }
                    sw.Dispose();
                    sw.Close();
                    MessageBox.Show("Playlist was saved succesfully.");
                }
                else
                {
                    MessageBox.Show("Playlist is empty!");
                }
            }
            catch
            {
                MessageBox.Show("Playlist could not be saved! Please try again");
            }
        }
    }//end of class
}//end of namespace
