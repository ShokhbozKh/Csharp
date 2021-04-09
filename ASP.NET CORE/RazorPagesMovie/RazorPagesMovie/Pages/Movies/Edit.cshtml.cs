using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class EditModel : GenreNamePageModel
    {
        private readonly RazorPagesMovieContext _context;

        public EditModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
                .Include(g => g.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }

            PopulateGenresDropDownList(_context, Movie.Genre);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ConcurrencyToken may have changed.
            var movieToUpdate = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if(movieToUpdate == null)
            {
                return HandleDeletedMovie();
            }

            // Set ConcurrencyToken to value read in OnGetAsync
            _context.Entry(movieToUpdate).Property(
                m => m.ConcurrencyToken).OriginalValue = Movie.ConcurrencyToken;

            if (await TryUpdateModelAsync<Movie>(
                movieToUpdate,
                "movie",
                m => m.Title, m => m.ReleaseDate,
                m => m.Price, m => m.Rating,
                m => m.GenreId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Movie)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();

                    if(databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. The movie was deleted by another user.");

                        return Page();
                    }

                    var dbValues = (Movie)databaseEntry.ToObject();
                    await SetDbErrorMessage(dbValues, clientValues, _context);

                    // Save the current ConcurrencyToken so next postback
                    // matches unless an new concurrency issue happens.
                    Movie.ConcurrencyToken = (byte[])dbValues.ConcurrencyToken;
                    // Clear model error for the next postback
                    ModelState.Remove($"{nameof(Movie)}.{nameof(Movie.ConcurrencyToken)}");
                }
            }

            // Get errors from TryUpdate
            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            .SelectMany(E => E.Errors)
            .Select(E => E.ErrorMessage)
            .ToList();

            PopulateGenresDropDownList(_context, movieToUpdate.Genre);
            return Page();
        }

        private IActionResult HandleDeletedMovie()
        {
            // ModelState contains the posted data because of the deletion error
            // and overides the Department instance values when displaying Page().
            ModelState.AddModelError(string.Empty, "Unable to save. The department was deleted by another user.");

            PopulateGenresDropDownList(_context, Movie.Genre);
            return Page();
        }

        private async Task SetDbErrorMessage(Movie dbValues, Movie clientValues, RazorPagesMovieContext context)
        {
            if(dbValues.Title != clientValues.Title)
            {
                ModelState.AddModelError("Movie.Title", $"Current value: {dbValues.Title}");
            }
            if (dbValues.ReleaseDate != clientValues.ReleaseDate)
            {
                ModelState.AddModelError("Movie.ReleaseDate", $"Current value: {dbValues.ReleaseDate}");
            }
            if (dbValues.Price != clientValues.Price)
            {
                ModelState.AddModelError("Movie.Price", $"Current value: {dbValues.Price}");
            }
            if (dbValues.Rating != clientValues.Rating)
            {
                ModelState.AddModelError("Movie.Rating", $"Current value: {dbValues.Rating}");
            }
            // omit the description checking for better performance
            /*if (dbValues.Description != clientValues.Description)
            {
                ModelState.AddModelError("Movie.Description", $"Current value: {dbValues.Description}");
            }*/
            if (dbValues.GenreId != clientValues.GenreId)
            {
                Genre dbGenre = await context.Genre
                    .FindAsync(dbValues.GenreId);
                ModelState.AddModelError("Movie.GenreId", $"Current value: {dbGenre?.GenreTitle}");
            }

            ModelState.AddModelError(string.Empty, "The record you attempted to edit was modified by another user after you." +
                "The edit operation was canceled and the current values in the database have been displayed." +
                "If you still want to edit this record, click the Save button again.");

        }
    }
}
