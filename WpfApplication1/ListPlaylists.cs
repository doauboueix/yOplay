using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public partial class ListPlaylists
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
