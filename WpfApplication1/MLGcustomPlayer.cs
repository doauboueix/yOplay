using ClassLibrary;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace WpfApplication1
{
    public partial class MLGcustomPlayer : Form
    {
        private List<Musique> ListMusique = new List<Musique>();
        private SoundPlayer SoundPlayer;
        private string Player { get; }
        private string Nom { get; }
        private int Minutes;
        private int Secondes;
        public MLGcustomPlayer(Playlist playlist)
        {
            InitializeComponent();
            NomPlaylist.Text = playlist.Nom;
            foreach (Musique musique in playlist.ListeMusique)
            {
                ListViewItem item = new ListViewItem(musique.Titre + "   /   " + musique.Auteur);
                list.Items.Add(item);
                SetListMusique(musique);
            }
        }
        public void SetListMusique(Musique musique)
        {
            ListMusique.Add(musique);
        }
        public List<Musique> GetListMusique()
        {
            return ListMusique;
        }
        private void Close(object sender, EventArgs e)
        {
            if (TimeLeft.Visible == true)
                SoundPlayer.Stop();
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
            this.Close();
        }

        private void Retour(object sender, EventArgs e)
        {
            if (TimeLeft.Visible == true)
                SoundPlayer.Stop();
            MesPlaylists MesPlaylists = new MesPlaylists();
            MesPlaylists.Show();
            this.Close();
        }

        public static TimeSpan GetWavFileDuration(string fileName)
        {
            WaveFileReader wf = new WaveFileReader(fileName);
            return wf.TotalTime;
        }

        private void LancementMusique(Musique musique)
        {
            ButtonPlay.Visible = false;
            ButtonStop.Visible = true;
            TitreSon.Text = "Now playing : " + musique.Titre + " / " + musique.Auteur;
            ProgressBar1.Visible = true;
            TimeLeft.Visible = true;
            TimeSpan duration = GetWavFileDuration(musique.Player);
            ProgressBar1.Value = 0;
            ProgressBar1.MaximumValue = (int)duration.TotalSeconds;
            SoundPlayer = new SoundPlayer(musique.Player.ToString());
            SoundPlayer.Play();
            Minutes = (int)duration.Minutes;
            Secondes = (int)duration.Seconds;
            TimerBar.Start();
            TimerBar.Interval = 1000;
        }

        private void Play(object sender, EventArgs e)
        {
            int i = list.FocusedItem.Index;
            Musique musique = GetListMusique()[i] as Musique;
            if (musique != null)
            {
                LancementMusique(musique);
            }
        }

       
        private void Stop(object sender, EventArgs e)
        {
            ButtonPlay.Visible = true;
            ButtonStop.Visible = false;
            TitreSon.Text = "";
            ProgressBar1.Visible = false;
            TimeLeft.Visible = false;
            SoundPlayer.Stop();
            TimerBar.Stop();
        }

        private void TimerBar_Tick(object sender, EventArgs e)
        {
            string a = "";
            string b = " : 0";
            string c = " : ";
            ProgressBar1.Value += 1;
            if (Secondes >= 10)
            {
                a = c;
                TimeLeft.Text = Minutes + a + Secondes;
            }
            else if (Secondes < 10)
            {
                a = b;
                TimeLeft.Text = Minutes + a + Secondes;
                if (Secondes <= 0)
                {
                    Secondes = 60;
                    Minutes--;
                }
            }
            Secondes--;
            if (Minutes == 0 && Secondes == 0)
            {
                TitreSon.Text = "";
                ProgressBar1.Visible = false;
                TimeLeft.Visible = false;
                SoundPlayer.Stop();
                TimerBar.Stop();
            }
        }

        private void ButtonForward_Click(object sender, EventArgs e)
        {
            int cpt = list.Items.Count;
            int i = list.FocusedItem.Index + 1;
            int a = list.FocusedItem.Index;
            if (i < cpt)
            {
                list.Items[a].Selected = false;
                list.Items[a].Focused = false;
                list.Items[i].Selected = true;
                list.Items[i].Focused = true;
                Musique musique = GetListMusique()[i] as Musique;
                if (musique != null)
                {
                    LancementMusique(musique);
                }
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            int i = list.FocusedItem.Index - 1;
            int a = list.FocusedItem.Index;
            if (i >= 0)
            {
                list.Items[a].Selected = false;
                list.Items[a].Focused = false;
                list.Items[i].Selected = true;
                list.Items[i].Focused = true;
                Musique musique = GetListMusique()[i] as Musique;
                if (musique != null)
                {
                    LancementMusique(musique);
                }
            }
        }
    }
}
