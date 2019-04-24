﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace ReadVideoInfo
{
    public partial class ReadVideoInfo : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();

        public ReadVideoInfo()
        {
            InitializeComponent();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
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

        private void buttonAddFolder_Click(object sender, EventArgs e)
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

        private void buttonClearList_Click(object sender, EventArgs e)
        {
            _files.Clear();
            RefreshFileList();
            richTextBoxOutput.Text = "";
        }

        private void RefreshFileList()
        {
            checkedListBoxFileName.Items.Clear();
            foreach (var file in _files)
            {
                checkedListBoxFileName.Items.Add(file.Key, file.Value);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ssf.bat", richTextBoxOutput.Text.Trim().Replace("\n", "\r\n"), Encoding.Default);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReadVideoCreationTime_Click(object sender, EventArgs e)
        {
            try
            {
                const string format = @"ren ""{0}\{1}{2}"" ""{3}{2}""";
                var sb = new StringBuilder();

                foreach (string item in checkedListBoxFileName.CheckedItems)
                {
                    var directoryName = Path.GetDirectoryName(item);
                    var dstFileExtension = Path.GetExtension(item);

                    var srcFileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);
                    var dstFileNameWithoutExtension = GetVideoCreationTime(item);

                    if (srcFileNameWithoutExtension == dstFileNameWithoutExtension)
                    {
                        continue;
                    }

                    sb.AppendLine(string.Format(format, directoryName, srcFileNameWithoutExtension, dstFileExtension, dstFileNameWithoutExtension));
                }

                richTextBoxOutput.Text += sb.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonAutoBitrate_Click(object sender, EventArgs e)
        {
            var IsSaveToRam = true;
            const string format = @"{5}ffmpeg -i ""{0}\{1}"" -b:v {4}K -vcodec hevc_nvenc -acodec aac -ac 2 -q:a 0.7 ""{2}\{3}_hevc_nvenc.mp4""";
            //const string format = @"{5}ffmpeg -i ""{0}\{1}"" -b:v {4}K -vcodec h264_qsv -acodec aac -ac 2 -q:a 0.7 ""{2}\{3}_h264_qsv.mp4""";

            try
            {
                var sb = new StringBuilder();

                foreach (string item in checkedListBoxFileName.CheckedItems)
                {
                    var srcDirectoryName = Path.GetDirectoryName(item);
                    var dstDirectoryName = IsSaveToRam ? "Z:" : srcDirectoryName;
                    var srcFileName = Path.GetFileName(item);
                    var dstFileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);

                    var dstFileAutoBitrate = GetVideoAutoBitrate(item);
                    var duration = GetVideoDuration(item);

                    var srcSize = ((double)GetVideoSize(item) / 1024 / 1024).ToString("F2");
                    var dstSize = ((double)(dstFileAutoBitrate + 70) / 8 * duration / 1024).ToString("F2");

                    var convertFlag = double.Parse(dstSize) > 0 && double.Parse(dstSize) < double.Parse(srcSize) / 1.5;

                    sb.AppendLine($"rem Src:{srcSize}M    Dst:{dstSize}M");
                    //sb.Append($"{srcSize}\t{dstSize}\t\t");
                    sb.AppendLine(string.Format(format, srcDirectoryName, srcFileName, dstDirectoryName, dstFileNameWithoutExtension, dstFileAutoBitrate, convertFlag ? "" : "rem "));
                }

                richTextBoxOutput.Text += sb.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private static string GetVideoInfo(string videoName, string selectStreams, string showEntries, string arg)
        {
            var result = "";
            var select_streams = selectStreams == "" ? "" : $"-select_streams {selectStreams} ";
            try
            {
                var p = new Process();

                //p.StartInfo.WorkingDirectory = @"F:\Softs\Media\Codecs\BIN";
                p.StartInfo.FileName = "ffprobe.exe";
                p.StartInfo.Arguments = $"-i \"{videoName}\" -loglevel error -print_format default=noprint_wrappers=1:nokey=1 {select_streams}-show_entries {showEntries}={arg} ";
                p.StartInfo.CreateNoWindow = true;
                //p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;

                p.Start();

                result = p.StandardOutput.ReadToEnd();

                p.WaitForExit();
                p.Close();

                return result.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return result;
            }
        }

        private static string GetVideoCreationTime(string fileName)
        {
            try
            {
                var result = GetVideoInfo(fileName, "", "format_tags", "com.apple.quicktime.creationdate");

                if (result == "")
                {
                    result = GetVideoInfo(fileName, "", "format_tags", "creation_time");
                }

                var dt = DateTime.Parse(result);

                return dt.ToString("yyyyMMdd_HHmmss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(fileName + "\r\n" + ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return "";
            }
        }

        private static long GetVideoSize(string fileName)
        {
            try
            {
                var size = GetVideoInfo(fileName, "", "format", "size");
                return long.Parse(size);
            }
            catch (Exception ex)
            {
                MessageBox.Show(fileName + "\r\n" + ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return 0;
            }
        }

        private static double GetVideoDuration(string fileName)
        {
            try
            {
                var duration = GetVideoInfo(fileName, "", "format", "duration");
                return double.Parse(duration);
            }
            catch (Exception ex)
            {
                MessageBox.Show(fileName + "\r\n" + ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return 0;
            }
        }

        private static int GetVideoAutoBitrate(string fileName)
        {
            try
            {
                var width = GetVideoInfo(fileName, "v:0", "stream", "width");
                var height = GetVideoInfo(fileName, "v:0", "stream", "height");
                var r_frame_rate = GetVideoInfo(fileName, "v:0", "stream", "r_frame_rate").Split('/');
                
                var fps = double.Parse(r_frame_rate[0])/double.Parse(r_frame_rate[1]);
                var dstVideoBitrate = int.Parse(width) * int.Parse(height) * fps / 20;
                
                return (int)dstVideoBitrate / 1024;
            }
            catch (Exception ex)
            {
                MessageBox.Show(fileName + "\r\n" + ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return 0;
            }
        }
    }
}
