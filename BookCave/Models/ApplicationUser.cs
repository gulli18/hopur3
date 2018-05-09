using System.Collections.Generic;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FavoriteBook { get; set; }
    public string Age { get; set; }
    public string Image { get; set; }
    public string BillingAdressId { get; set; }
    public string ShippingAdressId { get; set; }
    public string CardInformationId { get; set; }
    public string OrderListId { get; set; }
  }
}