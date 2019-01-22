using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private void buttonRead_Click(object sender, EventArgs e)
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
                    var dstFileNameWithoutExtension = GetVideoCreationTime(GetVideoInfo(item));

                    sb.AppendLine(string.Format(format, directoryName, srcFileNameWithoutExtension, dstFileExtension, dstFileNameWithoutExtension));
                }
                richTextBoxOutput.Text += sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetVideoInfo(string videoName)
        {
            var result = "";
            try
            {
                var p = new Process();

                p.StartInfo.WorkingDirectory = @"D:\Codecs\BIN";
                p.StartInfo.FileName = "ffprobe.exe";
                p.StartInfo.Arguments = $"-i {videoName} -loglevel quiet -print_format flat -show_format";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;

                p.Start();

                result = p.StandardOutput.ReadToEnd();

                p.WaitForExit();
                p.Close();

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return result;
            }
        }

        private string GetVideoCreationTime(string videoInfo)
        {
            var result = "";

            try
            {
                foreach (var line in videoInfo.Split(Environment.NewLine.ToCharArray()))
                {
                    if (line.StartsWith("format.tags.creation_time"))
                    {
                        result = line.Replace("format.tags.creation_time=", "").Replace("\"", "");
                    }
                }
                var dt = DateTime.Parse(result);

                return dt.ToString("yyyyMMdd_HHmmss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
                return result;
            }
        }
    }
}
