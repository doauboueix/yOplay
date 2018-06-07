using System.Data;
using System.Data.SqlClient;

namespace SQL
{
    public class SQLupdate
    {
        private SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-5SACIKC,49172; Initial Catalog=DataBaseProject;Integrated Security=True");

        /// <summary>
        /// Met à jour le solde de l'utilisateur en cours
        /// </summary>
        public int UpdateSolde(string username, decimal solde)
        {
            using (sqlCon)
            { 
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UpdateSolde", sqlCon); // créé une commande qui modifie le solde de l'utilisateur actuel //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Solde", solde); // cette commande prend en paramètre le solde de l'utilisateur //
                cmd.Parameters.AddWithValue("@UserName", username); // elle doit donc récupérer le UserName de celui-ci //
                cmd.ExecuteNonQuery(); // Exécute la procédure //
                return 1;
            }
        }



        /// <summary>
        /// Ajout musique dans la table UserPlaylist
        /// </summary>
        /// <param name="NameSong"></param>
        public int AjouterPlaylist(string username, string NameSong)
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("EnregistrementPlaylist", sqlCon); // on appelle la procédure stockée "EnregistrementPlaylist, qui ajoute une musique dans la table UserPlaylist (sans nom de playlist pour le moment //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameSong", NameSong); // on récupère le nom de la musique //
                cmd.Parameters.AddWithValue("@NamePlaylist", ""); // on ne possède pas encore le nom de la playlist, nous l'ajouterons quand on cliquera sur le bouton "Creer" //
                cmd.Parameters.AddWithValue("@UserName", username); // on récupère le nom d'utilisateur //
                cmd.ExecuteNonQuery(); // Exécute la procédure //
                return 1;
            }
        }



        /// <summary>
        /// Ajoute le nom de la playlist à la liste de musique qui constitue la playlist en cours de création
        /// </summary>
        /// <param name="NamePlaylist"></param>
        public int UpdatePlaylist(string NamePlaylist)
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UpdatePlaylist", sqlCon); // on update la table UserPlaylist, en remplacant le nom de playlist par toutes les musiques qui n'en possèdent pas //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NamePlaylist", NamePlaylist); // on récupère le nom de playlist //
                cmd.ExecuteNonQuery(); // Exécute la procédure //
                return 1;
            }
        }



        /// <summary>
        /// Achat Film
        /// </summary>
        /// <param name="NomFilm"></param>
        /// <param name="Prix"></param>
        public int AchatFilm(string username, string NomFilm, decimal Prix)
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("ReduceSolde", sqlCon); // On créé une commande qui réduit le solde de l'utilisateur connecté //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Prix", Prix); // Cette procédure prend en paramètre le prix du film acheté //
                cmd.Parameters.AddWithValue("@UserName", username); // Et aussi l'identifiant de l'utilisateur //
                cmd.ExecuteNonQuery(); // Exécute la procédure //

                SqlCommand cmd2 = new SqlCommand("AchatFilm", sqlCon); // On appelle la procédure stockée AchatFilm qui ajoute le nom d'un film + l'identifiant de l'utilisateur actuel //
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Nom", NomFilm); // Cette procédure prend en paramètre le nom du film acheté //
                cmd2.Parameters.AddWithValue("@UserName", username); // Et aussi l'identifiant de l'utilisateur //
                cmd2.ExecuteNonQuery(); // On exécute la procédure //
                return 1;
            }
        }



        /// <summary>
        /// Créé un utilisateur dans la table UserTable
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Prenom"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        public void Inscription(string Nom, string Prenom, string UserName, string Password)
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Inscription", sqlCon); // on appelle la procédure stockée "Inscription" qui créé un nouvel utilisateur //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom", Nom);
                cmd.Parameters.AddWithValue("@Prenom", Prenom);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Solde", 0);
                cmd.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Achat musique
        /// </summary>
        /// <param name="Prix"></param>
        /// <param name="Nom"></param>
        public int AcheterMusique(string username, decimal Prix, string Nom)
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("ReduceSolde", sqlCon); // On créé une commande qui réduit le solde de l'utilisateur connecté //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Prix", Prix); // Cette procédure prend en paramètre le prix de la musique achetée //
                cmd.Parameters.AddWithValue("@UserName", username); // Et aussi l'identifiant de l'utilisateur //
                cmd.ExecuteNonQuery(); // Exécute la procédure //

                SqlCommand cmd2 = new SqlCommand("AchatMusique", sqlCon); // On appelle la procédure stockée AchatMusique qui ajoute le nom d'un film + l'identifiant de l'utilisateur actuel //
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Name", Nom); // Cette procédure prend en paramètre le nom de la musique achetée //
                cmd2.Parameters.AddWithValue("@Username", username); // Et aussi l'identifiant de l'utilisateur //
                cmd2.ExecuteNonQuery(); // Exécute la procédure //
                return 1;
            }
        }
    }
}
