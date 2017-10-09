using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ffmpeg_gui
{
    public partial class MainFrm : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();
        private const string AudioFormat = "ffmpeg -i \"{0}\\{1}\" -ac 2 -map 0:1 -f wav - | neroaacenc -q 0.25 -if - -ignorelength -of \"{0}\\A_{2}.m4a\"\r\n";
        private const string VideoFormat = "x264 --crf 30 --demuxer lavf -o \"{0}\\V_{2}.mkv\" \"{0}\\{1}\"\r\n";
        private const string PackageFormat = "ffmpeg -i \"{0}\\V_{2}.mkv\" -i \"{0}\\A_{2}.m4a\" -vcodec copy -acodec copy \"{0}\\ENC_{2}.mkv\"\r\n";
        //private const string PackageFormat = "ffmpeg -i \"{0}\\V_{2}.mkv\" -itsoffset 1.196 -i \"{0}\\A_{2}.m4a\" -vcodec copy -acodec copy \"{0}\\ENC_{2}.mkv\"\r\n";
        private const string SeparateFormat = "ffmpeg -i \"{0}\\{1}\" -vcodec copy -an \"{0}\\V_{2}.mkv\"\r\nffmpeg -i \"{0}\\{1}\" -acodec copy -vn \"{0}\\A_{2}.m4a\"\r\n";

        //ffmpeg -i \"{0}\\V_{2}.mkv\" -itsoffset -0.578 -i \"{0}\\A_{2}.m4a\" -vcodec copy -acodec copy \"{0}\\ENC_{2}.mkv\"
        public MainFrm()
        {
            InitializeComponent();
        }

        private void ButtonAddFileClick(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            foreach (var fileName in openFileDialog.FileNames)
                            {
                                _files.Add(fileName, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(openFileDialog.FileName + ex.Message);
                        }
                    }
                }

                ShowFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowFileList()
        {
            checkedListBoxFileName.Items.Clear();
            foreach (var file in _files)
            {
                checkedListBoxFileName.Items.Add(file.Key, file.Value);
            }
        }

        private void ButtonAddFolderClick(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in Directory.GetFiles(folderBrowserDialog.SelectedPath))
                        {
                            try
                            {
                                _files.Add(fileName, true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(fileName + ex.Message);
                            }
                        }
                    }
                }

                ShowFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClearListClick(object sender, EventArgs e)
        {
            _files.Clear();
            ShowFileList();
        }

        private void ButtonAudioClick(object sender, EventArgs e)
        {
            GenerateCmdLine(AudioFormat);
        }

        private void ButtonVideoClick(object sender, EventArgs e)
        {
            GenerateCmdLine(VideoFormat);
        }

        private void ButtonPackageClick(object sender, EventArgs e)
        {
            GenerateCmdLine(PackageFormat);
        }

        private void ButtonSeparateClick(object sender, EventArgs e)
        {
            GenerateCmdLine(SeparateFormat);
        }
        private void GenerateCmdLine(string format)
        {
            try
            {
                string result = "";
                foreach (string item in checkedListBoxFileName.CheckedItems)
                {
                    string directoryName = Path.GetDirectoryName(item);
                    string fileName = Path.GetFileName(item);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);

                    result += string.Format(format, directoryName, fileName, fileNameWithoutExtension);
                }

                textBoxOutput.Text += result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
