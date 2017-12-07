using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ffmpeg_gui
{
    public partial class MainFrm : Form
    {
        private const bool IsSaveToRam = true;
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();

        
        private const string VideoFormat = @"x264 -o ""{2}\V_{3}.mkv"" ""{0}\{1}"" --ssim --tune ssim";
        //private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -an ""{2}\V_{3}.mkv""";     //2000 Kbps/s
        //private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_qsv   -an ""{2}\V_{3}.mkv""";     //1000 Kbps/s

        private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -f wav - | neroaacenc -q 0.3 -if - -ignorelength -of ""{2}\A_{3}.mp4""";           // 81 Kbps/s        59x
        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -f wav - | neroaacenc -q 0.4 -if - -ignorelength -of ""{2}\A_{3}.mp4""";         // 120 Kbps/s       55x
        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -f wav - | neroaacenc -q 0.5 -if - -ignorelength -of ""{2}\A_{3}.mp4""";         // 168 Kbps/s       52x
        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -vn -acodec aac -ac 2 ""{2}\A_{3}.mp4""";                                              // 130 Kbps/s       36x

        private const string PackageFormat = @"ffmpeg -i ""{2}\V_{3}.mkv"" -i ""{2}\A_{3}.mp4"" -vcodec copy -acodec copy ""{2}\{3}_ENC.mp4""";


        //private const string AllFormatLibx264   = @"ffmpeg -i ""{0}\{1}"" -vcodec libx264    -acodec aac -ac 2 ""{2}\{3}_libx264.mp4""";
        //private const string AllFormatLibx265   = @"ffmpeg -i ""{0}\{1}"" -vcodec libx265    -acodec aac -ac 2 ""{2}\{3}_libx265.mp4""";
        //private const string AllFormatH264NvEnc = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_nvenc -acodec aac -ac 2 ""{2}\{3}_h264_nvenc.mp4""";
        private const string AllFormatHevcNvEnc = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -acodec aac -ac 2 ""{2}\{3}_hevc_nvenc.mp4""";
        private const string AllFormatH264Qsv   = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_qsv   -acodec aac -ac 2 ""{2}\{3}_h264_qsv.mp4""";

        private const string AllFormatToMp4 = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -acodec copy ""{2}\{3}.mp4""";


        private const string SeparateAudioFormat    = @"ffmpeg -i ""{0}\{1}"" -acodec copy -vn     ""{2}\A_{3}.m4a""";
        private const string SeparateVideoFormat    = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -an     ""{2}\V_{3}.mkv""";
        private const string SeparateSubtitleFormat = @"ffmpeg -i ""{0}\{1}"" -vn -an -scodec copy ""{2}\S_{3}.ass""";

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


        private void ButtonVideoClick(object sender, EventArgs e)
        {
            GenerateCmdLine(VideoFormat);
        }

        private void ButtonAudioClick(object sender, EventArgs e)
        {
            GenerateCmdLine(AudioFormat);
        }

        private void ButtonPackageClick(object sender, EventArgs e)
        {
            GenerateCmdLine(PackageFormat);
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {

            GenerateCmdLine(AllFormatH264Qsv);
            //GenerateCmdLine(AudioFormat + "\n" + VideoFormat + "\n" + PackageFormat + "\n");
        }

        private void ButtonSeparateClick(object sender, EventArgs e)
        {
            GenerateCmdLine(SeparateAudioFormat);
        }

        private void GenerateCmdLine(string format)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (string item in checkedListBoxFileName.CheckedItems)
                {
                    var srcDirectoryName = Path.GetDirectoryName(item);
                    var dstDirectoryName = IsSaveToRam ? "Z:" : srcDirectoryName;
                    var srcFileName = Path.GetFileName(item);
                    var dstFileNameWithoutExtension = Path.GetFileNameWithoutExtension(item);

                    sb.AppendLine(string.Format(format, srcDirectoryName, srcFileName, dstDirectoryName, dstFileNameWithoutExtension));
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}