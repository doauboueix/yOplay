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
            EMusique.Add(new Musique(2.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/God'sPlan.jpg", "God's Plan", "Drake", "Scorpion", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\God'sPlan.wav"));
            EMusique.Add(new Musique(1.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/Rockstar.jpg", "Rockstar", "Post Malone & 21 Savage", "", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\Rockstar.wav"));
            EMusique.Add(new Musique(1.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/Friends.jpg", "Friends", "Marshmello & Anne-Marie", "Speak your Mind", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\Friends.wav"));
            EMusique.Add(new Musique(3.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/SafariSong.jpg", "Safari Song", "Greta Van Fleet", "", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\SafariSong.wav"));
            EMusique.Add(new Musique(3.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/Havana.jpg", "Havana", "Camila Cabello", "Camila", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\Havana.wav"));
            EMusique.Add(new Musique(0.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/King'sDead.jpg", "King's Dead", "Jay Rock & Kendrick Lamar & Future", "Black Panther", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\King'sDead.wav"));
            EMusique.Add(new Musique(2.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/Lullaby.jpg", "Lullaby", "R3HAB & Mike Williams", "", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\Lullaby.wav"));
            EMusique.Add(new Musique(1.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/RedColdRiver.jpg", "Red Cold River", "Breaking Benjamin", "Ember", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\RedColdRiver.wav"));
            EMusique.Add(new Musique(1.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/IDGAF.jpg", "IDGAF", "Dua Lipa", "Dua Lipa", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\IDGAF.wav"));
            EMusique.Add(new Musique(0.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/LookAlive.jpg", "Look Alive", "BlocBoy JB & Drake", "", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\LookAlive.wav"));
            EMusique.Add(new Musique(3.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/ColdAsStone.jpg", "Cold as Stone", "Kaskade & Charlotte Lawrence", "", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\ColdAsStone.wav"));
            EMusique.Add(new Musique(1.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/TheMountain.jpg", "The Mountain", "Three Days Grace", "Outsider", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\TheMountain.wav"));
            EMusique.Add(new Musique(0.99M, "Pop", "pack://application:,,,/WpfApplication1;component/adds/Musique/Delicate.jpg", "Delicate", "Taylor Swift", "reputation", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\Delicate.wav"));
            EMusique.Add(new Musique(1.99M, "Rap", "pack://application:,,,/WpfApplication1;component/adds/Musique/AllTheStars.jpg", "All the Stars", "Kendrick Lamar & SZA", "Black Panther", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\AllTheStars.wav"));
            EMusique.Add(new Musique(0.99M, "Electro", "pack://application:,,,/WpfApplication1;component/adds/Musique/LikeIDo.jpg", "Like I do", "David Guetta & Martin Garrix & Brooks", "", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\LikeIDo.wav"));
            EMusique.Add(new Musique(2.99M, "Rock", "pack://application:,,,/WpfApplication1;component/adds/Musique/Disillusioned.jpg", "Disillusioned", "A Perfect Circle", "Eat the Elephant", @"C:\Users\doauboueix\Desktop\yoplay\WpfApplication1\adds\Media\Disillusioned.wav"));
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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = MenuFilter;
        }
        private bool MenuFilter(object item)
        {
            return ((item as Musique).Genre.IndexOf(Button.Content.ToString(), StringComparison.OrdinalIgnoreCase) != 0);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "POP" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Pop(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = MenuFilter1;
        }
        private bool MenuFilter1(object item)
        {
            return ((item as Musique).Genre.IndexOf(Button1.Content.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "RAP" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Rap(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = MenuFilter2;
        }
        private bool MenuFilter2(object item)
        {
            return ((item as Musique).Genre.IndexOf(Button2.Content.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "ELECTRO" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Electro(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = MenuFilter3;
        }
        private bool MenuFilter3(object item)
        {
            return ((item as Musique).Genre.IndexOf(Button3.Content.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // GENRE "ROCK" !!! //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Menu_Rock(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = MenuFilter4;
        }
        private bool MenuFilter4(object item)
        {
            return ((item as Musique).Genre.IndexOf(Button4.Content.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
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
