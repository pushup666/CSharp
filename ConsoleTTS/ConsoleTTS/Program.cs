using System;
using System.IO;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;

namespace ConsoleTTS
{
    static class Program
    {
        private static void Main()
        {
            var files = Directory.GetFiles(@"Z:\Temp", "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                Text2Wav(file);
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void Text2Wav(string textFileName)
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
                synth.SetOutputToWaveFile(wavFileName, new SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
                synth.Speak(builder);

                //var mSoundPlayer = new System.Media.SoundPlayer(wavFileName);
                //mSoundPlayer.Play();
            }
        }
    }
}
