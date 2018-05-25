namespace ClassLibrary
{

    public class Film : Media
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
}