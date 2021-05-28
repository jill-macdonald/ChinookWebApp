using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookWebApp.Data;
using ChinookWebApp.Models;

namespace ChinookWebApp.Pages.Tracks
{
    public class DetailsModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public DetailsModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }

        public Track Track { get; set; }

        #region snippet1
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.tracks.FirstOrDefaultAsync(m => m.TrackId == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
} 