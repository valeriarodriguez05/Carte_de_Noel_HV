using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Carte_de_Noel_HV.Views
{
    public partial class JourWindow : Window
    {
        /// <summary>
        /// Constructeur recevant l’image et le texte à afficher
        /// </summary>
        public JourWindow(string imageUri, string texte)
        {
            InitializeComponent();

            // Chargement de l’image depuis les ressources WPF
            CarteImage.Source = new BitmapImage(
                new Uri(imageUri, UriKind.Absolute));

            // Affichage du texte
            CarteTexte.Text = texte;
        }
    }
}
