using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class calendrier : Window
    {
        string nomUtilisateur;
        // Le nom est reçu depuis la fenêtre précédente

        public calendrier()
        {
            // Correction : Ajout de l'appel à InitializeComponent généré par le designer XAML
            this.InitializeComponent();

            //recupérer le nom depuis le fichier de configuration
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            nomUtilisateur = configuration.AppSettings.Settings["NomUtilisateur"]?.Value ?? "Invité";

            // TEXTE DE BIENVENUE PERSONNALISÉ
            TexteBienvenue.Text =
                "Bienvenue " + nomUtilisateur + " 🎄\n\n" +
                "Clique sur le bouton ci-dessous pour découvrir le calendrier !";

            TexteBienvenue.Foreground = Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Crée la nouvelle fenêtre
            var carteJour = new carte_du_jour();

            // Affiche la nouvelle fenêtre
            carteJour.Show();

            // Ferme la fenêtre actuelle
            this.Close();
        }
    }
}
