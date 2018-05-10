using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class CartController : Controller
    {
        private BookService _bookService;
        private List<BookListViewModel> _cart;
        
        public CartController()
        {
            _bookService = new BookService();
            _cart =  new List<BookListViewModel>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BookListViewModel book)
        {
            if(book.Id != 0) {
                var addedBook = _bookService.GetBookListViewModel(book);

                if(addedBook != null) {
                    _cart.Add(addedBook);
                }
                return View(_cart);
            }
            return View();
        }

    }
}