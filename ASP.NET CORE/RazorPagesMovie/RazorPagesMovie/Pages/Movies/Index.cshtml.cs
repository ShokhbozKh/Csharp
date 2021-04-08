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
        public string TitleSort { get; set; }
        public string PriceSort { get; set; }
        public string RatingSort { get; set; }
        public string DateSort { get; set; }

        // track current sort and filter
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSearch { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public PaginatedList<Movie> Movies { get; set; }
        public int MoviesCount { get; set; }

        public async Task OnGetAsync(string sortBy, string searchString, 
            string genreTitle, int? pageIndex)
        {            
            // Fetch Movies and Genres data
            var movies = _context.Movie.Include("Genre");

            var genreQuery = _context.Genre
                            .OrderBy(g => g.GenreTitle)
                            .Select(g => g.GenreTitle);

            // set the sort order
            TitleSort = string.IsNullOrEmpty(sortBy) ? "title_desc" : "";
            PriceSort = sortBy == "price" ? "price_desc" : "price";
            RatingSort = sortBy == "rating" ? "rating_desc" : "rating";
            DateSort = sortBy == "releaseDate" ? "releaseDate_desc" : "releaseDate";

            CurrentSort = sortBy;
            CurrentSearch = searchString;
            CurrentFilter = genreTitle;

            // Order by columns
            movies = sortBy switch
            {
                "title_desc" => movies.OrderByDescending(m => m.Title),
                "price" => movies.OrderBy(m => m.Price),
                "price_desc" => movies.OrderByDescending(m => m.Price),
                "rating" => movies.OrderBy(m => m.Rating),
                "rating_desc" => movies.OrderByDescending(m => m.Rating),
                "releaseDate" => movies.OrderBy(m => m.ReleaseDate),
                "releaseDate_desc" => movies.OrderByDescending(m => m.ReleaseDate),
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
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            MoviesCount = movies.ToList().Count;

            // Get the page size (no. of items per page) or set default 5,
            // make new PaginatedList
            var pageSize = _configuration.GetValue("PageSize", 5);
            Movies = await PaginatedList<Movie>.CreateAsync(
                movies.AsNoTracking(), pageIndex ?? 1, pageSize);

            Genres = new SelectList(await genreQuery.ToListAsync());
            
            //int deb = 0;
        }
    }
}
