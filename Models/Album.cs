using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChinookWebApp.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }

        public int ArtistId{get; set;}

        //public ICollection<Artist> artists { get; set; }
    }
}