namespace ClassLibrary
{
    public class ListPlaylists
    {
        public string NameSong { get; set; }
        public string NamePlaylist { get; set; }

        public ListPlaylists(string namesong, string nameplaylist)
        {
            NameSong = namesong;
            NamePlaylist = nameplaylist;
        }
    }
}
