using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClassLibrary;
using SQL;

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
                SelectBox.Items.Add(new ComboBoxItem { Content = musique.Titre.ToString() }); // On rempli la SelectBox de toutes les musiques que l'utilisateur possède // 
            }
            if (!SelectBox.HasItems)
                SelectBox.Items.Add(new ComboBoxItem { Content = "Vous ne possédez pas de musique", IsEnabled = false });
        }



        /// <summary>
        /// Methode GET de ListPlaylist
        /// </summary>
        /// <returns> ListPlaylist </returns>
        public List<Musique> GetPlaylist()
        {
            return ListPlaylist;
        }



        /// <summary>
        /// Methode SET de ListPlaylist
        /// </summary>
        /// <param name="musique"></param>
        public void SetPlaylist(Musique musique)
        {
            ListPlaylist.Add(musique);
        }



        /// <summary>
        /// Redefinition de la méthode de la croix X 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            bool wasCodeClosed = new StackTrace().GetFrames().FirstOrDefault(x => x.GetMethod() == typeof(Window).GetMethod("Close")) != null;
            if (!wasCodeClosed) // Si la fenetre a été fermé par un click sur la croix X, on éxécute le code ci-dessous // 
            {
                SQLdelete SQLdelete = new SQLdelete();
                SQLdelete.DeletePlaylist(); // on supprime toute les musiques enregistrées dans UserPlaylist qui ne possède pas de nom de playlist // 
                MesPlaylists MesPlaylists = new MesPlaylists();
                MesPlaylists.Show();
            }
            base.OnClosing(e);
        }



        /// <summary>
        /// Ajoute une musique dans la liste de création de la playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMusique(object sender, RoutedEventArgs e)
        {
            Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
            MesMusiques MesMusiques = new MesMusiques();
            int index = GetPlaylist().FindIndex(item => item.Titre == SelectBox.Text.ToString()); // on vérifie si la playlist en cours de création ne possède pas 2 fois la même musique, via un index //
            var son = MesMusiques.GetList().Find(x => x.Titre == SelectBox.Text.ToString());

            if (SelectBox.Text.ToString() != "--Veuillez choisir une musique--")
            {
                if (index < 0) // si l'index est inférieur à 0, cela signifie qu'elle n'est pas présente dans la playlist, donc on peut l'ajouter //
                {
                    list.Items.Add(son);
                    SetPlaylist(son);
                    SQLupdate SQLupdate = new SQLupdate();
                    SQLupdate.AjouterPlaylist(Utilisateur.GetUserName(), SelectBox.Text);
                }
                else
                    MessageBox.Show("Cette musique est déja dans la liste !", "Erreur");
            }
            else
            {
                MessageBox.Show("Aucune musique sélectionnée !", " Erreur ");
            }
        }



        /// <summary>
        /// Bouton Créer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreePlaylist(object sender, RoutedEventArgs e)
        {
            if (NomPlaylist.Text.ToString() != "") // le nom de playlist ne doit pa être vide //
            {
                if (list.HasItems) // la liste doit contenir des musiques //
                {
                    MessageBox.Show("Playlist créée !", "Succès");
                    SQLupdate SQLupdate = new SQLupdate();
                    SQLupdate.UpdatePlaylist(NomPlaylist.Text); // On update toutes les musiques que l'on a ajouté dans UserPlaylist en rajoutant le nom de playlist //
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



        /// <summary>
        /// Bouton Retour 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour(object sender, RoutedEventArgs e)
        {
            SQLdelete SQLdelete = new SQLdelete();
            SQLdelete.DeletePlaylist(); // On supprime toute les musiques qui ne sont lié à aucune playlist dans UserPlaylist, cad celles qui ne possèdent pas de nom de playlist //
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
            this.Close();
        }
    }
}
