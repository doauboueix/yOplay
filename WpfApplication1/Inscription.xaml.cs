using System.Windows;
using SQL;

namespace WpfApplication1
{
    public partial class Inscription : Window
    {
        public Inscription()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Bouton Retour renvoyant vers la page de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }



        /// <summary>
        /// Bouton Créer, qui ajoute un nouvel utilisatuer dans la base de donnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreationCompte(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Mdp.Password == "" || Nom.Text == "" || Prenom.Text == "") // les champs obligatoires doivent être renseignés //
            {
                MessageBox.Show("Des champs obligatoires sont vides!", "Erreur");
            }
            else if (Mdp.Password != MdpConfirm.Password) // les mots de passe doivent concorder //
            {
                MessageBox.Show("Les mots de passe sont différents!", "Erreur");
            }
            else
            {
                SQLupdate SQLupdate = new SQLupdate();
                SQLupdate.Inscription(Nom.Text.Trim(), Prenom.Text.Trim(), Login.Text.Trim(), Mdp.Password.Trim());
                Clear();
                MessageBox.Show("Inscription réussie!", "Inscription");
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();
            }
        }



        /// <summary>
        /// Réinitialise le contenu des textboxs
        /// </summary>
        private void Clear()
        {
            Nom.Text = Prenom.Text = Login.Text = Mdp.Password = "";
        }
    }
}
