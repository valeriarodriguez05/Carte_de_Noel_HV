using System;
using System.Collections.Generic;
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
using System.IO;

namespace Carte_de_Noel_HV.Views
{
    
    public partial class carte_du_jour : Window
    {

        string cartesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/cartes"); // Chemin vers le dossier des images
        string textesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/textes"); // Chemin vers le dossier des textes
        string historiquePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/historique.txt"); // Chemin du fichier qui mémorise les cartes déjà utilisées

        public carte_du_jour()
        {
            InitializeComponent();
        }
        public (string imagePath, string texte) TirerCarteDuJour() // Méthode principale qui tire une carte du jour
        {
            // Créer l'historique s'il n'existe pas
            if (!File.Exists(historiquePath))
                File.WriteAllText(historiquePath, "");

            List<string> cartesUtilisees = File.ReadAllLines(historiquePath).ToList(); // On lit toutes les cartes déjà utilisées

            List<string> cartesDispo = Directory.GetFiles(cartesPath) // On récupère toutes les cartes disponibles non encore utilisées
                                                 .Where(c => !cartesUtilisees.Contains(c))
                                                 .ToList();

            List<string> textesDispo = Directory.GetFiles(textesPath) // On récupère tous les textes disponibles non encore utilisés
                                                 .Where(c => !cartesUtilisees.Contains(c))
                                                 .ToList();

            if (cartesDispo.Count == 0 || textesDispo.Count == 0) // Si toutes les cartes ou tous les textes sont utilisés, on stoppe
                throw new Exception("Toutes les cartes ont déjà été utilisées !");

            Random rnd = new Random(); // Générateur de nombres aléatoires

            string carteChoisie = cartesDispo[rnd.Next(cartesDispo.Count)]; // On choisit une carte au hasard
            string texteChoisi = textesDispo[rnd.Next(textesDispo.Count)]; // On choisit un texte au hasard

            // Sauvegarde dans l'historique
            File.AppendAllText(historiquePath, carteChoisie + Environment.NewLine);
            File.AppendAllText(historiquePath, texteChoisi + Environment.NewLine);

            string contenuTexte = File.ReadAllText(texteChoisi);

            return (carteChoisie, contenuTexte); // On retourne le chemin de l'image + le texte
        }

        private void Case_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                // Numéro de la case (1 à 24)
                string numero = btn.Content.ToString();

                try
                {
                    var (imagePath, texte) = TirerCarteDuJour();

                    MessageBox.Show(
                        $"🎄 Carte n°{numero}\n\n{texte}",
                        "Carte du jour",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
