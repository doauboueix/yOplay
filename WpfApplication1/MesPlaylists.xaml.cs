using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SQL;

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
            Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
            SQLselect SQLselect = new SQLselect();
            LoadingPlaylists = SQLselect.ChargementPlaylist(Utilisateur.GetUserName());

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
            UC.OnClosed += UCtitre_OnClosed;
            UC.OnSolded += UCtitre_OnSolded;
        }



        /// <summary>
        /// Méthode utilisée pour l'évênement OnClosed du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCtitre_OnClosed(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Méthode utilisée pour l'évênement OnSolded du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCtitre_OnSolded(object sender, EventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Méthode GET de ListePlaylist
        /// </summary>
        /// <returns> ListePlaylist </returns>
        public List<Playlist> GetListePlaylist()
        {
            return ListePlaylist;
        }



        /// <summary>
        /// Méthode SET de ListePlaylist
        /// </summary>
        /// <param name="p"></param>
        public void SetPlaylist(Playlist p)
        {
            ListePlaylist.Add(p);
        }



        /// <summary>
        /// Supprime une playlist dans ListPlaylist à l'index p
        /// </summary>
        /// <param name="p"></param>
        public void DeletePlaylist(int p)
        {
            ListePlaylist.RemoveAt(p);
        }



        /// <summary>
        /// Bouton Accueil renvoyant vers la page Accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            this.Close();
        }



        /// <summary>
        /// Bouton Mes Musiques renvoyant vers la page MesMusiques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MesMusiques(object sender, RoutedEventArgs e)
        {
            MesMusiques MesMusiques = new MesMusiques();
            MesMusiques.Show();
            this.Close();
        }



        /// <summary>
        /// Bouton Retour renvoyant vers la page Musiques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            this.Close();
        }



        /// <summary>
        /// Ouvre le menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }



        /// <summary>
        /// Ferme le menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Regroupe toutes les methodes du menu Material Design ( car ils sont dans une ListView donc obligation de passer par un switch / case )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Bouton Valider de l'InputBox
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
                MessageBox.Show("Format valide (Entiers uniquement) !", "Erreur format"); // on affiche un message indiquant que le format n'est pas respecté //
                InputTextBox.Text = String.Empty; // on réinitialise le contenu de la textbox //
            }
            else
            {
                Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
                Utilisateur.AjouterSolde(Convert.ToDecimal(input));
                UC.Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                SQLupdate SQLupdate = new SQLupdate();
                SQLupdate.UpdateSolde(Utilisateur.GetUserName(), Convert.ToDecimal(input));

                InputBox.Visibility = Visibility.Collapsed;
                InputTextBox.Text = String.Empty;
            }
        }



        /// <summary>
        /// Bouton Annuler de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }



        /// <summary>
        /// Bouton Créer Playlist renvoyant vers la page CreationPlaylist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Playlist(object sender, RoutedEventArgs e)
        {
            CreationPlaylist CreationPlaylist = new CreationPlaylist();
            CreationPlaylist.Show();
            this.Close();
        }



        /// <summary>
        /// Lorsqu'un item de la liste de playlist est séléctionné, affichage du bouton supprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfficherBouton(object sender, RoutedEventArgs e)
        {
            int cpt = list.Items.Count;
            if (list.SelectedIndex >= 0 && list.SelectedIndex < cpt)
            {
                DeleteButton.Visibility = Visibility.Visible;
            }
        }



        /// <summary>
        /// Supprimer la playlist séléctionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer(object sender, RoutedEventArgs e)
        {
            Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
            int i = list.SelectedIndex;
            string nom = GetListePlaylist()[i].Nom;
            if (MessageBox.Show("Voulez-vous supprimer la playlist '" + nom + "'!", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DeletePlaylist(i);
                ICollectionView view = CollectionViewSource.GetDefaultView(list.ItemsSource);
                view.Refresh();
                SQLdelete SQLdelete = new SQLdelete();
                SQLdelete.SupprimerPlaylist(Utilisateur.GetUserName() ,nom);
                DeleteButton.Visibility = Visibility.Hidden;
            }
        }



        /// <summary>
        /// Double clique sur un item de la liste de playlist --> Redirection vers le Media Player qui permet de jouer cette playlist 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Playlist(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                var Playlist = list.SelectedItem as Playlist;
                MLGcustomPlayer MLGcustomPlayer = new MLGcustomPlayer(Playlist);
                MLGcustomPlayer.Show();
                this.Close();
            }
        }
    }
}