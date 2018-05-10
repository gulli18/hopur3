using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;
using System;
using BookCave.Data.EntityModels;

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
            var books = (from b in _db.Books
                         join a in _db.Authors
                         on b.AuthorsId equals a.Id
                         select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Author = a.Name,
                            AuthorsId =a.Id,
                            Format = b.Format,
                            Price = b.Price,
                            Rating = b.Rating
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
                                    Format = b.Format,
                                    Image = b.Image
                                }).ToList();

            return searchResults;
        }

        public BookDetailedViewModel GetBook(int? id)
        {
            var oneBook = (from b in _db.Books
                           join a in _db.Authors
                           on b.AuthorsId equals a.Id
                           where b.Id == id
                           select new BookDetailedViewModel
                           {
                            Id = b.Id,
                            Title = b.Title,
                            Author = a.Name,
                            AuthorsId = a.Id,
                            Price = b.Price,
                            Rating = b.Rating,
                            Format = b.Format,
                            Language = b.Language,
                            Genre = b.Genre,
                            Image = b.Image,
                            PageCount = b.PageCount,
                            ShortDescription = b.ShortDescription,
                            PublicationYear = b.PublicationYear,
                            Publisher = b.Publisher
                           }).SingleOrDefault();
            return oneBook;
        }

        public BookListViewModel GetBookListViewModel(BookListViewModel book)
        {
            var addedBook = (from b in _db.Books
                            join a in _db.Authors on b.AuthorsId equals a.Id
                            where b.Id == book.Id
                            select new BookListViewModel
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Author = a.Name,
                                Rating = b.Rating,
                                Price = b.Price,
                                Format = b.Format,
                                Image = b.Image
                            }).SingleOrDefault();
            return addedBook;
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

        public List<BookListViewModel> GetTop10Rated()
        {
            var top10rated = (from b in _db.Books
                            join a in _db.Authors on b.AuthorsId equals a.Id
                            where b.Format != "Audiobook"
                            orderby b.Rating descending
                            select new BookListViewModel
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Author = a.Name,
                                Rating = b.Rating,
                                Format = b.Format,
                                Price = b.Price,
                                Image = b.Image
                            }).Take(10).ToList();
            return top10rated;
        }

        public List<BookListViewModel> GetTop10RatedAudio()
        {
            var top10RatedAudio = (from b in _db.Books
                                    join a in _db.Authors on b.AuthorsId equals a.Id
                                    where b.Format == "Audiobook"
                                    orderby b.Rating descending
                                    select new BookListViewModel
                                    {
                                        Id = b.Id,
                                        Title = b.Title,
                                        Author = a.Name,
                                        Rating = b.Rating,
                                        Format = b.Format,
                                        Price = b.Price,
                                        Image = b.Image
                                    }).Take(10).ToList();
            return top10RatedAudio;
        }

        public List<BookListViewModel> GetBooksByGenre(string genre)
        {
            var booksByGenre = (from b in _db.Books
                                join a in _db.Authors on b.AuthorsId equals a.Id
                                where b.Genre.ToLower() == genre.ToLower() && b.Format != "Audiobook"
                                select new BookListViewModel
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    Author = a.Name,
                                    Rating = b.Rating,
                                    Format = b.Format,
                                    Price = b.Price,
                                    Image = b.Image
                                }).ToList();
            return booksByGenre;
        }

        public List<BookListViewModel> GetAudioBooksByGenre(string genre)
        {
            var audioBooksByGenre = (from b in _db.Books
                                join a in _db.Authors on b.AuthorsId equals a.Id
                                where b.Genre.ToLower() == genre.ToLower() && b.Format == "Audiobook"
                                select new BookListViewModel
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    Author = a.Name,
                                    Rating = b.Rating,
                                    Format = b.Format,
                                    Price = b.Price,
                                    Image = b.Image
                                }).ToList();
            return audioBooksByGenre;
        }

        public BookDetailedViewModel GetWinner()
        {
            Random rnd = new Random();
            int randomId = rnd.Next(1, _db.Books.Count() + 1);
            var book = (from b in _db.Books
                        join a in _db.Authors on b.AuthorsId equals a.Id
                        where b.Id == randomId
                        select new BookDetailedViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Author = a.Name,
                            Price = b.Price,
                            Rating = b.Rating,
                            Format = b.Format,
                            Language = b.Language,
                            Genre = b.Genre,
                            Image = b.Image,
                            PageCount = b.PageCount,
                            ShortDescription = b.ShortDescription,
                            PublicationYear = b.PublicationYear,
                            Publisher = b.Publisher
                        }).SingleOrDefault();
            while (book == null)
            {
                book = GetWinner();
            }
            return book;
        }
  }
}