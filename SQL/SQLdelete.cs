using System.Data;
using System.Data.SqlClient;


namespace SQL
{
    public class SQLdelete
    {
        private SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-5SACIKC,49172; Initial Catalog=DataBaseProject;Integrated Security=True");  // String de connexion stocké dans app.config de WpfApplication1 //



        /// <summary>
        /// Suppression playlist dans CreationPlaylist lorsqu'on quitte sur la croix X ou bouton retour
        /// </summary>
        public int DeletePlaylist()
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("DeleteUserPlaylist", sqlCon); // on appelle la procédure stockée "DeleteUserPlaylist", supprimant toutes les musiques qui ne possède pas de nom de playlist //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery(); // Exécute la procédure //
                return 1;
            }
        }



        /// <summary>
        /// Suppression playlist dans MesPlaylists
        /// </summary>
        /// <param name="nom"></param>
        public int SupprimerPlaylist(string username, string nom)
        {
            using (sqlCon)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("DeletePlaylist", sqlCon); // On créé une commande qui supprime une playlist //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NamePlaylist", nom); // Cette procédure prend en paramètre le nom de la playlist //
                cmd.Parameters.AddWithValue("@UserName", username); // Et aussi l'identifiant de l'utilisateur //
                cmd.ExecuteNonQuery(); // Exécute la procédure //
                return 1;
            }
        }
    }
}
