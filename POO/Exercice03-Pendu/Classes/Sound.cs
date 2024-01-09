using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03.Classes
{
    internal class Sound
    {
        public static void PlayStartup()
        {
            PlaySoundFile("Sounds\\startup.wav");
        }

        public static void PlayWrong()
        {
            PlaySoundFile("Sounds\\wrong.wav");
        }

        public static void PlayCorrect()
        {
            PlaySoundFile("Sounds\\correct.wav");
        }

        public static void PlayFail()
        {
            PlaySoundFile("Sounds\\fail.wav", true);
        }

        public static void PlaySuccess()
        {
            PlaySoundFile("Sounds\\success.wav", true);
        }

        private static void PlaySoundFile(string file, bool wait = false)
        {
            var t = Task.Run(() => {
                using (var audioFile = new AudioFileReader(file))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(500);
                    }
                }
            });
            if (wait)
                t.Wait();
        }
    }
}
