using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class MesFilms : Window
    {
        private List<Film> eFilm = new List<Film>(); // Liste d'objets Film possédé par l'utilisateur que l'on affiche dans la ListView // 
        private List<string> mesFilms = new List<string>(); // Liste des noms de films possédés par l'utilisateur actuel //
        public MesFilms()
        {
            InitializeComponent();
            Utilisateur Utilisateur = new Utilisateur();
            NomPrenom.Text = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
            Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
            list.ItemsSource = eFilm;
            using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("ChargementMesFilms", sqlCon); // Appelle la procédure stockée ChargementMesFilms qui recupère le nom de tous les films pour l'utilisateur en cours //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName()); // Cette procédure prend en paramètre l'identifiant de l'utilisateur en cours que l'on récupère au moment de la connexion (lorsque celle-ci réussit) //
                cmd.ExecuteNonQuery(); // Execute la procédure //
                SqlDataReader reader = cmd.ExecuteReader(); // on créé un reader capable de lire des données SQL //
                while (reader.Read()) // Tant que ce reader lit des données on éxécute le code ci-dessous //
                {
                    mesFilms.Add((string)reader[0]); // Ajoute dans la liste mesFilms tous les noms de films possédés par l'utilisateur actuel //
                }
                reader.Close();
                Films Films = new Films();
                foreach (string film in mesFilms) // Pour chacun des noms de films présent dans cette liste, on cherche la correspondance avec l'objet "Film" en question //
                    eFilm.Add(Films.EFilms.Find(x => x.Nom == film)); // On retourne l'objet correspond dans une list<Film> //
                list.ItemsSource = eFilm; // On affiche tous les films possédés par l'utilisateur dans la ListView en indiquant la source de celle-ci //
            }
        }

        // LIST : GET, SET !!! //
        //////////////////////////////////////////////
        public List<Film> GetList()
        {
            return eFilm;
        }
        public void SetList(Film film)
        {
            eFilm.Add(film);
        }
        //////////////////////////////////////////////



        // MENU MATERIAL DESIGN !!! //
        ///////////////////////////////////////////////////////////////////////////
        private void Retour(object sender, RoutedEventArgs e)
        {
            Films Films = new Films();
            Films.Show();
            this.Close();
        }
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            this.Close();
        }
        private void Films(object sender, RoutedEventArgs e)
        {
            Films Films = new Films();
            Films.Show();
            this.Close();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemRetour":
                    Retour(sender, e);
                    break;
                case "ItemAccueil":
                    Accueil(sender, e);
                    break;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////



        // MENU COMPTE UTILISATEUR !!! //
        ///////////////////////////////////////////////////////////////////////
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
        ///////////////////////////////////////////////////////////////////////



        // BOUTON AJOUTER SOLDE //
        //////////////////////////////////////////////////////////////
        private void AugmenterSolde(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
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
                cpt2 += 1;
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
    }
}