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
    public class ProfileController : Controller
    {
        private BookService _bookService;
        
        public ProfileController()
        {
            _bookService = new BookService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyDetails()
        {
            return View();
        }

        public IActionResult MyAdressBook()
        {
            return View();
        }

        public IActionResult MyCards()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            return View();
        }
    }
}