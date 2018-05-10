using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApplication1
{
    public partial class MesPlaylists : Window
    {
        private List<Musique> eMusique;
        private List<Playlist> ListePlaylist = new List<Playlist>();
        public List<ListPlaylists> LoadingPlaylists = new List<ListPlaylists>();
        private string test = "";
        public MesPlaylists()
        {
            InitializeComponent();
            Utilisateur Utilisateur = new Utilisateur();
            NomPrenom.Text = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
            Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
            using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
            {

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from UserPlaylist WHERE UserName = @UserName;", sqlCon); // Appelle la procédure stockée ChargementMesMusiques qui recupère le nom de tous les films pour l'utilisateur en cours //
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName());  // Cette procédure prend en paramètre l'identifiant de l'utilisateur en cours que l'on récupère au moment de la connexion (lorsque celle-ci réussit) //
                cmd.ExecuteNonQuery(); // Execute la procédure //
                SqlDataReader reader = cmd.ExecuteReader(); // on créé un reader capable de lire des données SQL //
                while (reader.Read()) // Tant que ce reader lit des données on éxécute le code ci-dessous //
                {
                    LoadingPlaylists.Add(new ListPlaylists((string)reader[0], (string)reader[1])); // Ajoute dans la liste mesMusiques tous les noms de musique possédés par l'utilisateur actuel //
                }
                reader.Close();

                Musiques Musiques = new Musiques();
                if (LoadingPlaylists.Count != 0)
                {
                    foreach (ListPlaylists playlist in LoadingPlaylists)
                    {
                        if (test == "")
                        {
                            test = playlist.NamePlaylist;
                            eMusique = new List<Musique>();
                        }
                        if (playlist.NamePlaylist != test)
                        {
                            Playlist l = new Playlist(test, eMusique);
                            SetPlaylist(l);
                            test = playlist.NamePlaylist;
                            eMusique = new List<Musique>();
                        }
                        eMusique.Add(Musiques.EMusique.Find(x => x.Titre == playlist.NameSong));
                    }
                    Playlist m = new Playlist(test, eMusique);
                    SetPlaylist(m);
                }
                list.ItemsSource = GetListePlaylist();
            }
        }



        // GET/SET/REMOVE PLAYLIST //
        /////////////////////////////////////////////////////////
        public List<Playlist> GetListePlaylist()
        {
            return ListePlaylist;
        } 

        public void SetPlaylist ( Playlist p)
        {
            ListePlaylist.Add(p);
        }

        public void DeletePlaylist(int p)
        {
            ListePlaylist.RemoveAt(p);
        }
        /////////////////////////////////////////////////////////



        // CLICK ITEM MENU //
        //////////////////////////////////////////////////////////////////////////
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            this.Close();
        }
        private void MesMusiques(object sender, RoutedEventArgs e)
        {
            MesMusiques MesMusiques = new MesMusiques();
            MesMusiques.Show();
            this.Close();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            this.Close();
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
                case "ItemAccueil":
                    Accueil(sender, e);
                    break;

                case "ItemMesMusiques":
                    MesMusiques(sender, e);
                    break;

                case "ItemRetour":
                    Retour(sender, e);
                    break;
            }
        }
        ///////////////////////////////////////////////////////////////////////



        // BOUTON SE DECONNECTER //
        //////////////////////////////////////////////////////////////////////////
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
        //////////////////////////////////////////////////////////////////////////


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



        // BOUTON CREER PLAYLIST //
        //////////////////////////////////////////////////////////////////////////
        private void Playlist(object sender, RoutedEventArgs e)
        {
            CreationPlaylist CreationPlaylist = new CreationPlaylist();
            CreationPlaylist.Show();
            this.Close();
        }
        //////////////////////////////////////////////////////////////////////////



        // AFFICHER BOUTON SUPPRIMER //
        //////////////////////////////////////////////////////////////////////////
        private void AfficherBouton(object sender, RoutedEventArgs e)
        {
            int cpt = list.Items.Count;
            if (list.SelectedIndex >= 0 && list.SelectedIndex < cpt)
            {
                DeleteButton.Visibility = Visibility.Visible;
            }
        }
        //////////////////////////////////////////////////////////////////////////



        // BOUTON SUPPRIMER PLAYLIST //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Supprimer(object sender, RoutedEventArgs e)
        {
            int i = list.SelectedIndex;
            string nom = GetListePlaylist()[i].Nom;
            if (MessageBox.Show("Voulez-vous supprimer la playlist '" + nom + "'!", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DeletePlaylist(i);
                ICollectionView view = CollectionViewSource.GetDefaultView(list.ItemsSource);
                view.Refresh();
                Utilisateur Utilisateur = new Utilisateur();
                using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM UserPlaylist WHERE UserName = @UserName and NamePlaylist = @NamePlaylist", sqlCon); // On créé une commande qui supprime une playlist //
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NamePlaylist", nom); // Cette procédure prend en paramètre le nom de la playlist //
                    cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName()); // Et aussi l'identifiant de l'utilisateur //
                    cmd.ExecuteNonQuery(); // Exécute la procédure //
                    DeleteButton.Visibility = Visibility.Hidden;
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // CLICK ITEM LIST PLAYLIST ---> REDIRECTION VERS MEDIA PLAYER //
        //////////////////////////////////////////////////////////////////////////////
        private void Page_Playlist(object sender, RoutedEventArgs e)
        { 
            if(list.SelectedItem != null)
            {
                var Playlist = list.SelectedItem as Playlist;
                MLGcustomPlayer MLGcustomPlayer = new MLGcustomPlayer(Playlist);
                MLGcustomPlayer.Show();
                this.Close();
            }
        }
        //////////////////////////////////////////////////////////////////////////////
    }
}