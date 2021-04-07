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
                .Include(g => g.Genre).FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }

            PopelateGenresDropDownList(_context, Movie.Genre);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movieToUpdate = await _context.Movie.FindAsync(id);

            if(movieToUpdate == null)
            {
                return NotFound();
            }


            if (await TryUpdateModelAsync<Movie>
            (
                movieToUpdate,
                "movie",
                m => m.GenreId,
                m => m.Title,
                m => m.ReleaseDate,
                m => m.Price,
                m => m.Rating
            ))
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            PopelateGenresDropDownList(_context, movieToUpdate.Genre);
            return Page();
        }
    }
}
