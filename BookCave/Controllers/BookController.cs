using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;
        
        public BookController()
        {
            _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult Index(string searchTerm)
        {
            var books = _bookService.GetAllBooks();
            if(searchTerm != null) {
                var filteredBooks = (from b in books
                                    where b.Title.ToLower().Contains(searchTerm.ToLower())
                                    orderby b.Title ascending
                                    select new BookViewModel
                                    {
                                        Id = b.Id,
                                        Title = b.Title,
                                        Author = b.AuthorId,
                                        Rating = b.Rating,
                                        Price = b.Price
                                    }).ToList();
                if(filteredBooks.Any())
                {
                    return View(filteredBooks);
                }
                return View("Error");
            }
            return View("Error");
        }
    }
}