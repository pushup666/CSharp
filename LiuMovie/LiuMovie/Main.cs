using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace LiuMovie
{
    public partial class Main : Form
    {
        private readonly List<string> _files = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void ButtonAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            foreach (var fileName in openFileDialog.FileNames)
                            {
                                checkedListBoxFileName.Items.Add(fileName, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(openFileDialog.FileName + ex.Message);
                        }
                    }
                }

                RefreshFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClearList_Click(object sender, EventArgs e)
        {
            checkedListBoxFileName.Items.Clear();
            RefreshFileList();
        }

        private void RefreshFileList()
        {
            _files.Clear();
            foreach (string file in checkedListBoxFileName.CheckedItems)
            {
                _files.Add(file);
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIconNew.Visible = true;
                Hide();
            }
        }

        private void NotifyIconNew_DoubleClick(object sender, EventArgs e)
        {
            notifyIconNew.Visible = false;
            Show();
        }


        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_files.Count > 0)
            {
                var fileName = _files[0];
                _files.Remove(fileName);
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

                notifyIconNew.Text = fileNameWithoutExt;
                Record(fileNameWithoutExt);
                Play(fileName);
            }
        }

        private static void Play(string filename)
        {
            try
            {
                var p = new Process();

                p.StartInfo.WorkingDirectory = @"C:\Program Files\DAUM\PotPlayer";
                p.StartInfo.FileName = "PotPlayerMini64";

                p.StartInfo.Arguments = $"\"{filename}\"";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }


        private static void Record(string filename)
        {
            try
            {
                var p = new Process();

                p.StartInfo.WorkingDirectory = @"C:\Users\ssf\Desktop";
                p.StartInfo.FileName = "ffmpeg";

                p.StartInfo.Arguments = $"-f dshow -i video=\"screen-capture-recorder\":audio=\"virtual-audio-capturer\" -vcodec h264_qsv -acodec aac -ac 2 \"{filename}.mkv\"";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }
    }
}
