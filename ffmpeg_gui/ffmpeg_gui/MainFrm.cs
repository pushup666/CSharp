using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ffmpeg_gui
{
    public partial class MainFrm : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();

        private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -map 0:1 -f wav - | neroaacenc -hev2 -q 0.25 -if - -ignorelength -of ""{0}\A_{2}.m4a""";
        private const string VideoFormat = @"x264 -o ""{0}\V_{2}.mkv"" ""{0}\{1}"" --ssim --tune ssim";
        private const string PackageFormat = @"ffmpeg -i ""{0}\V_{2}.mkv"" -i ""{0}\A_{2}.m4a"" -vcodec copy -acodec copy ""{0}\ENC_{2}.mp4""";

        private const string AllFormatLibx264 = @"ffmpeg -i ""{0}\{1}"" -vcodec libx264 -acodec aac -ac 2 ""{0}\{2}_libx264.mp4""";
        private const string AllFormatLibx265 = @"ffmpeg -i ""{0}\{1}"" -vcodec libx265 -acodec aac -ac 2 ""{0}\{2}_libx265.mp4""";

        private const string AllFormatH264NvEnc = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_nvenc -acodec aac -ac 2 ""{0}\{2}_h264_nvenc.mp4""";
        private const string AllFormatHevcNvEnc = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -acodec aac -ac 2 ""{0}\{2}_hevc_nvenc.mp4""";

        private const string AllFormatH264Qsv = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_qsv -acodec aac -ac 2 ""{0}\{2}_h264_qsv.mp4""";

        private const string AllFormatToMp4 = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -acodec copy ""{0}\{2}.mp4""";

        private const string SeparateAudioFormat = @"ffmpeg -i ""{0}\{1}"" -acodec copy -vn ""{0}\A_{2}.m4a""";
        private const string SeparateVideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -an ""{0}\V_{2}.mkv""";
        private const string SeparateSubtitleFormat = @"ffmpeg -i ""{0}\{1}"" -vn -an -scodec copy ""{0}\S_{2}.ass""";
        
        
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

        private void ButtonClearListClick(object sender, EventArgs e)
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

        private void buttonAll_Click(object sender, EventArgs e)
        {
            GenerateCmdLine(AllFormatToMp4);
            //GenerateCmdLine(AllFormatH264Qsv + "\n" + AllFormatLibx264 + "\n" + AllFormatLibx265 + "\n");
        }

        private void ButtonSeparateClick(object sender, EventArgs e)
        {
            //GenerateCmdLine(SeparateSubtitleFormat);
            GenerateCmdLine(SeparateAudioFormat + "\n" + SeparateVideoFormat + "\n");
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


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ssf.bat", richTextBoxOutput.Text.Trim().Replace("\n", "\r\n") + "\r\npause", Encoding.Default);
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}