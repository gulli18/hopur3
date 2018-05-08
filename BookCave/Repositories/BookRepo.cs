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
                            AuthorsId = ar.Id,
                            Price = a.Price,
                            Rating = a.Rating
                        }).ToList();
                        
            return books;
        }

        public List<BookListViewModel> GetSearchResults(string searchTerm)
        {
            var searchResults = (from b in _db.Books
                                join a in _db.Authors on b.AuthorsId equals a.Id 
                                where b.Title.ToLower().Contains(searchTerm.ToLower()) || a.Name.ToLower().Contains(searchTerm.ToLower())
                                select new BookListViewModel
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    Author = a.Name,
                                    Rating = b.Rating,
                                    Price = b.Price,
                                    Image = b.Image
                                }).ToList();

            return searchResults;
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
                            AuthorsId = ar.Id,
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