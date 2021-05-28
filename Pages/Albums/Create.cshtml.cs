using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChinookWebApp.Models;
using System;
using System.Threading.Tasks;

namespace ChinookWebApp.Pages.Albums
{
    public class CreateModel : PageModel
    {
        private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

        public CreateModel(ChinookWebApp.Data.ChinookWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.albums.Add(Album);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}