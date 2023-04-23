using System;
using System.Diagnostics;
using System.IO;
using System.Text;
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
            textBoxPathLoad.Text = @"Z:\Temp\bilibili";
            textBoxPathSave.Text = @"Z:\Temp";
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            var listItem = Directory.GetDirectories(textBoxPathLoad.Text, "*", SearchOption.TopDirectoryOnly);

            foreach (var itemPath in listItem)
            {
                var filePlayUrl = $"{itemPath}\\.playurl";
                var fileVideoInfo = $"{itemPath}\\.videoInfo";

                if (!File.Exists(filePlayUrl)) continue;

                var listM4s = Directory.GetFiles(itemPath, "*.m4s");

                if (listM4s.Length != 2)
                {
                    MessageBox.Show($@"{itemPath}中m4s文件数为不等于2");
                    continue;
                }

                for (var i = 0; i < listM4s.Length; i++)
                {
                    CrackMp4File(listM4s[i], $"{textBoxPathSave.Text}\\{i}.m4s");
                }

                using (var file = File.OpenText(fileVideoInfo))
                {
                    using (var reader = new JsonTextReader(file))
                    {
                        var o = (JObject)JToken.ReadFrom(reader);

                        var fileDstMp4 = $"P{o["p"]}.{o["title"]}.mp4";

                        var sb = new StringBuilder(fileDstMp4);
                        foreach (var rInvalidChar in Path.GetInvalidFileNameChars())
                        {
                            sb.Replace(rInvalidChar.ToString(), string.Empty);
                        }
                        fileDstMp4 = sb.ToString();

                        var cmdArguments = $"-i \"{textBoxPathSave.Text}\\0.m4s\" -i \"{textBoxPathSave.Text}\\1.m4s\" -vcodec copy -acodec copy \"{textBoxPathSave.Text}\\{fileDstMp4}\"";
                        ExecCmd(cmdArguments);
                    }
                }
            }
            MessageBox.Show(@"Finish!");
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
