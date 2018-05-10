using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Console;

namespace WpfApplication1
{
    public partial class Media
    {
        public decimal Prix { get; }
        public string Genre { get; }
        public string Source { get; }

        public Media(decimal prix, string genre, string imageSource)
        {
            Prix = prix;
            Genre = genre;
            Source = imageSource;
        }
    }

    public partial class Film : Media
    {
        public string Nom { get; }
        public string Realisateur { get; }
        public string Description { get; }
        public string Note { get; }
        public Film(decimal prix, string genre, string imageSource, string nom, string realisateur, string description, string note)
            : base(prix, genre, imageSource)
        {
            Nom = nom;
            Realisateur = realisateur;
            Description = description;
            Note = note;
        }

    }

    public partial class Musique : Media
    {
        public string Titre { get; set; }
        public string Auteur { get; }
        public string Album { get; }
        public string Player { get; }
        public Musique(decimal prix, string genre, string imageSource, string titre, string auteur, string album, string player)
            : base(prix, genre, imageSource)
        {
            Titre = titre;
            Auteur = auteur;
            Album = album;
            Player = player;
        }
    }
}
