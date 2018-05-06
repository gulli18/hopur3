using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;

        public BookRepo()
        {
            _db = new DataContext();
        }
        public List<BookDetailedViewModel> GetAllBooks()
        {
            var books = (from a in _db.Books
                        select new BookDetailedViewModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Price = a.Price,
                            Rating = a.Rating,
                            Quantity = a.Quantity,
                            Format = a.Format,
                            Publisher = a.Publisher,
                            PublicationYear = a.PublicationYear,
                            Language = a.Language,
                            PageCount = a.PageCount,
                            Image = a.Image
                        }).ToList();
                        
            return books;
        }
    }
}