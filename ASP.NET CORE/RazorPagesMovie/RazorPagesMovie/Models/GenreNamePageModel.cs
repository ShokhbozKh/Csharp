using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public class GenreNamePageModel : PageModel
    {
        public SelectList GenreNameSL { get; set; }

        public void PopulateGenresDropDownList(RazorPagesMovieContext context, object selectedGenre = null)
        {
            var genresQuery = from g in context.Genre
                             orderby g.GenreTitle
                             select g;

            GenreNameSL = new SelectList(genresQuery.AsNoTracking(), "GenreId", "GenreTitle", selectedGenre);
        }
    }
}
