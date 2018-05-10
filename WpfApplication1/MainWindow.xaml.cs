using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
            string connectionString = @" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;";
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM UserTable WHERE UserName=@UserName AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon); // on regarde si il existe un utilisatuer possédant l'identifiant et le pseudo renseignés //
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UserName", login.Text);
                sqlCmd.Parameters.AddWithValue("@Password", mdp.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar()); // on convertit le résultat de cette commande par un entier //
                if (count == 1) // si il est égal à 1, la connexion a réussit //
                {
                    Utilisateur Utilisateur = new Utilisateur();
                    Utilisateur.SetUserName(login.Text);  // On stocke l'Identifiant connecté dans une variable //
                    String query2 = "SELECT Nom,Prenom,Solde FROM UserTable WHERE UserName=@Identifiant";
                    sqlCmd = new SqlCommand(query2, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Identifiant", Utilisateur.GetUserName());
                    sqlCmd.ExecuteNonQuery(); // Execute la procédure //
                    SqlDataReader reader = sqlCmd.ExecuteReader(); // on créé un reader qui va pouvoir lire les données SQL //
                    while (reader.Read())
                    {
                        Utilisateur.SetNom((string)reader[0]); // Recupere le Nom //
                        Utilisateur.SetPrenom((string)reader[1]); // Recupere le Prenom //
                        Utilisateur.SetSolde((decimal)reader[2]); // Recupere le Solde //
                    }
                    reader.Close(); // on ferme le reader une fois l'action terminée //

                    Accueil Accueil = new Accueil();
                    Accueil.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect!", "Erreur");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

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
