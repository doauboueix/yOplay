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



        // CONNEXION //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Connexion(object sender, RoutedEventArgs e)
        {
            SQLselect SQLselect = new SQL.SQLselect();
            int i = SQLselect.SQLConnexion(login.Text, mdp.Password);
            if (i == 1)
            {
                Accueil Accueil = new Accueil();
                Accueil.Show();
                this.Show();
            }
            else
                MessageBox.Show("Identifiant ou mot de passe incorrect", "Erreur");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // REDIRECTION VERS INSCRIPTION //
        ///////////////////////////////////////////////////////////////
        private void Inscription(object sender, RoutedEventArgs e)
        {
            Inscription Inscription = new Inscription();
            Inscription.Show();
            this.Close();
        }
        ///////////////////////////////////////////////////////////////
    }
}
