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
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    public class PaymentController : Controller
    {
      private readonly SignInManager<ApplicationUser> _signInManager;
      private readonly UserManager<ApplicationUser> _userManager;   
      private readonly IContactService _contactService;     
        public PaymentController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IContactService contactService)
        {
          _signInManager = signInManager;
          _userManager = userManager;
          _contactService = contactService;
        }

        [Authorize]
         public async Task<IActionResult> Delivery()
         {
           var user = await _userManager.GetUserAsync(User);
            return View(new InputPaymentModel {
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
        public async Task<IActionResult> Delivery(InputPaymentModel model)
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
          if (!ModelState.IsValid)
          {
            ViewData["ErrorMessage"]= "error";
            return View(model);
          }
          await _userManager.UpdateAsync(user);
          _contactService.ProcessContact(model);
          return View(model);
        }

        [Authorize]
         public async Task<IActionResult> Pay()
         {
           var user = await _userManager.GetUserAsync(User);
           
            return View(new InputCardModel {
            CardHolderName = user.CardHolderName,
            CardNumber = user.CardNumber,
            Month = user.Month,
            Year = user.Year,
            SecurityNumber = user.SecurityNumber
          });
         }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Pay(InputCardModel model)
        {
          var user =await _userManager.GetUserAsync(User);

          user.CardHolderName = model.CardHolderName;
          user.CardNumber = model.CardNumber;
          user.Month = model.Month;
          user.Year = model.Year;
          user.SecurityNumber = model.SecurityNumber;
      
          await _userManager.UpdateAsync(user);
            if (!ModelState.IsValid)
          {
            ViewData["ErrorMessage"]= "error";
            return View(model);
          }
         _contactService.ProcessContact(model);
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