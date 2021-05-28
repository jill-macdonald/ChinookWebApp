using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChinookWebApp.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public IndexModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }
        public IList<Album> Album { get;set; }

        public async Task OnGetAsync()
        {
            Album = await _context.albums.ToListAsync();
        }
    }
}