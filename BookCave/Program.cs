using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = BuildWebHost(args);
           //SeedData();
           host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new DataContext();

            
            
         var initialBooks = new List<Book>()
            {
                new Book 
                {
                    Title = "The Hobbit",
                    AuthorsId = 0,
                    Price = 0.0,
                    Rating = 0.0,
                    Quantity = 1000,
                    Format = "Hardcover",
                    Publisher = "George Allen & Unwin",
                    PublicationYear = 1937,
                    Language = "English",
                    PageCount = 304,
                    Genre = "Horror",
                    SoldCount = 500,
                    Image = "https://i.pinimg.com/736x/5b/db/6b/5bdb6bf7e2b394e945f8a7702d3ff067--hobbit-book-el-hobbit.jpg",
                    ShortDescription = "Bilbo Baggins is a hobbit who enjoys a comfortable, unambitious life, rarely traveling any farther than his pantry or cellar. But his contentment is disturbed when the wizard Gandalf and a company of dwarves arrive on his doorstep one day to whisk him away on an adventure. They have launched a plot to raid the treasure hoard guarded by Smaug the Magnificent, a large and very dangerous dragon. Bilbo reluctantly joins their quest, unaware that on his journey to the Lonely Mountain he will encounter both a magic ring and a frightening creature known as Gollum."
                 }
                 };
            db.AddRange(initialBooks);
            db.SaveChanges();
            
        }

    }
}
