using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using System.Threading.Tasks;
using BookCave.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
      private readonly SignInManager<ApplicationUser> _signInManager;
      private readonly UserManager<ApplicationUser> _userManager;        
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
          _signInManager = signInManager;
          _userManager = userManager;
        }

        public IActionResult Register()
        {
          return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
          if(!ModelState.IsValid) 
          {
            return View(); 
          }
          var user = new ApplicationUser 
          {
            UserName = model.Email,
            Email = model.Email
          };

          var result = await _userManager.CreateAsync(user, model.Password);
          if(result.Succeeded)
          {

            await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName}"));
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
          }
          return View();
        }

        public IActionResult Login()
        {
          return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
          if(!ModelState.IsValid)
          {
            return View();
          }

          var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
          if(result.Succeeded)
          {
            return RedirectToAction("Index", "Home");
          }
          return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
          await _signInManager.SignOutAsync();
          return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
          return View();
        }

        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
          var user = await _userManager.GetUserAsync(User);

          return View(new ProfileViewModel {
            FirstName = user.FirstName,
            LastName = user.LastName,
            FavoriteBook = user.FavoriteBook,
            Age = user.Age,
            Image = user.Image

          });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyProfile(ProfileViewModel model)
        {
          var user =await _userManager.GetUserAsync(User);

          user.FirstName = model.FirstName;
          user.LastName = model.LastName;
          user.FavoriteBook = model.FavoriteBook;
          user.Age = model.Age;
          user.Image = model.Image;

          await _userManager.UpdateAsync(user);

          return View(model);
        }

        [Authorize]
         public async Task<IActionResult> MyBillingAddress()
         {
           var user = await _userManager.GetUserAsync(User);
           
            return View(new BillingAddressViewModel {
            PropertyName = user.BillingPropertyName,
            StreetAdress = user.BillingStreetAdress,
            TownCity = user.BillingTownCity,
            ZipPostcode = user.BillingZipPostcode,
            Country = user.BillingCountry
          });
         }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyBillingAddress(BillingAddressViewModel model)
        {
          var user =await _userManager.GetUserAsync(User);

          user.BillingPropertyName = model.PropertyName;
          user.BillingStreetAdress = model.StreetAdress;
          user.BillingTownCity = model.TownCity;
          user.BillingZipPostcode = model.ZipPostcode;
          user.BillingCountry = model.Country;

          await _userManager.UpdateAsync(user);

          return View(model);
        }

        [Authorize]
         public async Task<IActionResult> MyShippingAddress()
         {
           var user = await _userManager.GetUserAsync(User);
           
            return View(new ShippingAddressViewModel {
            PropertyName = user.ShippingPropertyName,
            StreetAdress = user.ShippingStreetAdress,
            TownCity = user.ShippingTownCity,
            Postcode = user.ShippingZipPostcode,
            Country = user.ShippingCountry
          });
         }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyShippingAddress(ShippingAddressViewModel model)
        {
          var user =await _userManager.GetUserAsync(User);

          user.ShippingPropertyName = model.PropertyName;
          user.ShippingStreetAdress = model.StreetAdress;
          user.ShippingTownCity = model.TownCity;
          user.ShippingZipPostcode = model.Postcode;
          user.ShippingCountry = model.Country;

          await _userManager.UpdateAsync(user);

          return View(model);
        }

         [Authorize]
         public async Task<IActionResult> Index(ProfileViewModel model)
         {
           var user =await _userManager.GetUserAsync(User);

           model.FirstName = user.FirstName;
           model.LastName = user.LastName;
           model.FavoriteBook = user.FavoriteBook;
           model.Image = user.Image;
           model.Age = user.Age;
           
           return View(model);
         }

         [Authorize]
         public async Task<IActionResult> MyCardInformation()
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
        public async Task<IActionResult> MyCardInformation(CardViewModel model)
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



    }
}