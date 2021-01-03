using Assignment_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_05
{
    class Program
    {
        static void Main()
        {
            /*
             * Strategy chosen -> Single table strategy
             * Income -> Item <- Expense -->> Discriminator: ItemType {0 or 1}
             * Category 1 - * Item
             */


            using var db = new BudgetContext();
            // Insert
            Console.WriteLine("---- Inserting Categories ----");

            List<Category> categoriesList = new List<Category> 
            {
                new Category { IdCategory = 1,  Name = "Salary", CategoryType = ItemType.Income},
                new Category { IdCategory = 2, Name = "Freelance", CategoryType = ItemType.Income},
                new Category { IdCategory = 3, Name = "Uber eats driving", CategoryType = ItemType.Income },
                new Category { IdCategory = 4, Name = "Other", CategoryType = ItemType.Income},
                new Category { IdCategory = 5, Name = "Housing", CategoryType = ItemType.Expense},
                new Category { IdCategory = 6, Name = "Education", CategoryType = ItemType.Expense},
                new Category { IdCategory = 7, Name = "Health", CategoryType = ItemType.Expense}
            };


            foreach (Category category in categoriesList)
            {
                db.Categories.Add(category);
            }
            db.SaveChanges();

            // Adding items to the database
            Console.WriteLine("---- Inserting items to the database ----");

            List<Item> items = new List<Item>
                {
                    new Income {AddedDate = DateTime.Now, Description = "Google", CategoryId = 1, TotalSum = 10000},
                    new Income {AddedDate = DateTime.Now, Description = "Resutarant website", CategoryId = 2, TotalSum = 5000},
                    new Income {AddedDate = DateTime.Now, Description = "No comments", CategoryId = 3, TotalSum = 1500},
                    new Expense {AddedDate = DateTime.Now, Description = "Rent for flat", CategoryId = 5, TotalSum = 2000},
                    new Expense {AddedDate = DateTime.Now, Description = "Electricity", CategoryId = 5, TotalSum = 150},
                    new Expense {AddedDate = DateTime.Now, Description = "Internet", CategoryId = 5, TotalSum = 300},
                    new Expense {AddedDate = DateTime.Now, Description = "College monthly fee", CategoryId = 6, TotalSum = 4000},
                    new Expense {AddedDate = DateTime.Now, Description = "Gym", CategoryId = 7, TotalSum = 200},
                };

            try
            {
                foreach (Item item in items)
                {
                    db.Items.Add(item);
                }
                db.SaveChanges();
                Console.WriteLine("Data saved succesfully");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong with code: {e.Message}");
            }

            // Read
            Console.WriteLine("---- Reading data from database ----");

            List<Item> incomes = new List<Item>();
            List<Item> expenses = new List<Item>();
            List<Category> categories = new List<Category>();
            try
            {
                incomes = db.Items.Where(s => s.Category.CategoryType == ItemType.Income).ToList();
                expenses = db.Items.Where(s => s.Category.CategoryType == ItemType.Expense).ToList();
                categories = db.Categories.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong with code: {e.Message}");
            }
            

            Console.WriteLine("----");
            Console.WriteLine("Incomes:");
            Console.WriteLine("----");
            int counter = 1;

            foreach (Item item in incomes)
            {
                Console.WriteLine($"{counter++} {item}");
            }

            Console.WriteLine("----");
            Console.WriteLine("Expenses:");
            Console.WriteLine("----");
            counter = 1;
            foreach (Item item in incomes)
            {
                Console.WriteLine($"{counter++} {item}");
            }

            Console.WriteLine("----");
            Console.WriteLine("Categories: ");
            Console.WriteLine("----");

            foreach (Category category in categories)
            {
                Console.Write($"Category: {category.Name} related items");
                foreach(Item item in category.Items)
                {
                    Console.WriteLine(item);
                }
            }


            // Update
            Console.WriteLine();
            Console.WriteLine("---- Updating data from Items");
            Console.WriteLine();

            int g = 0;
            try
            {
                var itemToUpdate = db.Items.Where(s => s.Category.Name == "Housing").FirstOrDefault();
                var ca = db.Categories.Where(s => s.Name == "Health").FirstOrDefault();
                Console.WriteLine($"to update -> {itemToUpdate}");
                itemToUpdate.Category = ca;
                db.Items.Update(itemToUpdate);

                db.SaveChanges();

                var updatedItem = db.Items.Where(s => s.Category.Name == "Health").ToList();

                foreach (Item item in updatedItem) Console.WriteLine(item);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Something went wrong with code: {e.Message}");
            }

            

            // Delete
            Console.WriteLine();
            Console.WriteLine("---- Deleting data from Items ----");
            Console.WriteLine();

            try
            {
                db.Items.RemoveRange(incomes);
                db.Items.RemoveRange(expenses);
                db.Categories.RemoveRange(categoriesList);

                db.SaveChanges();

                Console.WriteLine("---- Deletion has been succesfully completed");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong with code: {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
    }
}
