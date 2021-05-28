using System.Linq;
using System.Threading.Tasks;
using ChinookWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ChinookWebApp.Pages.Albums{
public class EditModel : PageModel
{
    private readonly ChinookWebApp.Data.ChinookWebAppContext _context;

    public EditModel(ChinookWebApp.Data.ChinookWebAppContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Album Album { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Album = await _context.albums.FirstOrDefaultAsync(m => m.AlbumId == id);

        if (Album == null)
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

        _context.Attach(Album).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(Album.AlbumId))
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
        return _context.albums.Any(e => e.AlbumId == id);
    }
}
}