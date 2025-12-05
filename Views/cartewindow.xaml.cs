using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Carte_de_Noel_HV.Views
{
    public partial class cartewindow : Window
    {
        public cartewindow()
        {
            InitializeComponent();
            MusicManager.PlayMusic(); 
        }
    }

    public static class MusicManager
    {
        private static MediaPlayer player = new MediaPlayer();
        private static bool isInitialized = false;

        public static void PlayMusic()
        {
            if (!isInitialized)
            {
                var uri = new Uri("assets/sounds/music.mp3", UriKind.RelativeOrAbsolute);
                player.Open(uri);
                player.Volume = 0.5;
                player.MediaEnded += (s, e) =>
                {
                    player.Position = TimeSpan.Zero;
                    player.Play();
                };

                isInitialized = true;
            }

            player.Play();
        }

        public static void StopMusic()
        {
            player.Stop();
        }
    }
}


