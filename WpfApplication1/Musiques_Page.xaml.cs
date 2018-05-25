using ClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SQL;

namespace WpfApplication1
{
    public partial class Musiques_Page : Window
    {

        private Musique musique;
        private decimal Prix;
        public Musiques_Page(decimal prix, string genre, string source, string titre, string auteur, string album, string player)
        {
            InitializeComponent();
            Prix = prix;
            label1.Content = titre;
            image1.Source = new BitmapImage(new Uri(source));
            label2.Content = auteur;
            if (album == "")
                label3.Content = "Single";
            else
                label3.Content = "Album : " + album;
            label4.Content = genre;
            label5.Content = prix + "€";
            String Player = player;
            musique = new Musique(label5.Content.GetHashCode(), label4.Content.ToString(), image1.Source.ToString(), label1.Content.ToString(), label2.Content.ToString(), label3.Content.ToString(), Player);
            MesMusiques MesMusiques = new MesMusiques();
            int index = MesMusiques.GetList().FindIndex(item => item.Titre == label1.Content.ToString()); // on regarde si la musique a déja été achetée, via un index //
            if (index >= 0) // si l'index est supérieur ou égal à 0, cela veut dire qu'elle a déja été achetée //
            {
                Buy_Button.Content = "ACQUIS";
                Buy_Button.Background = new SolidColorBrush(Colors.Green);
                Buy_Button.Foreground = new SolidColorBrush(Colors.White);
            }
        }



        // MENU //
        /////////////////////////////////////////////////////////////////////////////////
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
        private void Retour(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            this.Close();
        }
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
                case "ItemMesPlaylists":
                    MesPlaylists(sender, e);
                    break;
                case "ItemMesMusiques":
                    MesMusiques(sender, e);
                    break;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////



        // ACHAT MUSIQUE //
        /////////////////////////////////////////////////////////////////////////////////
        private void Acheter(object sender, RoutedEventArgs e)
        {
            if (Buy_Button.Content.ToString() == "ACHETER")
                if (MessageBox.Show("Voulez-vous acheter cette musiques?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Utilisateur Utilisateur = new Utilisateur();
                    if (Utilisateur.GetSolde() >= Prix) // si le solde de l'utilisateur est supérieur ou égal au prix de la musique //
                    {
                        Utilisateur.ReduireSolde(Prix); // alors on réduit le solde de celui-ci par le prix de la musique //
                        Buy_Button.Content = "ACQUIS";
                        Buy_Button.Background = new SolidColorBrush(Colors.Green);
                        Buy_Button.Foreground = new SolidColorBrush(Colors.White);
                        MesMusiques MesMusiques = new MesMusiques();
                        MesMusiques.SetList(musique);
                        SQLupdate SQLupdate = new SQLupdate();
                        SQLupdate.AcheterMusique(Prix, label1.Content.ToString());
                    }
                    else
                        MessageBox.Show("Fonds insuffisants, veuillez garnir votre solde !", "Erreur"); // si le solde est inférieur au prix, on affiche un message exprimant le fait que l'utilisateur n'a pas les fonds nécessaires //
                }
        }
        /////////////////////////////////////////////////////////////////////////////////
    }
}
