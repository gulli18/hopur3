using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        public List<BookListViewModel> GetAllBooks()
        {
            var books = new List<BookListViewModel>
            {
                new BookListViewModel {
                    Id = 1,
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
                new BookListViewModel {
                    Id = 2,
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
                new BookListViewModel {
                    Id = 3,
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
                }
            };

            return books;
        }
    }
}