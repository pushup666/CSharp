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
            textBoxPathLoad.Text = @"Z:\Temp";
            textBoxPathTemp.Text = @"Z:\";
            textBoxPathSave.Text = @"Z:\";
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            var listItem = Directory.GetDirectories(textBoxPathLoad.Text, "*", SearchOption.TopDirectoryOnly);

            foreach (var itemPath in listItem)
            {
                var filePlayUrl = $"{itemPath}\\.playurl";
                var fileVideoInfo = $"{itemPath}\\.videoInfo";

                if (!File.Exists(filePlayUrl)) continue;

                var listM4S = Directory.GetFiles(itemPath, "*.m4s");

                if (listM4S.Length != 2)
                {
                    MessageBox.Show($@"{itemPath}中m4s文件数为不等于2");
                    continue;
                }

                for (var i = 0; i < listM4S.Length; i++)
                {
                    CrackMp4FileNew(listM4S[i], $"{textBoxPathTemp.Text}\\{i}.m4s");
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

                        var cmdArguments = $"-i \"{textBoxPathTemp.Text}\\0.m4s\" -i \"{textBoxPathTemp.Text}\\1.m4s\" -vcodec copy -acodec copy \"{textBoxPathSave.Text}\\{fileDstMp4}\"";
                        ExecCmd(cmdArguments);
                    }
                }
            }
            MessageBox.Show(@"Finish!");
        }

        private static void CrackMp4FileNew(string srcFile, string dstFile)
        {
            using (FileStream fsRead = new FileStream(srcFile, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(dstFile, FileMode.Create))
                {
                    byte[] arr = new byte[10*1024*1024];

                    int count = 0;
                    bool isFirst = true;
                    const int offset = 9;

                    while (fsRead.Position < fsRead.Length)
                    {
                        count = fsRead.Read(arr, 0, arr.Length);

                        if (isFirst)
                        {
                            fsWrite.Write(arr, offset, count - offset);
                            isFirst = false;
                        }
                        else
                        {
                            fsWrite.Write(arr, 0, count);
                        }
                       
                    }
                }
            }
        }

        private static void CrackMp4File(string srcFile, string dstFile)
        {
            var srcBytes = File.ReadAllBytes(srcFile);
            const int offset = 9;

            using (var writer = new BinaryWriter(new FileStream(dstFile, FileMode.Create)))
            {
                writer.Write(srcBytes, offset, srcBytes.Length - offset);
            }
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
