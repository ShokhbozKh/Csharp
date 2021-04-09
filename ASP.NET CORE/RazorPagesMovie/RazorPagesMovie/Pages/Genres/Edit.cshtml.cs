using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Genres
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public EditModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.FirstOrDefaultAsync(m => m.GenreId == id);

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch current Genre from DB.
            // ConcurrencyToken may have chaneged
            var genreToUpdate = await _context.Genre.FindAsync(id);

            if(genreToUpdate == null)
            {
                HandleDeletedGenre();
            }

            // Set the Concurrency token to the one, which was initially
            // when the Genre was fetched from DB on OnGetAsync
            _context.Entry(genreToUpdate).Property(
                g => g.ConcurrencyToken).OriginalValue = Genre.ConcurrencyToken;

            if(await TryUpdateModelAsync(
                genreToUpdate,
                "genre",
                g => g.GenreTitle))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Genre)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();

                    if(databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. The Genre was deleted by another user.");
                        return Page();
                    }

                    var dbValues = (Genre)databaseEntry.ToObject();
                    await SetDbErrorMessage(dbValues, clientValues, _context);

                    // Save the current ConcurrencyToken so next postback
                    // matches unless a new concurrency issue happens
                    Genre.ConcurrencyToken = (byte[])dbValues.ConcurrencyToken;
                    // Clear the model error for the next postback
                    ModelState.Remove($"{nameof(Genre)}.{nameof(Genre.ConcurrencyToken)}");
                }
            }

            // Get errors from TryUpdate
            /*
            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            .SelectMany(E => E.Errors)
            .Select(E => E.ErrorMessage)
            .ToList();
            */

            return Page();
        }

        private IActionResult HandleDeletedGenre()
        {
            // ModelState contains the posted data because of the deletion error
            // and overides the Department instance values when displaying Page().
            ModelState.AddModelError(string.Empty, "Unable to save. The department was deleted by another user.");

            return Page();
        }

        private async Task SetDbErrorMessage(Genre dbValues, Genre clientValues, RazorPagesMovieContext context)
        {
            if(dbValues.GenreTitle != clientValues.GenreTitle)
            {
                ModelState.AddModelError("Genre.GenreTitle", $"Current value: {clientValues.GenreTitle}");
            }

            if(dbValues.GenreId != clientValues.GenreId)
            {
                Genre dbGenre = await _context.Genre.FindAsync(dbValues.GenreId);

                ModelState.AddModelError("Genre.GenreId", $"Current value {dbGenre?.GenreTitle}");
            }

            ModelState.AddModelError(string.Empty, "The record you attempted to edit was modified by another user " +
                "and the operation was canceled. If you still want to edit this record, click the Save button again.");
        }
    }
}
