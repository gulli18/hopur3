using System;
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

        public BookListViewModel GetBookListViewModel(BookListViewModel book)
        {
            var addedBook = _bookRepo.GetBookListViewModel(book);
            return addedBook;
        }

        public List<BookListViewModel> getHorror()
        {
            var horrormovies = _bookRepo.getHorror();
            return horrormovies;
        }

        public List<BookListViewModel> GetTop10Rated()
        {
            var top10rated = _bookRepo.GetTop10Rated();
            return top10rated;
        }

        public List<BookListViewModel> GetTop10RatedAudio()
        {
            var top10RatedAudio = _bookRepo.GetTop10RatedAudio();
            return top10RatedAudio;
        }

        public List<BookListViewModel> GetBooksByGenre(string genre)
        {
            var booksByGenre = _bookRepo.GetBooksByGenre(genre);
            return booksByGenre;
        }
        public BookDetailedViewModel GetWinner()
        {
            var chosenBook = _bookRepo.GetWinner();
            return chosenBook;
        }
    }
}