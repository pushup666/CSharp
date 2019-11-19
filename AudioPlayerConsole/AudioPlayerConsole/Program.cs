using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AudioPlayerConsole
{
    struct LrcLine
    {
        public int Position;
        public string Line;
    }


    static class Program
    {
        private static readonly List<LrcLine> LrcList = new List<LrcLine>();

        private static void Main(string[] args)
        {
            ReadLyricFile(@"D:\Music\叶倩文 - 秋去秋来.lrc");
            PlayAudioFile(@"D:\Music\叶倩文 - 秋去秋来.mp3");
        }

        private static void PlayAudioFile(string fileFullName)
        {
            if (!File.Exists(fileFullName))
            {
                return;
            }

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
                        Console.WriteLine($"{Path.GetFileName(fileFullName)}\t\t{st.Elapsed:hh\\:mm\\:ss}");

                        Console.WriteLine();
                        PrintLyric((int)st.ElapsedMilliseconds);

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
            if (!File.Exists(fileFullName))
            {
                return;
            }

            using (var sr = new StreamReader(fileFullName, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("]"))
                    {
                        continue;
                    }

                    var lineSplit = line.Split(']');

                    var lrc = lineSplit.Last().Trim();
                    if (lrc == "")
                    {
                        continue;
                    }

                    for (var i = 0; i < lineSplit.Length - 1; i++)
                    {
                        var timestamp = "00:" + lineSplit[i].Replace("[", "");
                        var position = (int)TimeSpan.Parse(timestamp).TotalMilliseconds;

                        var lline = new LrcLine { Position = position, Line = lrc };

                        LrcList.Add(lline);
                    }
                }
            }
        }

        private static void PrintLyric(int elapsedMilliseconds)
        {
            if (LrcList.Count == 0)
            {
                return;
            }

            var currLineNo = 0;

            for (var i = 0; i < LrcList.Count; i++)
            {
                if (LrcList[i].Position < elapsedMilliseconds)
                {
                    currLineNo = i;
                }
                else
                {
                    break;
                }
            }

            var currLine = LrcList[currLineNo].Line;
            var prevLine = currLineNo > 0 ? LrcList[currLineNo - 1].Line : "";
            var nextLine = currLineNo < LrcList.Count - 1 ? LrcList[currLineNo + 1].Line : "";

            WriteColorLine(prevLine.PadRight(50), ConsoleColor.DarkGray);
            WriteColorLine(currLine.PadRight(50), ConsoleColor.Green);
            WriteColorLine(nextLine.PadRight(50), ConsoleColor.DarkGray);
        }

        private static void WriteColorLine(string value, ConsoleColor color)
        {
            var currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentForeColor;
        }
    }
}
