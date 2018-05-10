using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApplication1
{
    public partial class Inscription : Window
    {
        string connectionString = @" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;";
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
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Inscription", sqlCon); // on appelle la procédure stockée "Inscription" qui créé un nouvel utilisateur //
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nom", Nom.Text.Trim());
                    cmd.Parameters.AddWithValue("@Prenom", Prenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserName", Login.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", Mdp.Password.Trim());
                    cmd.Parameters.AddWithValue("@Solde", 0);
                    cmd.ExecuteNonQuery();
                    Clear();
                    MessageBox.Show("Inscription réussie!", "Inscription");
                }
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
