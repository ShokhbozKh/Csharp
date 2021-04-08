﻿using System.Collections.Generic;
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

        // filtering
        [BindProperty]
        public string MovieGenre { get; set; }

        // searching
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // track current sort and filter
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSearch { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public PaginatedList<Movie> Movies { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, 
            string movieGenre, int? pageIndex)
        {            
            // Fetch Movies and Genres data
            var movies = _context.Movie.Include("Genre");

            var genreQuery = _context.Genre
                            .OrderBy(g => g.GenreTitle)
                            .Select(g => g.GenreTitle);

            // set the sort order
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            PriceSort = sortOrder == "price" ? "price_desc" : "price";
            RatingSort = sortOrder == "rating" ? "rating_desc" : "rating";

            if (searchString != null )
            {
                pageIndex = 1;
            }
            else
            {
                CurrentSort = sortOrder;
                CurrentSearch = searchString;
                CurrentFilter = movieGenre;
            }

            // Order by columns
            movies = sortOrder switch
            {
                "title_desc" => movies.OrderByDescending(m => m.Title),
                "price" => movies.OrderBy(m => m.Price),
                "price_desc" => movies.OrderByDescending(m => m.Price),
                "rating" => movies.OrderBy(m => m.Rating),
                "rating_desc" => movies.OrderByDescending(m => m.Rating),
                _ => movies.OrderBy(m => m.Title),
            };

            // Filter by search input
            SearchString = searchString;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            // Filter by selectlist genre title
            MovieGenre = movieGenre;
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre.GenreTitle == MovieGenre);
            }

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
