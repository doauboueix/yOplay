using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{

    public partial class Playlist
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
