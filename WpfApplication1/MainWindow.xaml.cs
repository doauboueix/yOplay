using System.Windows;
using SQL;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Bouton Connexion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connexion(object sender, RoutedEventArgs e)
        {
            SQLselect SQLselect = new SQLselect();
            int i = SQLselect.SQLConnexion(login.Text, mdp.Password);
            if (i == 1)
            {
                Accueil Accueil = new Accueil();
                Accueil.Show();
                this.Close();

            }
            else
                MessageBox.Show("Identifiant ou mot de passe incorrect", "Erreur");
        }



        /// <summary>
        /// Label Inscription renvoyant vers la page d'inscription d'un nouvel utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inscription(object sender, RoutedEventArgs e)
        {
            Inscription Inscription = new Inscription();
            Inscription.Show();
            this.Close();
        }
    }
}
