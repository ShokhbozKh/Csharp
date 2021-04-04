using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>());
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Genre.AddRange(
                new Genre
                {
                    GenreTitle = "Action",
                },

                new Genre
                {
                    GenreTitle = "Adventure",
                },

                new Genre
                {
                    GenreTitle = "Crime and mystery",
                },

                new Genre
                {
                    GenreTitle = "Comedy",
                },

                new Genre
                {
                    GenreTitle = "Fantasy",
                },

                new Genre
                {
                    GenreTitle = "Historical",
                }
            );

            context.SaveChanges();

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = context.Genre.Where(s => s.GenreTitle == "Historical").FirstOrDefault(),
                    Price = 7.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = context.Genre.Where(s => s.GenreTitle == "Action").FirstOrDefault(),
                    Price = 8.99M,
                    Rating = "C"
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = context.Genre.Where(s => s.GenreTitle == "Fantasy").FirstOrDefault(),
                    Price = 9.99M,
                    Rating = "G"
                },

                new Movie
                {
                    Title = "Black Window",
                    ReleaseDate = DateTime.Parse("1999-4-15"),
                    Genre = context.Genre.Where(s => s.GenreTitle == "Historical").FirstOrDefault(),
                    Price = 5.99M,
                    Rating = "C"
                },

                new Movie
                {
                    Title = "The Father",
                    ReleaseDate = DateTime.Parse("1952-4-14"),
                    Genre = context.Genre.Where(s => s.GenreTitle == "Historical").FirstOrDefault(),
                    Price = 8.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1982-3-23"),
                    Genre = context.Genre.Where(s => s.GenreTitle == "Adventure").FirstOrDefault(),
                    Price = 9.99M,
                    Rating = "B"
                }
            );
            context.SaveChanges();
        }
    }
}
