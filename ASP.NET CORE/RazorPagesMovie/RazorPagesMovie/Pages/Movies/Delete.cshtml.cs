using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(RazorPagesMovieContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.Include(g => g.Genre).FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = $"Delete {id} failed because it was deleted by another user. If you still want to delete this record, click Delete button again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                // Movie.ConcurrencyToken value is from when the entity was fetched
                // from OnGetAsync method. If it doesn't match the DB, 
                // DbUpdateConcurrencyException is thrown
                if(await _context.Movie.AnyAsync(
                    m => m.ID == id))
                {
                    _context.Movie.Remove(Movie);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToPage("./Delete", new { id, saveChangesError = true });
            }
            catch (DbUpdateException)
            {
                return RedirectToPage("../Error");
            }
        }
    }
}
