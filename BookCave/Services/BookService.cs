using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;
        public BookService()
        {
            _bookRepo = new BookRepo();
        }
        public List<BookListViewModel> GetAllBooks()
        {
            var books = _bookRepo.GetAllBooks();
            return books;
        }

        public List<BookListViewModel> GetSearchResults(string searchTerm)
        {
            var searchResults = _bookRepo.GetSearchResults(searchTerm);
            return searchResults;
        }

        public BookDetailedViewModel GetBook(int? id)
        {
            var oneBook = _bookRepo.GetBook(id);
            return oneBook;
        }

        public List<BookListViewModel> getHorror()
        {
            var horrormovies = _bookRepo.getHorror();
            return horrormovies;
        }
    }
}