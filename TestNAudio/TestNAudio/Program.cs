using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.Compression;

namespace TestNAudio
{
    static class Program
    {
        static Dictionary<double, string> _lrcDict = new Dictionary<double, string>();

        private static void Main(string[] args)
        {
            ReadLyricFile(@"D:\Music\叶倩文 - 秋去秋来.lrc");
            PlayAudioFile(@"D:\Music\叶倩文 - 秋去秋来.mp3");




            //var outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "NAudio");
            //Directory.CreateDirectory(outputFolder);
            //var outputFilePath = Path.Combine(outputFolder, "recorded.wav");
            //var capture = new WasapiLoopbackCapture();
            //var writer = new WaveFileWriter(outputFilePath, capture.WaveFormat);
        }

        private static void PlayAudioFile(string fileFullName)
        {
            try
            {
                var st = new Stopwatch();

                using (var audioFile = new AudioFileReader(fileFullName))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    st.Restart();
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"{Path.GetFileName(fileFullName)?.PadRight(30, ' ')}{st.Elapsed:hh\\:mm\\:ss}");


                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void ReadLyricFile(string fileFullName)
        {
            using (var sr = new StreamReader(fileFullName, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("]"))
                    {
                        continue;
                    }

                    var temp = line.Split(']');

                    var seq = temp.Last().Trim();
                    if (seq == "")
                    {
                        continue;
                    }

                    for (var i = 0; i < temp.Length - 1; i++)
                    {
                        var tsTemp = "00:" + temp[i].Replace("[", "");
                        var ts = TimeSpan.Parse(tsTemp).TotalMilliseconds;

                        _lrcDict.Add(ts, seq);
                    }
                }
            }
        }

        private static string GetLyric(int elapsedMilliseconds)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _lrcDict.Count; i++)
            {
                
            }




            return sb.ToString();
        }
    }
}
