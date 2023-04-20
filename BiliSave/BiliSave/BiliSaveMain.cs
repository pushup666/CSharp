using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BiliSave
{
    public partial class BiliSaveMain : Form
    {
        public BiliSaveMain()
        {
            InitializeComponent();
        }

        private void BiliSaveMain_Load(object sender, EventArgs e)
        {
            textBoxPathLoad.Text = @"C:\Users\ssf\Desktop\Videos\bilibili";
            textBoxPathSave.Text = @"C:\Users\ssf\Desktop\Video";
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            var listItem = Directory.GetDirectories(textBoxPathLoad.Text, "*", SearchOption.TopDirectoryOnly);

            foreach (var itemPath in listItem)
            {
                var filePlayUrl = $"{itemPath}\\.playurl";
                var fileVideoInfo = $"{itemPath}\\.videoInfo";

                if (!File.Exists(filePlayUrl)) continue;

                using (var file = File.OpenText(fileVideoInfo))
                {
                    using (var reader = new JsonTextReader(file))
                    {
                        var o = (JObject)JToken.ReadFrom(reader);

                        var fileSrcVideo = $"{itemPath}\\{o["itemId"]}-1-30080.m4s";
                        var fileDstVideo = $"{textBoxPathSave.Text}\\Video.m4v";
                        CrackMp4File(fileSrcVideo, fileDstVideo);

                        var fileSrcAudio = $"{itemPath}\\{o["itemId"]}-1-30280.m4s";
                        var fileDstAudio = $"{textBoxPathSave.Text}\\Audio.m4a";
                        CrackMp4File(fileSrcAudio, fileDstAudio);

                        var fileDstMp4 = $"{textBoxPathSave.Text}\\P{o["p"]} {o["title"]}.mp4";

                        var cmdArguments = $"-i \"{fileDstVideo}\" -i \"{fileDstAudio}\" -vcodec copy -acodec copy \"{fileDstMp4}\"";
                        ExecCmd(cmdArguments);
                    }
                }
            }
        }

        private static void CrackMp4File(string srcFile, string dstFile)
        {
            var srcBytes = File.ReadAllBytes(srcFile);
            var dstBytes = new byte[srcBytes.Length - 9];

            for (var i = 0; i < dstBytes.Length; i++)
            {
                dstBytes[i] = srcBytes[i + 9];
            }

            File.WriteAllBytes(dstFile, dstBytes);
        }

        private void ExecCmd(string cmdArguments)
        {
            try
            {
                var p = new Process
                {
                    StartInfo =
                    {
                        WorkingDirectory = textBoxPathSave.Text,
                        FileName = "ffmpeg",
                        Arguments = cmdArguments,
                        WindowStyle = ProcessWindowStyle.Normal
                    }
                };

                p.Start();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }
    }
}
