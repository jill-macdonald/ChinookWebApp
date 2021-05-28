using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookWebApp.Data;
using ChinookWebApp.Models;

namespace ChinookWebApp.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public DetailsModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.artists.FirstOrDefaultAsync(m => m.ArtistId == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}