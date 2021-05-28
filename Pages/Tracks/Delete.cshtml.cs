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
    public class DeleteModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public DeleteModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Track Track { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.tracks.FindAsync(id);

            if (Track != null)
            {
                _context.tracks.Remove(Track);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}