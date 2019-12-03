using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ffmpeg_gui
{
    public partial class MainFrm : Form
    {
        //码率预估      width * height * fps / 20 / 1024;
        //1280 * 720 = 1350K;   1366 * 768 = 1536K;     1920 * 1080 = 3037K;    2560 * 1440 = 5400K;    3840 * 2160 = 12150K


        //分割        ffmpeg -ss 00:02:40 -i 111.mp4 -c copy -t 01:27:15 222.mp4
        //录屏        ffmpeg -f gdigrab -probesize 100M -i desktop -b:v 1536k -vcodec h264_qsv desktop.mp4
        //录屏录音    ffmpeg -f dshow   -rtbufsize 100M -i video="screen-capture-recorder":audio="virtual-audio-capturer" -b:v 1536k -vcodec h264_qsv -acodec aac -ac 2 desktop.mp4

        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();

        //VideoFormat
        private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -an ""{2}\Video_{3}.mp4""";             //copy

        //private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -an ""{2}\Video_{3}.mp4""";     //default 2000 Kbps/s
        //private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_qsv   -an ""{2}\Video_{3}.mp4""";     //default 1000 Kbps/s

        //private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -b:v 2000K     -an ""{2}\Video_{3}.mp4""";
        //private const string VideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -rc vbr -cq 30 -an ""{2}\Video_{3}.mp4""";

        //private const string VideoFormat = @"x264 -o ""{2}\Video_{3}.mp4"" ""{0}\{1}"" --ssim --tune ssim";




        //AudioFormat
        private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -vn -acodec copy ""{2}\Audio_{3}.m4a""";             //copy

        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -f wav - | neroaacenc -q 0.3 -if - -ignorelength -of ""{2}\Audio_{3}.m4a""";         // 81  Kbps/s       59x
        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -f wav - | neroaacenc -q 0.4 -if - -ignorelength -of ""{2}\Audio_{3}.m4a""";         // 120 Kbps/s       55x
        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -ac 2 -f wav - | neroaacenc -q 0.5 -if - -ignorelength -of ""{2}\Audio_{3}.m4a""";         // 168 Kbps/s       52x

        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -vn -acodec aac -ac 2          ""{2}\Audio_{3}.m4a""";                                     // 130 Kbps/s       36x
        //private const string AudioFormat = @"ffmpeg -i ""{0}\{1}"" -vn -acodec aac -ac 2 -q:a 0.7 ""{2}\Audio_{3}.m4a""";                                     // 86  Kbps/s       44x





        //PackageFormat
        private const string PackageFormat = @"ffmpeg -i ""{2}\Video_{3}.mp4"" -i ""{2}\Audio_{3}.m4a"" -vcodec copy -acodec copy ""{2}\{3}_ENC.mp4""";



        //AllFormat
        private const string AllFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -acodec copy ""{2}\{3}.mp4""";            //copy

        //private const string AllFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec libx264    -acodec aac -ac 2 ""{2}\{3}_libx264.mp4""";
        //private const string AllFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec libx265    -acodec aac -ac 2 ""{2}\{3}_libx265.mp4""";
        //private const string AllFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_nvenc -acodec aac -ac 2 ""{2}\{3}_h264_nvenc.mp4""";

        //private const string AllFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec hevc_nvenc -b:v 2000K -acodec aac -ac 2 -q:a 0.7 ""{2}\{3}_hevc_nvenc.mp4""";     //16:9 1080 2500、720 1500、480 
        //private const string AllFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec h264_qsv              -acodec aac -ac 2          ""{2}\{3}_h264_qsv.mp4""";




        private const string SeparateAudioFormat = @"ffmpeg -i ""{0}\{1}"" -acodec copy -vn ""{2}\Audio_{3}.m4a""";
        private const string SeparateVideoFormat = @"ffmpeg -i ""{0}\{1}"" -vcodec copy -an ""{2}\Video_{3}.mp4""";
        //private const string SeparateSubtitleFormat = @"ffmpeg -i ""{0}\{1}"" -vn -an -scodec copy ""{2}\Sub_{3}.ass""";

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

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            GenerateCmdLine(AllFormat);
        }

        private void ButtonSeparateClick(object sender, EventArgs e)
        {
            GenerateCmdLine(SeparateAudioFormat);
            GenerateCmdLine(SeparateVideoFormat);
        }

        private void GenerateCmdLine(string format)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (string item in checkedListBoxFileName.CheckedItems)
                {
                    var srcDirectoryName = Path.GetDirectoryName(item);
                    var dstDirectoryName = checkBoxSaveToRam.Checked ? "Z:" : srcDirectoryName;
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


        private void ButtonSave_Click(object sender, EventArgs e)
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
    }
}