using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TestNAudio
{
    class Program
    {
        private static void Main(string[] args)
        {
            const string audioFileName = @"D:\Music\2pac - Life Goes On.mp3";

            using (var audioFile = new AudioFileReader(audioFileName))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
