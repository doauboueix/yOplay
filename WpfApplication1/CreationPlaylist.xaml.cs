using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class CreationPlaylist : Window
    {
        private List<Musique> ListPlaylist = new List<Musique>();
        public CreationPlaylist()
        {
            InitializeComponent();
            MesMusiques MesMusiques = new MesMusiques();
            var items = MesMusiques.GetList();
            foreach (Musique musique in items)
            {
                SelectBox.Items.Add(new ComboBoxItem { Content = musique.Titre.ToString() });
            }
            if (!SelectBox.HasItems)
                SelectBox.Items.Add(new ComboBoxItem { Content = "Vous ne possédez pas de musique", IsEnabled = false });
        }



        // GET/SET DE LA LISTE //
        /////////////////////////////////////////////////////////////
        public List<Musique> GetPlaylist()
        {
            return ListPlaylist;
        }
        public void SetPlaylist(Musique musique)
        {
            ListPlaylist.Add(musique);
        }
        /////////////////////////////////////////////////////////////



        // REDEFINITION DE LA CROIX X EN HAUT A DROITE //
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            bool wasCodeClosed = new StackTrace().GetFrames().FirstOrDefault(x => x.GetMethod() == typeof(Window).GetMethod("Close")) != null;
            if (!wasCodeClosed)
            {
                using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
                {
                    Utilisateur Utilisateur = new Utilisateur();
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("DeleteUserPlaylist", sqlCon); // on appelle la procédure stockée "DeleteUserPlaylist", supprimant toutes les musiques qui ne possède pas de nom de playlist //
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); // Exécute la procédure //
                }
                MesPlaylists MesPlaylists = new MesPlaylists();
                MesPlaylists.Show();
            }
            base.OnClosing(e);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // AJOUTE UNE MUSIQUE DANS LA LISTE DE CREATION DE PLAYLIST //
        ////////////////////////////////////////////////////////////////////////////////////////////
        private void AddMusique(object sender, RoutedEventArgs e)
        {
            MesMusiques MesMusiques = new MesMusiques();
            int index = GetPlaylist().FindIndex(item => item.Titre == SelectBox.Text.ToString()); // on vérifie si la playlist en cours de création ne possède pas 2 fois la même musique, via un index //
            var son = MesMusiques.GetList().Find(x => x.Titre == SelectBox.Text.ToString());

            if (SelectBox.Text.ToString() != "--Veuillez choisir une musique--")
            {
                if (index < 0) // si l'index est inférieur à 0, cela signifie qu'elle n'est pas présente dans la playlist, donc on peut l'ajouter //
                {
                    list.Items.Add(son);
                    SetPlaylist(son);

                    using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
                    {
                        Utilisateur Utilisateur = new Utilisateur();
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("EnregistrementPlaylist", sqlCon); // on appelle la procédure stockée "EnregistrementPlaylist, qui ajoute une musique dans la table UserPlaylist (sans nom de playlist pour le moment //
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NameSong", SelectBox.Text); // on récupère le nom de la musique //
                        cmd.Parameters.AddWithValue("@NamePlaylist", ""); // on ne possède pas forcemment encore le nom de la playlist, nous l'ajouterons quand on cliquera sur le bouton "Creer" //
                        cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName()); // on récupère le nom d'utilisateur //
                        cmd.ExecuteNonQuery(); // Exécute la procédure //
                    }
                }
                else
                    MessageBox.Show("Cette musique est déja dans la liste !", "Erreur");
            }
            else
            {
                MessageBox.Show("Aucune musique sélectionnée !", " Erreur ");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////



        private void CreePlaylist(object sender, RoutedEventArgs e)
        {
            if (NomPlaylist.Text.ToString() != "") // le nom de playlist ne doit pa être vide //
            {
                if (list.HasItems) // la liste doit contenir des musiques //
                {
                    MessageBox.Show("Playlist créée !", "Succès");
                    using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
                    {
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("UpdatePlaylist", sqlCon); // on update la table UserPlaylist, en remplacant le nom de playlist par toutes les musiques qui n'en possèdent pas //
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NamePlaylist", NomPlaylist.Text); // on récupère le nom de playlist //
                        cmd.ExecuteNonQuery(); // Exécute la procédure //
                    }
                    MesPlaylists MesPlaylists = new MesPlaylists();
                    MesPlaylists.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Votre playlist ne contient aucune musique !", "Erreur");
            }
            else
                MessageBox.Show("Entrez un nom de playlist !", "Erreur");
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
            {
                Utilisateur Utilisateur = new Utilisateur();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("DeleteUserPlaylist", sqlCon); // on appelle la procédure stockée "DeleteUserPlaylist", supprimant toutes les musiques qui ne possède pas de nom de playlist //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery(); // Exécute la procédure //
            }
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
            this.Close();
        }
    }
}
