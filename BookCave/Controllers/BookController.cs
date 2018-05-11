using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        
        public BookController()
        {
            _bookService = new BookService();
        }

        public IActionResult Index(string searchTerm)
        {
            if(searchTerm != null) {
                var searchResults = _bookService.GetSearchResults(searchTerm);

                ViewBag.searchTerm = searchTerm;
                if(searchResults.Any()) {
                     return View(searchResults);
                }
                ViewBag.header = "Your search did not return any results!";
                return View("NotFound");
            }
            ViewBag.header = "Your search did not return any results!";
            return View("NotFound");
        }

        public IActionResult Details(int? id)
        {
            var oneBook = _bookService.GetBook(id); 
            if(oneBook != null) {
                return View(oneBook);
            }
            ViewBag.header = "Book not found!";
            return View("Notfound");
        }

        public IActionResult Top10Rated ()
        {
            var top10Rated = _bookService.GetTop10Rated();

            return View(top10Rated);
        }

        public IActionResult Top10RatedAudio ()
        {
            var top10RatedAudio = _bookService.GetTop10RatedAudio();

            return View(top10RatedAudio);
        }

        public IActionResult BestSellers ()
        {
            var top10Sold = _bookService.GetBestSellers();

            return View(top10Sold);
        }
    
        public IActionResult BestSellersAudio ()
        {
            var top10SoldAudio = _bookService.GetBestSellersAudio();

            return View(top10SoldAudio);
        }

        public IActionResult Genre(string genre)
        {
            var booksByGenre = _bookService.GetBooksByGenre(genre);
            
            if(booksByGenre.Any()) {
                ViewBag.genreTitle = genre.ToUpper();
                return View(booksByGenre);
            }

            ViewBag.header = "Genre not found!";
            return View("NotFound");
        }

        public IActionResult GenreAudio(string genre)
        {
            var audioBooksByGenre = _bookService.GetAudioBooksByGenre(genre);

            if(audioBooksByGenre.Any()) {
                ViewBag.genreTitle = genre.ToUpper();
                return View(audioBooksByGenre);
            }

            ViewBag.header = "Genre not found!";
            return View("NotFound");
        }
        public IActionResult ChooseForMe()
        {
            return View();
        }

        public IActionResult GetWinner()
        {
            var chosenBook = _bookService.GetWinner();

            if(chosenBook != null) {
                return Json(chosenBook);
            }

            ViewBag.header = "Book not found!";
            return View("NotFound");
        }

        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if(exceptionFeature != null) {
                string path = exceptionFeature.Path;
                Exception ex = exceptionFeature.Error;
            }
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}