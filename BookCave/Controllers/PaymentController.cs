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
    public class PaymentController : Controller
    {
       
        
        public PaymentController()
        {
            
        }

        public IActionResult Delivery()
        {
            return View();
        }

        public IActionResult Pay()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}