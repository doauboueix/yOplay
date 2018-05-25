using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;


namespace SQL
{
    public class SQLdelete
    {
        private SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLserver"].ConnectionString);
        
        public void DeletePlaylist()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLserver"].ConnectionString))
            {
                Utilisateur Utilisateur = new Utilisateur();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("DeleteUserPlaylist", sqlCon); // on appelle la procédure stockée "DeleteUserPlaylist", supprimant toutes les musiques qui ne possède pas de nom de playlist //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery(); // Exécute la procédure //
            }
        }

        public void SupprimerPlaylist(string nom)
        {
            using (sqlCon)
            {
                Utilisateur Utilisateur = new Utilisateur();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM UserPlaylist WHERE UserName = @UserName and NamePlaylist = @NamePlaylist", sqlCon); // On créé une commande qui supprime une playlist //
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NamePlaylist", nom); // Cette procédure prend en paramètre le nom de la playlist //
                cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName()); // Et aussi l'identifiant de l'utilisateur //
                cmd.ExecuteNonQuery(); // Exécute la procédure //
            }
        }
    }
}
