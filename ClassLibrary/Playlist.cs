using System.Collections.Generic;

namespace ClassLibrary
{

    public class Playlist
    {
        public List<Musique> ListeMusique { set; get; }
        public string Nom { get; set; }

        public Playlist ( string Nom , List<Musique> ListeMusique)
        {
            this.Nom = Nom;
            this.ListeMusique = ListeMusique;
        }
    }
}
