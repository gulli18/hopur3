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

            
            
            var initialAuthors = new List<Author>()
            {
                new Author {Name = "J.R.R Tolkien", Nationality = "Britain"},
                new Author {Name = "J.K Rowling", Nationality = "Britain"}
            };
            db.AddRange(initialAuthors);
            db.SaveChanges();
        
        }

    }
}
