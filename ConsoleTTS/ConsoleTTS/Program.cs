using System;
using System.IO;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;

namespace ConsoleTTS
{
    static class Program
    {
        //ConsoleTTS -path txtPath
        //ConsoleTTS -file txtFile
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                GenBatFile(Environment.CurrentDirectory);
            }
            if (args.Length == 2)
            {
                if (args[0] == "-path")
                {
                    GenBatFile(args[1]);
                }
                if (args[0] == "-file")
                {
                    Txt2Wav(args[1]);
                }
                else
                {
                    ShowHelp();
                }
            }
            else
            {
                ShowHelp();
            }
        }

        private static void Txt2Wav(string textFileName)
        {
            if (textFileName == null) return;

            Console.WriteLine(textFileName);

            using (var synth = new SpeechSynthesizer())
            {
                var text = File.ReadAllText(textFileName, Encoding.Default);
                var builder = new PromptBuilder();
                builder.AppendText(text);

                var wavFileName = Path.ChangeExtension(textFileName, "wav");

                synth.Rate = 5;
                synth.SetOutputToWaveFile(wavFileName, new SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Stereo));
                synth.Speak(builder);
            }
        }

        private static void GenBatFile(string path)
        {
            var sb = new StringBuilder();
            var files = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var wavFileName = Path.ChangeExtension(file, "wav");
                var mp3FileName = Path.ChangeExtension(file, "mp3");

                sb.AppendFormat(@"ConsoleTTS -file ""{0}""", file);
                sb.AppendLine();
                sb.AppendFormat(@"ffmpeg -channel_layout stereo -i ""{0}"" -codec:a libmp3lame -q:a 9 ""{1}""", wavFileName, mp3FileName);
                sb.AppendLine();
                sb.AppendFormat(@"del ""{0}""", wavFileName);
                sb.AppendLine();
            }

            File.WriteAllText(Environment.CurrentDirectory + "\\ssf.bat", sb.ToString(), Encoding.Default);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("ConsoleTTS -path txtPath     to gen bat file");
            Console.WriteLine("OR");
            Console.WriteLine("ConsoleTTS -file txtFile     to gen wav file");
        }
    }
}
