using System.Linq;
using System.Threading.Tasks;
using ChinookWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ChinookWebApp.Pages.Artists{
public class EditModel : PageModel
{
    private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

    public EditModel(ChinookWebApp.Data.ChinookWebAppContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Artist).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(Artist.ArtistId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool MovieExists(int id)
    {
        return _context.artists.Any(e => e.ArtistId == id);
    }
}
}