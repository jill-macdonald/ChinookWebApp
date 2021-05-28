using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookWebApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace ChinookWebApp.Pages.Albums
{
    public class AlbumTracksModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public AlbumTracksModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }
        public IEnumerable<Track> Tracks { get; set; }
         public void OnGetAsync(int? id)
        {
            ViewData["Title"] = "Chinook - Tracks";
            //display tracks for selected album based on album id
            Tracks = _context.tracks.Include(a => a.albums).Where(a => a.AlbumId == id);
        } 

    }
}