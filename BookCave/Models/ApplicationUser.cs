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
    public string BillingPropertyName { get; set; }
    public string BillingStreetAdress { get; set; }
    public string BillingTownCity { get; set; }
    public int BillingZipPostcode { get; set; }
    public string BillingCountry { get; set; }
    public string ShippingPropertyName { get; set; }
    public string ShippingStreetAdress { get; set; }
    public string ShippingTownCity { get; set; }
    public int ShippingZipPostcode { get; set; }
    public string ShippingCountry { get; set; }
    public string CardHolderName { get; set; }
    public int CardNumber { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int SecurityNumber { get; set; }
    
  }
}