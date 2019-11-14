using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;


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
                                if (!_files.Contains(fileName))
                                {
                                    _files.Add(fileName);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(openFileDialog.FileName + ex.Message);
                        }
                    }
                }

                RefreshTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClearList_Click(object sender, EventArgs e)
        {
            _files.Clear();
            RefreshTextBox();
        }

        private void RefreshTextBox()
        {
            var sb = new StringBuilder();
            foreach (var file in _files)
            {
                sb.AppendLine(file);
            }
            richTextBoxFileList.Text = sb.ToString().TrimEnd();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                Hide();
            }
        }

        private void NotifyIconNew_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Show();
        }


        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_files.Count > 0)
            {
                var fileName = _files[0];
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

                _files.Remove(fileName);
                RefreshTextBox();

                notifyIcon.Text = fileNameWithoutExt;
                Record(fileNameWithoutExt);
                Play(fileName);
            }
            else
            {
                MessageBox.Show("看完了！");
            }
        }

        private static void Play(string filename)
        {
            try
            {
                var p = new Process();

                p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\111\";
                p.StartInfo.FileName = "2021";

                p.StartInfo.Arguments = $"\"{filename}\"";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }


        private static void Record(string fileNameWithoutExt)
        {
            try
            {
                var p = new Process();

                p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                p.StartInfo.FileName = "ffmpeg";

                p.StartInfo.Arguments = $"-f dshow -i video=\"screen-capture-recorder\":audio=\"virtual-audio-capturer\" -vcodec h264_qsv -acodec aac -ac 2 \"{fileNameWithoutExt}.mkv\"";
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
