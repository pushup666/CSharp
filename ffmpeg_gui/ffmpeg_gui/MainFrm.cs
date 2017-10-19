﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ffmpeg_gui
{
    public partial class MainFrm : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();

        private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -map 0:1 -f wav - | neroaacenc -q 0.25 -if - -ignorelength -of ""{0}\A_{2}.m4a""";
        private const string VideoFormat = @"x264 -o ""{0}\V_{2}.mkv"" ""{0}\{1}"" --ssim --tune ssim";
        private const string PackageFormat = @"ffmpeg -i ""{0}\V_{2}.mkv"" -i ""{0}\A_{2}.m4a"" -vcodec copy -acodec copy ""{0}\ENC_{2}.mp4""";
        private const string SeparateVideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -an ""{0}\V_{2}.mkv""";
        private const string SeparateAudioFormat = @"ffmpeg -i ""{0}\{1}"" -acodec copy -vn ""{0}\A_{2}.m4a""";
        
        public MainFrm()
        {
            InitializeComponent();
        }

        private void ButtonAddFileClick(object sender, EventArgs e)
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
                                _files.Add(fileName, true);
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

        private void ButtonAddFolderClick(object sender, EventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var fileName in Directory.GetFiles(folderBrowserDialog.SelectedPath))
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

                RefreshFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshFileList()
        {
            checkedListBoxFileName.Items.Clear();
            foreach (var file in _files)
            {
                checkedListBoxFileName.Items.Add(file.Key, file.Value);
            }
        }

        

        private void ButtonClearListClick(object sender, EventArgs e)
        {
            _files.Clear();
            RefreshFileList();
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
            GenerateCmdLine(SeparateVideoFormat);
            GenerateCmdLine(SeparateAudioFormat);
        }

        private void GenerateCmdLine(string format)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (string item in checkedListBoxFileName.CheckedItems)
                {
                    var directoryName = Path.GetDirectoryName(item);
                    var fileName = Path.GetFileName(item);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);

                    sb.AppendLine(string.Format(format, directoryName, fileName, fileNameWithoutExtension));
                }

                richTextBoxOutput.Text += sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
