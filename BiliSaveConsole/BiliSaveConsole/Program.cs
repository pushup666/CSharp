using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BiliSaveConsole
{
    class Program
    {
        private static string pathLoad = @"C:\Users\ssf\Desktop\Videos\bilibili";
        private static string pathSave = @"C:\Users\ssf\Desktop\Video";


        static void Main(string[] args)
        {

            var listItem = Directory.GetDirectories(pathLoad, "*", SearchOption.TopDirectoryOnly);

            foreach (var itemPath in listItem)
            {
                var filePlayUrl = $"{itemPath}\\.playurl";
                var fileVideoInfo = $"{itemPath}\\.videoInfo";

                if (!File.Exists(filePlayUrl)) continue;

                var listM4s = Directory.GetFiles(itemPath, "*.m4s");

                if (listM4s.Length != 2)
                {
                    Console.WriteLine($@"{itemPath}中m4s文件数为不等于2");
                    continue;
                }

                for (var i = 0; i < listM4s.Length; i++)
                {
                    CrackMp4File(listM4s[i], $"{pathSave}\\{i}.m4s");
                }

                using (var file = File.OpenText(fileVideoInfo))
                {
                    using (var reader = new JsonTextReader(file))
                    {
                        var o = (JObject)JToken.ReadFrom(reader);

                        var fileDstMp4 = $"{pathSave}\\P{o["p"]}.{o["title"]}.mp4";

                        var cmdArguments = $"-i \"{pathSave}\\0.m4s\" -i \"{pathSave}\\1.m4s\" -vcodec copy -acodec copy \"{fileDstMp4}\"";
                        ExecCmd(cmdArguments);
                    }
                }
            }
            Console.WriteLine(@"Finish!");
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

        private static void ExecCmd(string cmdArguments)
        {
            try
            {
                var p = new Process
                {
                    StartInfo =
                    {
                        WorkingDirectory = pathSave,
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
                Console.WriteLine(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
        }
    }
}
