using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

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
                return View("NotFound");
            }
            return View("NotFound");
        }

        public IActionResult Details(int? id)
        {
            var oneBook = _bookService.GetBook(id);             
            return View(oneBook);
        }
    }
}