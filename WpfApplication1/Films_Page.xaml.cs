using ClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SQL;

namespace WpfApplication1
{
    public partial class Films_Page : Window
    {
        private Film film;
        private decimal Prix;
        public Films_Page(String source, String nom, String realisateur, String genre, decimal prix, String description, String note)
        {
            InitializeComponent();
            image1.Source = new BitmapImage(new Uri(source));
            label1.Content = nom;
            label2.Content = realisateur;
            label3.Content = genre;
            image2.Source = new BitmapImage(new Uri(note));
            label4.Content = description;
            label5.Content = prix + "€";
            Prix = prix;
            film = new Film(Prix, label3.Content.ToString(), image1.Source.ToString(), label1.Content.ToString(), label2.Content.ToString(), label4.Content.ToString(), image2.Source.ToString());
            MesFilms page = new MesFilms();
            int index = page.GetList().FindIndex(item => item.Nom == label1.Content.ToString()); // on regarde si le film a déja été acheté, via un index //
            if (index >= 0) // si l'index est supérieur à 0, cela veut dire qu'il a déja été acheté //
            {
                Buy_Button.Content = "ACQUIS";
                Buy_Button.Background = new SolidColorBrush(Colors.Green);
                Buy_Button.Foreground = new SolidColorBrush(Colors.White);
            }
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
        /// Bouton Retour renvoyant vers la page Films
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour(object sender, RoutedEventArgs e)
        {
            Films Films = new Films();
            Films.Show();
            this.Close();
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
        /// Bouton Mes Films renvoyant vers la page MesFilms 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MesFilms(object sender, RoutedEventArgs e)
        {
            MesFilms MesFilms = new MesFilms();
            MesFilms.Show();
            this.Close();
        }



        /// <summary>
        ///  Regroupe toutes les methodes du menu Material Design ( car ils sont dans une ListView donc obligation de passer par un switch / case )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                case "ItemMesFilms":
                    MesFilms(sender, e);
                    break;
            }
        }



        /// <summary>
        /// Bouton Acheter qui achète le film affiché 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acheter(object sender, RoutedEventArgs e)
        {
            if (Buy_Button.Content.ToString() == "ACHETER")
                if (MessageBox.Show("Voulez-vous acheter ce film?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
                    if (Utilisateur.GetSolde() >= Prix) // si le solde de l'utilisateur est supérieur ou égal au prix du film //
                    {
                        Utilisateur.ReduireSolde(Prix); // alors on réduit le solde de celui-ci par le prix du film //
                        Buy_Button.Content = "ACQUIS";
                        Buy_Button.Background = new SolidColorBrush(Colors.Green);
                        Buy_Button.Foreground = new SolidColorBrush(Colors.White);
                        MesFilms MesFilms = new MesFilms();
                        MesFilms.SetList(film);
                        SQLupdate achat = new SQLupdate();
                        achat.AchatFilm(Utilisateur.GetUserName(),label1.Content.ToString(), Prix);
                    }
                    else
                        MessageBox.Show("Fonds insuffisants, veuillez garnir votre solde !", "Erreur"); // si le solde est inférieur au prix, on affiche un message exprimant le fait que l'utilisateur n'a pas les fonds nécessaires //
                }
        }
    }
}