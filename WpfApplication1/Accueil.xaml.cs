using System;
using System.Windows;
using ClassLibrary;
using SQL;

namespace WpfApplication1
{
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
            Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
            NomPrenom.Content = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
            Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€"; // Initialise le label Solde dans le menu utilisateur //
        }



        /// <summary>
        /// Affiche la page Films quand on clique sur le bouton FILMS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Films(object sender, RoutedEventArgs e)
        {
            Films Films = new Films();
            Films.Show();
            this.Close();
        }



        /// <summary>
        /// Affiche la page Musiques quand on clique sur le bouton MUSIQUES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Musiques(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            this.Close();
        }



        /// <summary>
        /// Déconnecte l'utilisateur en cours et renvoie sur la page de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }



        /// <summary>
        /// Affiche 1 InputBox pour augmenter son solde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AugmenterSolde(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }



        /// <summary>
        /// Bouton valider de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            int cpt = 0;
            int cpt2 = 0;
            string input = InputTextBox.Text;
            foreach (Char c in input) // pour chaque caractère inscrit dans la textbox //
            {
                if (!Char.IsDigit(c)) // si ce caractère n'est pas un chiffre compris entre 0 et 9 //
                {
                    cpt += 1; // alors on incrémente le compteur de 1 //
                }
                cpt2 += 1; // compteur qui compte le nombre de caractère renseigné //
            }
            if (cpt2 == 0)
                MessageBox.Show("Vous n'avez entré aucune valeur !", "Erreur");
            else if (cpt != 0) // si le compteur n'est pas égal à 0 //
            {
                MessageBox.Show("Format invalide (Entiers uniquement) !", "Erreur format"); // on affiche un message indiquant que le format n'est pas respecté //
                InputTextBox.Text = String.Empty; // on réinitialise le contenu de la textbox //
            }
            else
            {
                Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
                SQLupdate SQLupdate = new SQLupdate();
                Utilisateur.AjouterSolde(Convert.ToDecimal(input));
                Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                SQLupdate.UpdateSolde(Utilisateur.GetUserName(), Convert.ToDecimal(input));
                InputBox.Visibility = Visibility.Collapsed;
                InputTextBox.Text = String.Empty;
            }
        }



        /// <summary>
        /// Bouton annuler de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }
    }
}
