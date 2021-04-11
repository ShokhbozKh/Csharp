using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public DetailsModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; }
        public List<Movie> Movies { get; set; }
        public SelectList MoviesSL { get; set; }
        [BindProperty]
        public Movie SelectedMovie 
        { 
            get; 
            set; 
        }
        [BindProperty]
        public int ID 
        { 
            get; 
            set; 
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.Include(m => m.Movies).FirstOrDefaultAsync(m => m.GenreId == id);
            Movies = Genre.Movies.ToList();
            ID = Movies[0].ID;

            var result = (from m in _context.Movie
                          join g in _context.Genre on m.GenreId equals g.GenreId
                          where g.GenreTitle == "Action"
                          select m).ToList();

            if (Genre == null)
            {
                return NotFound();
            }

            MoviesSL = new SelectList(Movies, nameof(Movie.ID), nameof(Movie.Title));

            return Page();
        }

        public IActionResult OnPost(int? id)
        {

            return Redirect($"/Movies/Details/{id}");
        }
    }
}