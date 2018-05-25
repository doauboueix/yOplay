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
        private void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
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
        private void Clear()
        {
            Nom.Text = Prenom.Text = Login.Text = Mdp.Password = "";
        }
    }
}
