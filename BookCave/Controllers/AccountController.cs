using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using System.Threading.Tasks;
using BookCave.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
            Image = user.Image,
            BillingAdressId = user.BillingAdressId,
            ShippingAdressId = user.ShippingAdressId,
            CardInformationId = user.CardInformationId,
            OrderListId = user.OrderListId

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

    }
}