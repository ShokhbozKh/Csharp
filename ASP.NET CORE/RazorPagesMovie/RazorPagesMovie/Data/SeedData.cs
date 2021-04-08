using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Models;
using Bogus;

namespace RazorPagesMovie.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>());

            var faker = new Faker("en");
            var movieNames = GetMovieNames();
            var genreNames = GetGenresNames();

            foreach(string genreTitle in genreNames)
            {
                context.Genre.Add(new Genre { GenreTitle = genreTitle });
            }

            context.SaveChanges();
            
            foreach(string movieTitle in movieNames)
            {
                context.Movie.Add(
                    new Movie
                    {
                        Title = movieTitle,
                        ReleaseDate = GetRandomDate(),
                        Price = GetRandomPrice(5.5, 30.5),
                        Rating = GetRandomRating(),
                        Description = faker.Lorem.Sentence(20, 100),
                        GenreId = GetRandomGenreId()
                    }
               );
            }

            context.SaveChanges();
        }

        private static List<string> GetMovieNames()
        {
            return new List<string>
            {
                "All in This Tea", "American Beer", "Beer Wars", "Bill W.", "A Bite of China", "Black Coffee",
                "Black Gold", "Blood into Wine", "Chez Schwartz", "Dive!", "Fat Head", "Fine Food, Fine Pastries, Open 6 to 9",
                "The Five Obstructions", "The Fruit Hunters", "Garlic Is as Good as Ten Mothers", "Global Steak",
                "Gutbusters", "I Like Killing Flies", "Ingredients", "Jiro Dreams of Sushi", "Kings of Pastry",
                "Know Your Mushrooms", "A Matter of Taste", "Mondovino", "Off the Menu: The Last Days of Chasen's",
                "Our Daily Bread", "Paavo, a Life in Five Courses", "Pennsylvania Diners and Other Roadside Restaurants",
                "A Place at the Table", "Red Obsession", "The Restaurant Inspector", "The Search for General Tso",
                "Soul Food Junkies", "State of Bacon", "A State of Vine", "Super Size Me[1]",
                "Terminal Bar", "Unacceptable Levels", "Wine for the Confused", "Devour the Earth", "Earthlings",
                "Fat, Sick and Nearly Dead", "Food Matters", "Forks over Knives", "Go Further", 
                "Meet Your Meat", "Peaceable Kingdom", "Planeat", "A Sacred Duty", "Vegucated", "At Sachem Farm",
                "Autumn Tale", "Blood into Wine", "Bottle Shock", "A Good Year", "Mondovino", "Red Obsession",
                "Sideways", "A State of Vine", "Story of Wine", "This Earth Is Mine", "Vagabond", "The Vineyard",
                "Wine for the Confused", "Year of the Comet", "Babette's Feast", "A Fairy Secret", "A Fashion Fairytale",
                "Big Night", "The Big Restaurant", "Burnt", "Chef (2014)", "The Chef (2012)", "The Chinese Feast",
                "Chocolat", "The Cook, the Thief, His Wife & Her Lover", "Cook Up a Storm", "Cooking with Stella",
                "Dinner Rush", "Eat Drink Man Woman", "Estômago", "The God of Cookery", "Le Grand Chef", "Le Grand Chef 2: Kimchi Battle",
                "La Grande Bouffe", "Gulabjaam (2018)", "Ham and Eggs", "Haute Cuisine", "The Hundred-Foot Journey",
                "Jiro Dreams of Sushi", "Julie & Julia", "Just Desserts", "Krazy Kat & Ignatz Mouse Discuss the Letter 'G'"
            };
        }

        private static List<string> GetGenresNames()
        {
            return new List<string>
            {
                "Action",
                "Drama",
                "Horror",
                "Comedy",
                "Science fiction",
                "Romance",
                "Documentary",
                "Crime film",
                "Thriller",
            };
        }

        private static DateTime GetRandomDate()
        {
            Random rnd = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

        private static decimal GetRandomPrice(double minimum, double maximum)
        {
            Random rnd = new Random();
            return (decimal)(rnd.NextDouble() * (maximum - minimum) + minimum);
        }

        private static string GetRandomRating()
        {
            List<string> ratings = new List<string>
            {
                "G",
                "PG",
                "PG-13",
                "R",
                "NC-17"
            };
            
            Random rnd = new Random();

            return ratings.ElementAt(rnd.Next(0, ratings.Count));
        }

        private static int GetRandomGenreId()
        {
            Random rnd = new Random();
            return rnd.Next(1, 10);
        }
    }
}
