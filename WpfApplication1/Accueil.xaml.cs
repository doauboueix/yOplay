using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApplication1
{
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
            Utilisateur Utilisateur = new Utilisateur();
            NomPrenom.Content = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
            Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
        }



        // BOUTON FILMS //
        /////////////////////////////////////////////////////////////
        private void Films(object sender, RoutedEventArgs e)
        {
            Films Films = new Films();
            Films.Show();
            this.Close();
        }
        /////////////////////////////////////////////////////////////



        // BOUTON MUSIQUES //
        /////////////////////////////////////////////////////////////
        private void Musiques(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            this.Close();
        }
        /////////////////////////////////////////////////////////////



        // BOUTON SE DECONNECTER //
        //////////////////////////////////////////////////////////////
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
        //////////////////////////////////////////////////////////////



        // BOUTON AJOUTER SOLDE //
        //////////////////////////////////////////////////////////////
        private void AugmenterSolde(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }
        //////////////////////////////////////////////////////////////



        // INPUT BOX //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                MessageBox.Show("Format valide (Entiers uniquement) !", "Erreur format"); // on affiche un message indiquant que le format n'est pas respecté //
                InputTextBox.Text = String.Empty; // on réinitialise le contenu de la textbox //
            }
            else
            {
                Utilisateur Utilisateur = new Utilisateur();
                Utilisateur.AjouterSolde(Convert.ToDecimal(input));
                Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE UserTable SET Solde = @Solde WHERE UserName = @UserName", sqlCon); // créé une commande qui modifie le solde de l'utilisateur actuel //
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Solde", Utilisateur.GetSolde()); // cette commande prend en paramètre le solde de l'utilisateur //
                    cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName()); // elle doit donc récupérer le UserName de celui-ci //
                    cmd.ExecuteNonQuery(); // Exécute la procédure //
                }

                InputBox.Visibility = Visibility.Collapsed;
                InputTextBox.Text = String.Empty;
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
