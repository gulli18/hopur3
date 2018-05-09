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
    public class GenreController : Controller
    {
        private BookService _bookService;
        
        public GenreController()
        {
            _bookService = new BookService();
        }

        public IActionResult Horror()
        {
             var horrormovies = _bookService.getHorror();

            return View(horrormovies);
        }

        
    }
}