using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using ClassLibrary;
using System.Linq;
using SQL;

namespace WpfApplication1
{
    public partial class Musiques : Window
    {
        public List<Musique> EMusique { get; set; } = new List<Musique>();
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public Musiques()
        {
            InitializeComponent();
            Utilisateur Utilisateur = new Utilisateur();
            NomPrenom.Text = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
            Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
            DataContext = this;
            EMusique.Add(new Musique(2.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/God'sPlan.jpg", "God's Plan", "Drake", "Scorpion", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\God'sPlan.wav"));
            EMusique.Add(new Musique(1.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/Rockstar.jpg", "Rockstar", "Post Malone & 21 Savage", "", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\Rockstar.wav"));
            EMusique.Add(new Musique(1.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/Friends.jpg", "Friends", "Marshmello & Anne-Marie", "Speak your Mind", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\Friends.wav"));
            EMusique.Add(new Musique(3.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/SafariSong.jpg", "Safari Song", "Greta Van Fleet", "", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\SafariSong.wav"));
            EMusique.Add(new Musique(3.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/Havana.jpg", "Havana", "Camila Cabello", "Camila", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\Havana.wav"));
            EMusique.Add(new Musique(0.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/King'sDead.jpg", "King's Dead", "Jay Rock & Kendrick Lamar & Future", "Black Panther", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\King'sDead.wav"));
            EMusique.Add(new Musique(2.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/Lullaby.jpg", "Lullaby", "R3HAB & Mike Williams", "", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\Lullaby.wav"));
            EMusique.Add(new Musique(1.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/RedColdRiver.jpg", "Red Cold River", "Breaking Benjamin", "Ember", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\RedColdRiver.wav"));
            EMusique.Add(new Musique(1.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/IDGAF.jpg", "IDGAF", "Dua Lipa", "Dua Lipa", @"C:\Users\nathan\Desktop\yoplay\WpfApplication1\adds\Media\IDGAF.wav"));
            EMusique.Add(new Musique(0.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/LookAlive.jpg", "Look Alive", "BlocBoy JB & Drake", "", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\LookAlive.wav"));
            EMusique.Add(new Musique(3.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/ColdAsStone.jpg", "Cold as Stone", "Kaskade & Charlotte Lawrence", "", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\ColdAsStone.wav"));
            EMusique.Add(new Musique(1.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/TheMountain.jpg", "The Mountain", "Three Days Grace", "Outsider", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\TheMountain.wav"));
            EMusique.Add(new Musique(0.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/Delicate.jpg", "Delicate", "Taylor Swift", "reputation", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\Delicate.wav"));
            EMusique.Add(new Musique(1.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/AllTheStars.jpg", "All the Stars", "Kendrick Lamar & SZA", "Black Panther", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\AllTheStars.wav"));
            EMusique.Add(new Musique(0.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/LikeIDo.jpg", "Like I do", "David Guetta & Martin Garrix & Brooks", "", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\LikeIDo.wav"));
            EMusique.Add(new Musique(2.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/Disillusioned.jpg", "Disillusioned", "A Perfect Circle", "Eat the Elephant", @"C:\Users\Nathan\Desktop\yoplay\WpfApplication1\adds\Media\Disillusioned.wav"));
            list.ItemsSource = EMusique;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = UserFilter;
        }

        // BARRE DE RECHERCHE !!! //
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Musique).Titre.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Musique).Auteur.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Musique).Album.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Musique).Genre.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Musique).Prix.ToString().IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(list.ItemsSource).Refresh();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // TRI PAR COLONNE !!! //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Column_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Content.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                list.Items.SortDescriptions.Clear();
            }
            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;


            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            list.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        // CLASS SORTADORNER //
        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                    Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                    Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                    : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                        (
                                AdornedElement.RenderSize.Width - 15,
                                (AdornedElement.RenderSize.Height - 5) / 2
                        );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "TOUT" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Tout(object sender, RoutedEventArgs e)
        {
            list.ItemsSource = EMusique;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "POP" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Pop(object sender, RoutedEventArgs e)
        {
            List<Musique> Pop = EMusique.Where(musique => musique.Genre == "Pop").ToList();
            list.ItemsSource = Pop;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "RAP" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Rap(object sender, RoutedEventArgs e)
        {
            List<Musique> Rap = EMusique.Where(musique => musique.Genre == "Rap").ToList();
            list.ItemsSource = Rap;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "ELECTRO" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Electro(object sender, RoutedEventArgs e)
        {
            List<Musique> Electro = EMusique.Where(musique => musique.Genre == "Electro").ToList();
            list.ItemsSource = Electro;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "ROCK" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Rock(object sender, RoutedEventArgs e)
        {
            List<Musique> Rock = EMusique.Where(musique => musique.Genre == "Rock").ToList();
            list.ItemsSource = Rock;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // DOUBLE CLIQUE SUR ITEM LIST ----> REDIRECTION SUR MUSIQUES_PAGE !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject originalSource = (DependencyObject)e.OriginalSource;
            while ((originalSource != null) && !(originalSource is ListViewItem))
            {
                originalSource = VisualTreeHelper.GetParent(originalSource);
            }
            if (originalSource != null)
            {
                var Musique = list.SelectedItem as Musique;
                var titre = Musique.Titre;
                var auteur = Musique.Auteur;
                var prix = Musique.Prix;
                var genre = Musique.Genre;
                var source = Musique.Source;
                var album = Musique.Album;
                var player = Musique.Player;

                Musiques_Page Musiques_Page = new Musiques_Page(prix, genre, source, titre, auteur, album, player);
                Musiques_Page.Show();
                this.Close();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////?



        // MENU MATERIAL DESIGN !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            this.Close();
        }
        private void MesPlaylists(object sender, RoutedEventArgs e)
        {
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
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
                case "ItemSearch":
                    ItemSearch.Visibility = Visibility.Collapsed;
                    ItemSearchBar.Visibility = Visibility.Visible;
                    break;
                case "ItemSearchBar":
                    ItemSearchBar.Visibility = Visibility.Collapsed;
                    ItemSearch.Visibility = Visibility.Visible;
                    txtFilter.Clear();
                    break;
                case "ItemMesPlaylists":
                    MesPlaylists(sender, e);
                    break;
                case "ItemMesMusiques":
                    MesMusiques(sender, e);
                    break;
                case "ItemGenreON":
                    ItemGenreON.Visibility = Visibility.Collapsed;
                    ItemGenreOFF.Visibility = Visibility.Visible;
                    if (stackP.Visibility == Visibility.Hidden)
                    {
                        stackP.Visibility = Visibility.Visible;
                    }
                    break;
                case "ItemGenreOFF":
                    ItemGenreOFF.Visibility = Visibility.Collapsed;
                    ItemGenreON.Visibility = Visibility.Visible;
                    if (stackP.Visibility == Visibility.Visible)
                    {
                        stackP.Visibility = Visibility.Hidden;
                    }
                    break;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////



        // MENU COMPTE UTILISATEUR !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////



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
                SQLupdate SQLupdate = new SQLupdate();
                SQLupdate.UpdateSolde();

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
