using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    public class PaymentController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public PaymentController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Delivery()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(new BillingAddressViewModel
            {
                StreetAdress = user.BillingStreetAdress,
                TownCity = user.BillingTownCity,
                ZipPostcode = user.BillingZipPostcode,
                Country = user.BillingCountry
            });
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