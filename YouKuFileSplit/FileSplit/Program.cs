using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSplit
{
    static class Program
    {
        static void Main()
        {
            //var splitPattern = new byte[] { 70, 76, 86, 1, 5 };     //flv
            //const string ext = "flv";

            //var splitPattern = new byte[] {0, 0, 0, 32, 102, 116, 121, 112, 105, 115, 111, 109};     //mp4
            //const string ext = "mp4";

            var splitPattern = new byte[] {107, 101, 0, 60, 7, 120, 0};     //flv
            const string ext = "flv";

            var count = 0;
            const string path = @"D:\Temp\";

            foreach (var fullname in Directory.GetFiles(path, "*.kux"))
            {
                count++;
                
                var name = Path.GetFileNameWithoutExtension(fullname);
                var fileData = File.ReadAllBytes(fullname);

                Console.WriteLine($@"{count}: {name}");

                var idx = new List<int> {0};
                for (var i = 0; i < fileData.Length - splitPattern.Length + 1; i++)
                {
                    var flag = true;
                    for (var j = 0; j < splitPattern.Length; j++)
                    {
                        if (fileData[i + j] != splitPattern[j])
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        idx.Add(i);
                    }
                }
                idx.Add(fileData.Length);

                using (var bat = new StreamWriter($@"{path}concat.bat", true, Encoding.Default))
                {
                    bat.WriteLine("ffmpeg -f concat -i {0}.txt -c copy \"{1}.{2}\"",count, name, "mp4");
                }

                using (var list = new StreamWriter($@"{path}{count}.txt", false, Encoding.Default))
                {
                    for (var i = 1; i < idx.Count; i++)
                    {
                        var data = new byte[idx[i] - idx[i - 1]];
                        Array.Copy(fileData, idx[i - 1], data, 0, idx[i] - idx[i - 1]);
                        File.WriteAllBytes($@"{path}{count}_{i}.{ext}", data);
                        if (i != 1)
                        {
                            list.WriteLine(@"file '{0}_{1}.{2}'", count, i, ext);
                        }
                    }

                }
            }
        }
    }
}
