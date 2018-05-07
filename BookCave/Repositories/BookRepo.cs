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
        public List<BookListViewModel> GetAllBooks()
        {
            var books = (from a in _db.Books
                         join ar in _db.Authors
                         on a.AuthorsId equals ar.Id
                         select new BookListViewModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Author = ar.Name,
                            Price = a.Price,
                            Rating = a.Rating
                        }).ToList();
                        
            return books;
        }

        public BookDetailedViewModel GetBook(int? id)
        {
            var oneBook = (from a in _db.Books
                           join ar in _db.Authors
                           on a.AuthorsId equals ar.Id
                           where a.Id == id
                           select new BookDetailedViewModel
                           {
                            Id = a.Id,
                            Title = a.Title,
                            Author = ar.Name,
                            Price = a.Price,
                            Rating = a.Rating,
                            Format = a.Format,
                            Language = a.Language,
                            Image = a.Image,
                            PageCount = a.PageCount,
                            ShortDescription = a.ShortDescription,
                            PublicationYear = a.PublicationYear,
                            Publisher = a.Publisher
                           }).SingleOrDefault();
            return oneBook;
        }


        public List<BookListViewModel> getHorror()
        {
            var horrormovies = (from a in _db.Books
                                where a.Genre == "Horror"
                                select new BookListViewModel
                                {
                                Id = a.Id,
                                Title = a.Title,
                                Price = a.Price,
                                Rating = a.Rating,
                                Image = a.Image
                                }).ToList();
            return horrormovies;
        }

    }
}