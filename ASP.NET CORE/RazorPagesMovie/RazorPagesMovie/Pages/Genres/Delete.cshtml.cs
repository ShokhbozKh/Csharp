using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Genres
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(RazorPagesMovieContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Genre Genre { get; set; }
        [Display(Name = "Movies list")]
        public SelectList MoviesSL { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? errorSaveChanges = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.Include(m => m.Movies).FirstOrDefaultAsync(m => m.GenreId == id);
            MoviesSL = new SelectList(Genre.Movies);

            if (Genre == null)
            {
                return NotFound();
            }

            if (errorSaveChanges.GetValueOrDefault())
            {
                ErrorMessage = $"Deleting {id} failed. Please, try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FindAsync(id);

            if(genre == null)
            {
                return NotFound();
            }

            try
            {
                _context.Genre.Remove(genre);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToPage("./Delete", new { id, saveChangesError = true });
            }

        }
    }
}
