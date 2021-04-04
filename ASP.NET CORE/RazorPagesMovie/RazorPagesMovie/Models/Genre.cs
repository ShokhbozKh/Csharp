using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }

        [Key]
        public int GenreId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        [Display(Name = "Genre Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string GenreTitle { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public override string ToString()
        {
            return GenreTitle;
        }
    }
}
