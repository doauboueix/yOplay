namespace ClassLibrary
{
    public class Musique : Media
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