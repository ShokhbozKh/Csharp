using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RazorPagesMovie.Helpers;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(RazorPagesMovieContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // sorting
        /*
        public string TitleSort { get; set; }
        public string PriceSort { get; set; }
        public string RatingSort { get; set; }
        public string DateSort { get; set; }
        */

        // track current sort and filter
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSearch { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public PaginatedList<Movie> Movies { get; set; }
        public SelectList SortOptions { get; set; }
        public int MoviesCount { get; set; }

        public async Task OnGetAsync(string sortBy, string searchString, 
            string genreTitle, int? pageIndex)
        {            
            // Fetch Movies and Genres data
            var movies = _context.Movie.Include("Genre");

            var genreQuery = _context.Genre
                            .OrderBy(g => g.GenreTitle)
                            .Select(g => g.GenreTitle);

            CurrentSort = sortBy;
            CurrentSearch = searchString;
            CurrentFilter = genreTitle;
            
            // Order by columns
            movies = sortBy switch
            {
                "Title (desc)" => movies.OrderByDescending(m => m.Title),
                "Price (asc)" => movies.OrderBy(m => m.Price),
                "Price (desc)" => movies.OrderByDescending(m => m.Price),
                "Release date (asc)" => movies.OrderBy(m => m.ReleaseDate),
                "Release date (desc)" => movies.OrderByDescending(m => m.ReleaseDate),
                "Rating (asc)" => movies.OrderBy(m => m.Rating),
                "Rating (desc)" => movies.OrderByDescending(m => m.Rating),
                _ => movies.OrderBy(m => m.Title),
            };

            // Filter by selectlist genre title
            if (!string.IsNullOrEmpty(genreTitle))
            {
                movies = movies.Where(m => m.Genre.GenreTitle == genreTitle);
            }

            // Filter by search input
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString) 
                || m.Description.Contains(searchString));
            }

            MoviesCount = movies.ToList().Count;

            // Get the page size (no. of items per page) or set default 5,
            // make new PaginatedList
            var pageSize = _configuration.GetValue("PageSize", 5);
            Movies = await PaginatedList<Movie>.CreateAsync(
                movies.AsNoTracking(), pageIndex ?? 1, pageSize);

            Genres = new SelectList(await genreQuery.ToListAsync());
            SortOptions = new SelectList(new List<string>
            {
                "Title (asc)",
                "Title (desc)",
                "Price (asc)",
                "Price (desc)",
                "Release date (asc)",
                "Release date (desc)",
                "Rating (asc)",
                "Rating (desc)",
            });
            
            //int deb = 0;
        }
    }
}
