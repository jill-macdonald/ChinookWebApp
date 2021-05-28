using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookWebApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace ChinookWebApp.Pages.Albums
{
    public class AlbumArtistsModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public AlbumArtistsModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }
        public IEnumerable<Artist> Artists { get; set; }
         public void OnGetAsync(int? id)
        {
            ViewData["Title"] = "Chinook - Artists";
            //This will display the artist of the album, using the artist id
            Artists = _context.artists.Include(a => a.albums).Where(a => a.ArtistId == id);
        } 

    }
}