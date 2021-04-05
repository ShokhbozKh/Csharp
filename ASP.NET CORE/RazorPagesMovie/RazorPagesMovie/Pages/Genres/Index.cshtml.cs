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

        public IList<Genre> Genre { get;set; }
        public SelectList SortOptions { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortQuery { get; set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genre.Include("Movies").ToListAsync();

            List<string> options = new List<string>
            {
                "By name (asc)",
                "By name (desc)",
                "By number of movies (asc)",
                "By number of movies (desc)"
            };

            int g = 0;

            if (!string.IsNullOrEmpty(SortQuery))
            {

                if (SortQuery == "By name (asc)")
                    Genre = Genre.OrderBy(s => s.GenreTitle).ToList();
                else if (SortQuery == "By name (desc)")
                    Genre = Genre.OrderByDescending(s => s.GenreTitle).ToList();
                else if (SortQuery == "By number of movies (asc)")
                    Genre = Genre.OrderBy(s => s.Movies.Count).ToList();
                else if (SortQuery == "By number of movies (desc)")
                    Genre = Genre.OrderByDescending(s => s.Movies.Count).ToList();
            }

            SortOptions = new SelectList(options);
        }
    }
}
