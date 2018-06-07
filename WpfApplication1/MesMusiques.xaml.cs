using ClassLibrary;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using SQL;
using System.Diagnostics;
using System.Linq;

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
            Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
            SQLselect SQLselect = new SQLselect();
            mesMusiques = SQLselect.ChargementMesMusiques(Utilisateur.GetUserName());
            Musiques Musiques = new Musiques();
            foreach (string musique in mesMusiques) // Pour chacun des noms de musique présent dans cette liste, on cherche la correspondance avec l'objet "Musique" en question //
                eMusique.Add(Musiques.EMusique.Find(x => x.Titre == musique)); // On retourne l'objet correspond dans une list<Musique> //
            list.ItemsSource = eMusique; // On affiche toutes les musiques possédés par l'utilisateur dans la ListView en indiquant la source de celle-ci //
            UC.OnClosed += UCtitre_OnClosed;
            UC.OnSolded += UCtitre_OnSolded;
        }



        /// <summary>
        /// Méthode utilisée pour l'évênement OnClosed du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCtitre_OnClosed(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Méthode utilisée pour l'évênement OnSolded du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCtitre_OnSolded(object sender, EventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Méthode GET de eMusique
        /// </summary>
        /// <returns></returns>
        public List<Musique> GetList()
        {
            return eMusique;
        }



        /// <summary>
        /// Méthode SET de eMusique
        /// </summary>
        /// <param name="musique"></param>
        public void SetList(Musique musique)
        {
            eMusique.Add(musique);
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
                if (Stop.Visibility == Visibility.Visible)
                    SoundPlayer.Stop();
            }
            base.OnClosing(e);
        }



        /// <summary>
        /// Ouvre le menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }



        /// <summary>
        /// Ferme le menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Bouton Accueil renvoyant vers la page Accueil
        /// Si une musique est en cours de lecture, elle est arrêtée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }



        /// <summary>
        /// Bouton MesPlaylists renvoyant vers la page MesPlaylists
        /// Si une musique est en cours de lecture, elle est arrêtée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MesPlaylists(object sender, RoutedEventArgs e)
        {
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }



        /// <summary>
        /// Bouton Retour renvoyant vers la page Musiques 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour(object sender, RoutedEventArgs e)
        {
            Musiques Musiques = new Musiques();
            Musiques.Show();
            if (Stop.Visibility == Visibility.Visible)
                SoundPlayer.Stop();
            this.Close();
        }



        /// <summary>
        /// Regroupe toutes les methodes du menu Material Design ( car ils sont dans une ListView donc obligation de passer par un switch / case )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Bouton Valider de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
                Utilisateur.AjouterSolde(Convert.ToDecimal(input));
                UC.Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                SQLupdate SQLupdate = new SQLupdate();
                SQLupdate.UpdateSolde(Utilisateur.GetUserName(), Convert.ToDecimal(input));

                InputBox.Visibility = Visibility.Collapsed;
                InputTextBox.Text = String.Empty;
            }
        }



        /// <summary>
        /// Bouton Annuler de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }



        /// <summary>
        /// Méthode calculant la durée d'un fichier .wav
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns> Durée du fichier .wav </returns>
        public static TimeSpan GetWavFileDuration(string fileName)
        {
            WaveFileReader wf = new WaveFileReader(fileName);
            return wf.TotalTime;
        }



        /// <summary>
        /// Lit la musique de l'item de la ListView sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Bouton Stop du Lecteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStop(object sender, MouseButtonEventArgs e)
        {
            Timer.Stop();
            SoundPlayer.Stop();
            AffichageStop();
        }



        /// <summary>
        /// Joue la musique qui se trouve à la position -1 que la musique en cours ( position dans la ListView ) 
        /// Si la musique en cours est la première dans la ListView, cette méthode ne fait rien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Joue la musique qui se trouve à la position +1 que la musique en cours ( position dans la ListView ) 
        /// Si la musique en cours est la dernère dans la ListView, cette méthode ne fait rien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Active un timer
        /// </summary>
        private void ActivateTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += DispatcherTimer_Tick;
            Timer.Start();
        }



        /// <summary>
        /// Méthode qui affiche un timer pour la musique en cours 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Affiche le bouton play, aucune musique n'est en cours de lecture
        /// </summary>
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



        /// <summary>
        /// Affiche le bouton stop, cela signifie qu'une musique est en cours de lecture
        /// </summary>
        private void AffichageStop()
        {
            Stop.Visibility = Visibility.Collapsed;
            Play.Visibility = Visibility.Visible;
            ProgressBar1.Visibility = Visibility.Hidden;
            TimeLeft.Visibility = Visibility.Hidden;
            NameSon.Visibility = Visibility.Hidden;
        }



        /// <summary>
        /// Méthode appellée dans ButtonBack et ButtonNext réinitialisant l'affichage (timer + progressionBar)
        /// </summary>
        /// <param name="musique"></param>
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
    }
}
