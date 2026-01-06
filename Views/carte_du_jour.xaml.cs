using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Carte_de_Noel_HV.Views
{
    public class CarteJour
    {
        public string Image { get; set; }
        public string Texte { get; set; }
    }

    public partial class carte_du_jour : Window
    {
        string basePath;
        string cartesPath;
        string textesPath;
        string historiquePath;

        Dictionary<string, CarteJour> historique;
        private static Random rnd = new Random();
        public carte_du_jour()
        {
            InitializeComponent();

            basePath = AppDomain.CurrentDomain.BaseDirectory;

            cartesPath = Path.Combine(basePath, "assets", "cartes");
            textesPath = Path.Combine(basePath, "assets", "textes");
            historiquePath = Path.Combine(basePath, "assets", "historique.json");

            Directory.CreateDirectory(cartesPath);
            Directory.CreateDirectory(textesPath);

            ChargerHistorique();
        }

        private void ChargerHistorique()
        {
            if (File.Exists(historiquePath))
            {
                historique = JsonSerializer.Deserialize<Dictionary<string, CarteJour>>(
                    File.ReadAllText(historiquePath));
            }
            else
            {
                historique = new Dictionary<string, CarteJour>();
            }
        }

        private void SauvegarderHistorique()
        {
            File.WriteAllText(
                historiquePath,
                JsonSerializer.Serialize(historique, new JsonSerializerOptions { WriteIndented = true })
            );
        }

        private CarteJour CreerCarte(string jour)
        {
            var images = Directory.GetFiles(cartesPath);
            var textes = Directory.GetFiles(textesPath);

            if (images.Length == 0 || textes.Length == 0)
            {
                MessageBox.Show("Aucune image ou aucun texte trouvé dans les dossiers assets.",
                                "Erreur",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return null;
            }

            // Images déjà utilisées
            var imagesUtilisees = historique.Values.Select(c => c.Image).ToList();
            var textesUtilises = historique.Values.Select(c => c.Texte).ToList();

            var imagesDispo = images.Where(i => !imagesUtilisees.Contains(i)).ToList();
            var textesDispo = textes.Where(t => !textesUtilises.Contains(t)).ToList();

            if (imagesDispo.Count == 0 || textesDispo.Count == 0)
            {
                MessageBox.Show("Toutes les cartes ont déjà été utilisées.",
                                "Information",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return null;
            }


            CarteJour carte = new CarteJour
            {
                Image = imagesDispo[rnd.Next(imagesDispo.Count)],
                Texte = textesDispo[rnd.Next(textesDispo.Count)]
            };

            historique[jour] = carte;
            SauvegarderHistorique();

            return carte;
        }

        private void Case_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string jour = btn.Tag.ToString();

                CarteJour carte;
                if (historique.ContainsKey(jour))
                {
                    carte = historique[jour];
                }
                else
                {
                    carte = CreerCarte(jour);
                }

                if (carte == null)
                    return;

                string texte = File.ReadAllText(carte.Texte);

                JourWindow window = new JourWindow(carte.Image, texte);
                window.Show();
            }
        }
    }
}




//string cartesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/cartes"); // Chemin vers le dossier des images
//string textesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/textes"); // Chemin vers le dossier des textes
//string historiquePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/historique.txt"); // Chemin du fichier qui mémorise les cartes déjà utilisées

//public carte_du_jour()
//{
//    InitializeComponent();
//}
//public (string imagePath, string texte) TirerCarteDuJour() // Méthode principale qui tire une carte du jour
//{
//    // Créer l'historique s'il n'existe pas
//    if (!File.Exists(historiquePath))
//        File.WriteAllText(historiquePath, "");

//    List<string> cartesUtilisees = File.ReadAllLines(historiquePath).ToList(); // On lit toutes les cartes déjà utilisées

//    List<string> cartesDispo = Directory.GetFiles(cartesPath) // On récupère toutes les cartes disponibles non encore utilisées
//                                         .Where(c => !cartesUtilisees.Contains(c))
//                                         .ToList();

//    List<string> textesDispo = Directory.GetFiles(textesPath) // On récupère tous les textes disponibles non encore utilisés
//                                         .Where(c => !cartesUtilisees.Contains(c))
//                                         .ToList();

//    if (cartesDispo.Count == 0 || textesDispo.Count == 0) // Si toutes les cartes ou tous les textes sont utilisés, on stoppe
//        throw new Exception("Toutes les cartes ont déjà été utilisées !");

//    Random rnd = new Random(); // Générateur de nombres aléatoires

//    string carteChoisie = cartesDispo[rnd.Next(cartesDispo.Count)]; // On choisit une carte au hasard
//    string texteChoisie = textesDispo[rnd.Next(textesDispo.Count)]; // On choisit un texte au hasard

//    // Sauvegarde dans l'historique
//    File.AppendAllText(historiquePath, carteChoisie + Environment.NewLine);
//    File.AppendAllText(historiquePath, texteChoisie + Environment.NewLine);

//    string contenuTexte = File.ReadAllText(texteChoisi);

//    return (carteChoisie, contenuTexte); // On retourne le chemin de l'image + le texte
//}

//private void Case_Click(object sender, RoutedEventArgs e)
//{
//    if (sender is Button btn)
//    {
//        // Numéro de la case (1 à 24)
//        string numero = btn.Content.ToString();

//        try
//        {
//            var (imagePath, texte) = TirerCarteDuJour();

//            MessageBox.Show(
//                $"🎄 Carte n°{numero}\n\n{texte}",
//                "Carte du jour",
//                MessageBoxButton.OK,
//                MessageBoxImage.Information
//            );
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//    }
//        //}
//    }
//}
