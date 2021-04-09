using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Genres
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
        public Genre Genre { get; set; }
        [Display(Name = "Movies list")]
        public SelectList MoviesSL { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? errorSaveChanges = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.GenreId == id);

            if (Genre == null)
            {
                return NotFound();
            }

            if (errorSaveChanges.GetValueOrDefault())
            {
                ErrorMessage = $"Deleting {id} failed because it was modified by another user. If you still want to delete this record, please click Delete button again.";
            }

            MoviesSL = new SelectList(Genre.Movies);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                if (await _context.Genre.AnyAsync(
                    m => m.GenreId == id))
                {
                    // Genre.ConcurrencyToken value is from when the entity
                    // was fetched from OnGetAsync. If it doesn't match the DB,
                    // DbUpdateConcurrencyException is thrown
                    _context.Genre.Remove(Genre);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
                return NotFound();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message, "DB delete concurrency error");
                return RedirectToPage("./Delete", new { concurrencyError = true, id });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message, "DB delete error");
                return RedirectToPage("../Error");
            }
        }
    }
}
