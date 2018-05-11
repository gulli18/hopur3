using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookCave.Models.ViewModels;

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
           
            return View(new PaymentViewModel {
            ShippingPropertyName = user.ShippingPropertyName,
            ShippingStreetAdress = user.ShippingStreetAdress,
            ShippingTownCity = user.ShippingTownCity,
            ShippingPostcode = user.ShippingZipPostcode,
            ShippingCountry = user.ShippingCountry,
            BillingPropertyName = user.BillingPropertyName,
            BillingStreetAdress = user.BillingStreetAdress,
            BillingTownCity = user.BillingTownCity,
            BillingZipPostcode = user.BillingZipPostcode,
            BillingCountry = user.BillingCountry
          });
         }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delivery(PaymentViewModel model)
        {
          var user =await _userManager.GetUserAsync(User);

          user.ShippingPropertyName = model.ShippingPropertyName;
          user.ShippingStreetAdress = model.ShippingStreetAdress;
          user.ShippingTownCity = model.ShippingTownCity;
          user.ShippingZipPostcode = model.ShippingPostcode;
          user.ShippingCountry = model.ShippingCountry;
          user.BillingPropertyName = model.BillingPropertyName;
          user.BillingStreetAdress = model.BillingStreetAdress;
          user.BillingTownCity = model.BillingTownCity;
          user.BillingZipPostcode = model.BillingZipPostcode;
          user.BillingCountry = model.BillingCountry;

          await _userManager.UpdateAsync(user);

          return View(model);
        }

        [Authorize]
         public async Task<IActionResult> Pay()
         {
           var user = await _userManager.GetUserAsync(User);
           
            return View(new CardViewModel {
            CardHolderName = user.CardHolderName,
            CardNumber = user.CardNumber,
            Month = user.Month,
            Year = user.Year,
            SecurityNumber = user.SecurityNumber
          });
         }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Pay(CardViewModel model)
        {
          var user =await _userManager.GetUserAsync(User);

          user.CardHolderName = model.CardHolderName;
          user.CardNumber = model.CardNumber;
          user.Month = model.Month;
          user.Year = model.Year;
          user.SecurityNumber = model.SecurityNumber;

          await _userManager.UpdateAsync(user);

          return View(model);
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