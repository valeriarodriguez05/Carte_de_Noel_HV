# 🎄 Carte de Noël – WPF

Petit projet WPF permettant d’afficher une **carte de Noël aléatoire** (image + texte) lorsqu’on clique sur une étoile.

Chaque carte est **unique** : une image et un texte ne peuvent être utilisés qu’une seule fois.

---

## ✨ Fonctionnement

* L’écran principal affiche plusieurs étoiles cliquables
* Au clic sur une étoile :

  * une image est choisie aléatoirement
  * un texte est choisi aléatoirement
  * une nouvelle fenêtre s’ouvre pour afficher la carte
* L’image et le texte sont ensuite supprimés des listes
* L’étoile cliquée est désactivée

---


## ⚙️ Configuration importante

Pour **toutes les images et fichiers texte** dans `assets` :

* **Action de génération** : `Resource`
* **Copier dans le répertoire de sortie** : `Ne pas copier`

Cela permet d’utiliser les ressources WPF sans problème de chemins.

---

## 🚀 Lancer le projet

1. Ouvrir la solution dans Visual Studio
2. Vérifier la configuration des fichiers dans `assets`
3. Lancer le projet (`F5`)
4. Cliquer sur une étoile ⭐

---

## 🛠️ Technologies

* C#
* WPF
* XAML

---

🎁 Projet simple à but pédagogique – Joyeuses fêtes 🎄
