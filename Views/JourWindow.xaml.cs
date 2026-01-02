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
using System.Collections.Generic;

namespace Carte_de_Noel_HV.Views
{
    public partial class JourWindow : Window
    {
        public JourWindow(int jour)
        {
            InitializeComponent();

            JourText.Text = $"Jour {jour}";
            CadeauText.Text = GetCadeau(jour);
        }

        private string GetCadeau(int jour)
        {
            var cadeaux = new Dictionary<int, string>
            {
                { 1, "Une bougie parfumée 🕯️" },
                { 2, "Un mug personnalisé ☕" },
                { 3, "Un livre inspirant 📚" },
                { 4, "Un parfum 🧴" },
                { 5, "Une boîte de chocolats 🍫" },
                { 6, "Un bonnet ou une écharpe 🧣" },
                { 7, "Une carte cadeau 🎟️" },
                { 8, "Un bracelet ✨" },
                { 9, "Une plante 🪴" },
                { 10, "Un puzzle 🧩" },
                { 11, "Une enceinte Bluetooth 🔊" },
                { 12, "Un sweat confortable 👕" },
                { 13, "Un jeu de société 🎲" },
                { 14, "Une bouillotte 🧸" },
                { 15, "Un carnet personnalisé 📓" },
                { 16, "Une lampe décorative 💡" },
                { 17, "Des chaussettes fun 🧦" },
                { 18, "Un porte-clés personnalisé 🔑" },
                { 19, "Un coffret bien-être 🛀" },
                { 20, "Un cadre photo 🖼️" },
                { 21, "Un plaid tout doux 🛋️" },
                { 22, "Un calendrier personnalisé 📅" },
                { 23, "Une surprise gourmande 🍪" },
                { 24, "🎄 Le cadeau de Noël final 🎁" }
            };

            return cadeaux[jour];
        }
    }
}
