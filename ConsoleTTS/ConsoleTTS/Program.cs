using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTTS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.Rate = 5;

                // Configure the audio output.
                synth.SetOutputToWaveFile(@"C:\Users\ssf\Desktop\tts\test.wav", new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));

                // Create a SoundPlayer instance to play output audio file.
                System.Media.SoundPlayer m_SoundPlayer = new System.Media.SoundPlayer(@"C:\Users\ssf\Desktop\tts\test.wav");

                // Build a prompt.
                var text = File.ReadAllText(@"C:\Users\ssf\Desktop\tts\test.txt");
                PromptBuilder builder = new PromptBuilder();
                builder.AppendText(text);

                // Speak the prompt.
                synth.Speak(builder);
                m_SoundPlayer.Play();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
