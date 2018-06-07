using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;

namespace SQL
{
    public class SQLselect
    {
        private SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-5SACIKC,49172; Initial Catalog=DataBaseProject;Integrated Security=True");


        /// <summary>
        /// Connexion dans MainWindow
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns> 1 si la connexion a résussi, 0 sinon </returns>
        public int SQLConnexion(string login, string password)
        {
            using (sqlCon)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("CheckConnexion", sqlCon); // on regarde si il existe un utilisatuer possédant l'identifiant et le pseudo renseignés //
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", login);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar()); // on convertit le résultat de cette commande par un entier //
                if (count == 1) // si il est égal à 1, la connexion a réussit //
                {
                    Utilisateur Utilisateur = new Utilisateur();
                    Utilisateur.SetUserName(login);  // On stocke l'Identifiant connecté dans une variable //
                    sqlCmd = new SqlCommand("GetUserInfos", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
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
                    Utilisateur.CurrentUtilisateur = Utilisateur;
                    return 1;
                }
                else
                    return 0;
            }
        }



        /// <summary>
        /// Chargement des Films que l'utilisateur possède dans MesFikms
        /// </summary>
        /// <returns> mesFilms</returns>
        public List<string> ChargementMesFilms(string username)
        {
            using (sqlCon)
            {
                List<string> mesFilms = new List<string>();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("ChargementMesFilms", sqlCon); // Appelle la procédure stockée ChargementMesFilms qui recupère le nom de tous les films pour l'utilisateur en cours //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username); // Cette procédure prend en paramètre l'identifiant de l'utilisateur en cours que l'on récupère au moment de la connexion (lorsque celle-ci réussit) //
                cmd.ExecuteNonQuery(); // Execute la procédure //
                SqlDataReader reader = cmd.ExecuteReader(); // on créé un reader capable de lire des données SQL //
                while (reader.Read()) // Tant que ce reader lit des données on éxécute le code ci-dessous //
                {
                    mesFilms.Add((string)reader[0]); // Ajoute dans la liste mesFilms tous les noms de films possédés par l'utilisateur actuel //
                }
                reader.Close();
                return mesFilms;
            }
        }



        /// <summary>
        /// Chargement des musiques que l'utilisateur possède dans MesMusiques
        /// </summary>
        /// <returns> mesMusiques </returns>
        public List<string> ChargementMesMusiques(string username)
        {
            using (sqlCon)
            {
                List<string> mesMusiques = new List<string>();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("ChargementMesMusiques", sqlCon); // Appelle la procédure stockée ChargementMesMusiques qui recupère le nom de tous les films pour l'utilisateur en cours //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);  // Cette procédure prend en paramètre l'identifiant de l'utilisateur en cours que l'on récupère au moment de la connexion (lorsque celle-ci réussit) //
                cmd.ExecuteNonQuery(); // Execute la procédure //
                SqlDataReader reader = cmd.ExecuteReader(); // on créé un reader capable de lire des données SQL //
                while (reader.Read()) // Tant que ce reader lit des données on éxécute le code ci-dessous //
                {
                    mesMusiques.Add((string)reader[0]); // Ajoute dans la liste mesMusiques tous les noms de musique possédés par l'utilisateur actuel //
                }
                reader.Close();
                return mesMusiques;
            }
        }



        /// <summary>
        /// Chargement des playlists créées par l'utilisateurs dans MesPlaylists 
        /// </summary>
        /// <returns> LoadingPlaylists </returns>
        public List<ListPlaylists> ChargementPlaylist(string username)
        {
            using (sqlCon)
            {
                List<ListPlaylists> LoadingPlaylists = new List<ListPlaylists>();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("LoadListPlaylist", sqlCon); // Appelle la procédure stockée ChargementMesMusiques qui recupère le nom de tous les films pour l'utilisateur en cours //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);  // Cette procédure prend en paramètre l'identifiant de l'utilisateur en cours que l'on récupère au moment de la connexion (lorsque celle-ci réussit) //
                cmd.ExecuteNonQuery(); // Execute la procédure //
                SqlDataReader reader = cmd.ExecuteReader(); // on créé un reader capable de lire des données SQL //
                while (reader.Read()) // Tant que ce reader lit des données on éxécute le code ci-dessous //
                {
                    LoadingPlaylists.Add(new ListPlaylists((string)reader[0], (string)reader[1])); // Ajoute dans la liste mesMusiques tous les noms de musique possédés par l'utilisateur actuel //
                }
                reader.Close();
                return LoadingPlaylists;
            }
        }
    }
}
