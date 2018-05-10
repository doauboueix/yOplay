﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApplication1
{
    public partial class MesMusiques : Window
    {
        private List<Musique> eMusique = new List<Musique>(); // Liste d'objets Musique possédé par l'utilisateur que l'on affiche dans la ListView // 
        private SoundPlayer SoundPlayer;
        private DispatcherTimer Timer;
        private int Minutes;
        private int Secondes;
        public List<string> mesMusiques = new List<string>(); // Liste des noms de films possédés par l'utilisateur actuel //
        public MesMusiques()
        {
            InitializeComponent();
            using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
            {
                Utilisateur Utilisateur = new Utilisateur();
                NomPrenom.Text = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
                Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("ChargementMesMusiques", sqlCon); // Appelle la procédure stockée ChargementMesMusiques qui recupère le nom de tous les films pour l'utilisateur en cours //
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName());  // Cette procédure prend en paramètre l'identifiant de l'utilisateur en cours que l'on récupère au moment de la connexion (lorsque celle-ci réussit) //
                cmd.ExecuteNonQuery(); // Execute la procédure //
                SqlDataReader reader = cmd.ExecuteReader(); // on créé un reader capable de lire des données SQL //
                while (reader.Read()) // Tant que ce reader lit des données on éxécute le code ci-dessous //
                {
                    mesMusiques.Add((string)reader[0]); // Ajoute dans la liste mesMusiques tous les noms de musique possédés par l'utilisateur actuel //
                }
                reader.Close();
                Musiques Musiques = new Musiques();
                foreach (string musique in mesMusiques) // Pour chacun des noms de musique présent dans cette liste, on cherche la correspondance avec l'objet "Musique" en question //
                    eMusique.Add(Musiques.EMusique.Find(x => x.Titre == musique)); // On retourne l'objet correspond dans une list<Musique> //
                list.ItemsSource = eMusique; // On affiche toutes les musiques possédés par l'utilisateur dans la ListView en indiquant la source de celle-ci //
            }
        }



        // LIST : GET, SET !!! //
        //////////////////////////////////////////////
        public List<Musique> GetList()
        {
            return eMusique;
        }
        public void SetList(Musique musique)
        {
            eMusique.Add(musique);
        }
        //////////////////////////////////////////////



        // OUVERTURE/FERMETURE MENU //
        ///////////////////////////////////////////////////////////////////////
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        ///////////////////////////////////////////////////////////////////////



        // CLICK ITEM MATERIAL DESIGN MENU //
        ///////////////////////////////////////////////////////////////////////
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }
        private void MesPlaylists(object sender, RoutedEventArgs e)
        {
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemRetour":
                    Retour(sender, e);
                    break;

                case "ItemAccueil":
                    Accueil(sender, e);
                    break;

                case "ItemMesPlaylists":
                    MesPlaylists(sender, e);
                    break;
            }
        }
        ///////////////////////////////////////////////////////////////////////



        // SE DECONNECTER //
        ////////////////////////////////////////////////////////////////
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }
        /////////////////////////////////////////////////////////////////



        // BOUTON AJOUTER SOLDE //
        //////////////////////////////////////////////////////////////
        private void AugmenterSolde(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }
        //////////////////////////////////////////////////////////////



        // INPUT BOX //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            int cpt = 0;
            int cpt2 = 0;
            string input = InputTextBox.Text;
            foreach (Char c in input) // pour chaque caractère inscrit dans la textbox //
            {
                if (!Char.IsDigit(c)) // si ce caractère n'est pas un chiffre compris entre 0 et 9 //
                {
                    cpt += 1; // alors on incrémente le compteur de 1 //
                }
                cpt2 += 1; // compteur qui compte le nombre de caractère renseigné //
            }
            if (cpt2 == 0)
                MessageBox.Show("Vous n'avez entré aucune valeur !", "Erreur");
            else if (cpt != 0) // si le compteur n'est pas égal à 0 //
            {
                MessageBox.Show("Format valide (Entiers uniquement) !", "Erreur format"); // on affiche un message indiquant que le format n'est pas respecté //
                InputTextBox.Text = String.Empty; // on réinitialise le contenu de la textbox //
            }
            else
            {
                Utilisateur Utilisateur = new Utilisateur();
                Utilisateur.AjouterSolde(Convert.ToDecimal(input));
                Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                using (SqlConnection sqlCon = new SqlConnection(@" Data Source=192.168.42.106,49172 ; Initial Catalog=DataBaseProject ; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE UserTable SET Solde = @Solde WHERE UserName = @UserName", sqlCon); // créé une commande qui modifie le solde de l'utilisateur actuel //
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Solde", Utilisateur.GetSolde()); // cette commande prend en paramètre le solde de l'utilisateur //
                    cmd.Parameters.AddWithValue("@UserName", Utilisateur.GetUserName()); // elle doit donc récupérer le UserName de celui-ci //
                    cmd.ExecuteNonQuery(); // Exécute la procédure //
                }

                InputBox.Visibility = Visibility.Collapsed;
                InputTextBox.Text = String.Empty;
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        /// PLAYER ///

        // RETURN MUSIC DURATION !!! //
        ////////////////////////////////////////////////////////////////
        public static TimeSpan GetWavFileDuration(string fileName)
        {
            WaveFileReader wf = new WaveFileReader(fileName);
            return wf.TotalTime;
        }
        ///////////////////////////////////////////////////////////////



        // Boutton "Play" !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonPlay(object sender, MouseButtonEventArgs e)
        {
            Musique musique = list.SelectedItem as Musique;
            if (musique != null)
            {
                AffichagePlay();
                SoundPlayer = new SoundPlayer(musique.Player.ToString());
                NameSon.Content = "Now playing : " + musique.Titre.ToString() + " / " + musique.Auteur.ToString();
                TimeSpan duration = GetWavFileDuration(musique.Player.ToString());
                Minutes = (int)duration.Minutes;
                Secondes = (int)duration.Seconds;
                ProgressBar1.Maximum = (int)duration.TotalSeconds;
                SoundPlayer.Play();
                ActivateTimer();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Boutton "STOP" !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonStop(object sender, MouseButtonEventArgs e)
        {
            Timer.Stop();
            SoundPlayer.Stop();
            AffichageStop();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Boutton "BACK" !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonBack(object sender, MouseButtonEventArgs e)
        {
            int i = list.SelectedIndex - 1;
            int a = list.SelectedIndex;
            if (i >= 0)
            {
                ListViewItem item = list.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                item.Focus();
                item.IsSelected = true;
                ListViewItem item2 = list.ItemContainerGenerator.ContainerFromIndex(a) as ListViewItem;
                item2.IsSelected = false;
                Musique musique = GetList()[i] as Musique;
                Back_Next(musique);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Boutton "NEXT" !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonNext(object sender, MouseButtonEventArgs e)
        {
            int cpt = list.Items.Count;
            int i = list.SelectedIndex + 1;
            int a = list.SelectedIndex;
            if (i < cpt && a >= 0)
            {
                ListViewItem item = list.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                item.Focus();
                item.IsSelected = true;
                ListViewItem item2 = list.ItemContainerGenerator.ContainerFromIndex(a) as ListViewItem;
                item2.IsSelected = false;
                Musique musique = GetList()[i] as Musique;
                Back_Next(musique);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // TIMER !!! //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ActivateTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += DispatcherTimer_Tick;
            Timer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            string a = "";
            string b = " : 0";
            string c = " : ";
            ProgressBar1.Value += 1;
            if (Secondes >= 10)
            {
                a = c;
                TimeLeft.Content = Minutes + a + Secondes;
            }
            else if (Secondes < 10)
            {
                a = b;
                TimeLeft.Content = Minutes + a + Secondes;
                if (Secondes <= 0)
                {
                    Secondes = 60;
                    Minutes--;
                }
            }
            Secondes--;
            if (Minutes == 0 && Secondes == 0)
            {
                Timer.Stop();
                AffichageStop();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // AFFICHAGE //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void AffichagePlay()
        {
            Play.Visibility = Visibility.Collapsed;
            Stop.Visibility = Visibility.Visible;
            ProgressBar1.Visibility = Visibility.Visible;
            ProgressBar1.Value = 0;
            TimeLeft.Content = "";
            TimeLeft.Visibility = Visibility.Visible;
            NameSon.Visibility = Visibility.Visible;
        }
        private void AffichageStop()
        {
            Stop.Visibility = Visibility.Collapsed;
            Play.Visibility = Visibility.Visible;
            ProgressBar1.Visibility = Visibility.Hidden;
            TimeLeft.Visibility = Visibility.Hidden;
            NameSon.Visibility = Visibility.Hidden;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////       



        //   Si l'élément précédent ou suivant est non null, execution de ce code   //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Back_Next(Musique musique)
        {
            if (musique != null)
            {
                if (Stop.Visibility == Visibility.Collapsed)
                    AffichagePlay();
                else
                    Timer.Stop();
                SoundPlayer = new SoundPlayer(musique.Player.ToString());
                NameSon.Content = "Now playing : " + musique.Titre.ToString() + " / " + musique.Auteur.ToString();
                TimeSpan duration = GetWavFileDuration(musique.Player.ToString());
                Minutes = (int)duration.Minutes;
                Secondes = (int)duration.Seconds;
                ProgressBar1.Maximum = (int)duration.TotalSeconds;
                ProgressBar1.Value = 0;
                ProgressBar1.Visibility = Visibility.Hidden;
                ProgressBar1.Visibility = Visibility.Visible;
                SoundPlayer.Play();
                ActivateTimer();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
