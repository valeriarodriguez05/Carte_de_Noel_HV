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

using System.Configuration;

namespace Carte_de_Noel_HV.Views
{
    public partial class cartewindow : Window
    {

        string nom ="";
        public cartewindow()
        {
            InitializeComponent();
            //MusicManager.PlayMusic(); 
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            nom = PrenomTextBox.Text;

            //cnfiguration pour stocker le nom
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove("NomUtilisateur");
            configuration.AppSettings.Settings.Add("NomUtilisateur", nom);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            if (string.IsNullOrWhiteSpace(nom))
            {
                ResultatText.Text = "Veuillez entrer un prénom.";
            }
            else
            {
                ResultatText.Text = $"Bonjour, {nom} !";
            }
            // Crée la nouvelle fenêtre
            var Calendrier = new calendrier();

            // Affiche la nouvelle fenêtre
            Calendrier.Show();

            // Ferme la fenêtre actuelle
            this.Close();
        }
    }
    }

    //public static class MusicManager
    //{
    //    private static MediaPlayer player = new MediaPlayer();
    //    private static bool isInitialized = false;

    //    public static void PlayMusic()
    //    {
    //        if (!isInitialized)
    //        {
    //            var uri = new Uri("assets/sounds/music.mp3", UriKind.RelativeOrAbsolute);
    //            player.Open(uri);
    //            player.Volume = 0.5;
    //            player.MediaEnded += (s, e) =>
    //            {
    //                player.Position = TimeSpan.Zero;
    //                player.Play();
    //            };

    //            isInitialized = true;
    //        }

    //        player.Play();
    //    }

    //    public static void StopMusic()
    //    {
    //        player.Stop();
    //    }
    //}



