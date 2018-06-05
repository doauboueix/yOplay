namespace ClassLibrary
{
    public abstract class Media
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
}
