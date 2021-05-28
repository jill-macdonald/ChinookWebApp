using System.Linq;
using System.Threading.Tasks;
using ChinookWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ChinookWebApp.Pages.Tracks{
public class EditModel : PageModel
{
    private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

    public EditModel(ChinookWebApp.Data.ChinookWebAppContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Track).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(Track.TrackId))
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
        return _context.tracks.Any(e => e.TrackId == id);
    }
}
} 