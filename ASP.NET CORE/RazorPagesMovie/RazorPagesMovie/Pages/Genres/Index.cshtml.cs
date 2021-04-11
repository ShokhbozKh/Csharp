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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        // Sorting
        public string TitleSort { get; set; }
        public string NumOfMoviesSort { get; set; }

        public IList<Genre> Genre { get;set; }
        public SelectList SortOptions { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortQuery { get; set; }

        public async Task OnGetAsync(string sortBy)
        {
            IQueryable<Genre> genres = _context.Genre.Include("Movies");

            //int g = 0;

            TitleSort = string.IsNullOrWhiteSpace(sortBy) ? "title_desc" : "";
            NumOfMoviesSort = sortBy == "movies_desc" ? "movies_asc" : "movies_desc";

            genres = sortBy switch
            {
                "title_desc" => genres.OrderByDescending(g => g.GenreTitle),
                "movies_asc" => genres.OrderBy(g => g.Movies.Count),
                "movies_desc" => genres.OrderByDescending(g => g.Movies.Count),
                _ => genres.OrderBy(g => g.GenreTitle),
            };

            Genre = await genres.ToListAsync();
        }
    }
}
