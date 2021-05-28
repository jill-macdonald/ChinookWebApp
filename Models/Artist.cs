using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChinookWebApp.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

       public Album albums { get; set; }

    }
}