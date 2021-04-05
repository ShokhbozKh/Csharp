using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DetailsModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; }
        [Display(Name = "Movies list")]
        public IList<Movie> Movies { get; set; }
        private Movie selectedMovie;
        [BindProperty]
        public Movie SelectedMovie 
        {
            get => selectedMovie;
            set
            {
                selectedMovie = value;
                int g = 0;
            }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.Include(m => m.Movies).FirstOrDefaultAsync(m => m.GenreId == id);
            Movies = Genre.Movies.ToList();

            int g = 0;

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }

        public void OnPost(Movie movie)
        {
            var k = SelectedMovie;

            int g = 0;
        }
    }
}
