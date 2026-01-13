using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;

namespace Carte_de_Noel_HV.Views
{
    public partial class carte_du_jour : Window
    {
        // Liste des URI des images (ressources WPF)
        private static List<string> imagesCartes;

        // Liste des URI des fichiers texte (ressources WPF)
        private static List<string> textesCartes;

        // Générateur aléatoire
        private static Random random = new Random();

        public carte_du_jour()
        {
            InitializeComponent();

            // Initialisation des listes UNE SEULE FOIS
            InitialiserCartes();
        }

        /// <summary>
        /// Initialise les listes d’images et de textes
        /// </summary>
        private void InitialiserCartes()
        {
            // Empêche la réinitialisation (évite la répétition)
            if (imagesCartes != null && textesCartes != null)
                return;

            // 🔹 LISTE DES IMAGES (pack URI WPF)
            imagesCartes = new List<string>
            {
                "pack://application:,,,/assets/cartes/cartetest.png",
                "pack://application:,,,/assets/cartes/cartetest2.png",
                // ➜ ajoute autant d’images que tu veux
            };

            // 🔹 LISTE DES TEXTES (URI relative WPF)
            textesCartes = new List<string>
            {
                "assets/textes/texte1.txt"
                // ➜ ajoute autant de textes que tu veux
            };
        }

        /// <summary>
        /// Événement déclenché au clic sur une étoile
        /// </summary>
        private void Case_Click(object sender, RoutedEventArgs e)
        {
            // Sécurité : plus de cartes disponibles
            if (imagesCartes.Count == 0 || textesCartes.Count == 0)
            {
                MessageBox.Show("Toutes les cartes ont déjà été ouvertes 🎄");
                return;
            }

            // 🔹 Tirage aléatoire d’une image
            int indexImage = random.Next(imagesCartes.Count);
            string imageUri = imagesCartes[indexImage];

            // 🔹 Tirage aléatoire d’un texte
            int indexTexte = random.Next(textesCartes.Count);
            string texteUri = textesCartes[indexTexte];

            // 🔹 Lecture du texte depuis les ressources WPF
            string texte;
            StreamResourceInfo streamInfo =
                Application.GetResourceStream(new Uri(texteUri, UriKind.Relative));

            using (StreamReader reader = new StreamReader(streamInfo.Stream))
            {
                texte = reader.ReadToEnd();
            }

            // 🔹 Suppression des éléments utilisés (ANTI-DOUBLON)
            imagesCartes.RemoveAt(indexImage);
            textesCartes.RemoveAt(indexTexte);

            // 🔹 Désactivation visuelle du bouton cliqué
            Button bouton = sender as Button;
            bouton.IsEnabled = false;
            bouton.Opacity = 0.5;

            // 🔹 Ouverture de la fenêtre JourWindow
            JourWindow window = new JourWindow(imageUri, texte);
            window.ShowDialog();
        }
    }
}
