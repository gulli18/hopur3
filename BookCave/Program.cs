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
           SeedData();
           host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new DataContext();

            if (!db.Books.Any())
            {
            var initialBooks = new List<Book>()
            {
                new Book {
                    Title = "The Hobbit",
                    // AuthorId
                    Price = 0.0,
                    Rating = 0.0,
                    Quantity = 1000,
                    Format = "Hardcover",
                    Publisher = "George Allen & Unwin",
                    PublicationYear = 1937,
                    Language = "English",
                    PageCount = 304,
                    //Genre List<string>,
                    //Image
                },
                new Book {
                    Title = "The Shining",
                    // AuthorId
                    Price = 0.0,
                    Rating = 0.0,
                    Quantity = 1000,
                    Format = "Hardcover",
                    Publisher = "Doubleday",
                    PublicationYear = 1977,
                    Language = "English",
                    PageCount = 447,
                    //Genre List<string>,
                    //Image
                },
                new Book {
                    Title = "Fifty Shades of Grey",
                    // AuthorId
                    Price = 0.0,
                    Rating = 0.0,
                    Quantity = 1000,
                    Format = "Paperback",
                    Publisher = "Vintage Books",
                    PublicationYear = 2011,
                    Language = "English",
                    PageCount = 514,
                    //Genre List<string>,
                    //Image
                },
                new Book {
                    Title = "Binni Reykir",
                    // AuthorId
                    Price = 0.0,
                    Rating = 0.0,
                    Quantity = 1000,
                    Format = "Paperback",
                    Publisher = "Vintage Books",
                    PublicationYear = 2011,
                    Language = "English",
                    PageCount = 122,
                    //Genre List<string>,
                    //Image
                 }
            };
            db.AddRange(initialBooks);
            db.SaveChanges();
        }
        }

    }
}
