using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Carte_de_Noel_HV
{
    public static class MusicManager
    {
        private static MediaPlayer player = new MediaPlayer();
        private static bool isStarted = false;

        public static void Play()
        {
            if (isStarted) return;

            player.Open(new Uri("assets/sounds/music.mp3", UriKind.Relative));
            player.Volume = 0.5;
            player.MediaEnded += (s, e) =>
            {
                player.Position = TimeSpan.Zero;
                player.Play();
            };

            player.Play();
            isStarted = true;
        }
    }
}
