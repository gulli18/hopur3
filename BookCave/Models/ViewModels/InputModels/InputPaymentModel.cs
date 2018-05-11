using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
  public class InputPaymentModel
  {
    [Required(ErrorMessage = "Property name is required!")]
    public string BillingPropertyName { get; set; }
    [Required(ErrorMessage = "Street Address is required!")]
    public string BillingStreetAdress { get; set; }
    [Required(ErrorMessage = "Town/City is required!")]
    public string BillingTownCity { get; set; }
    [Required(ErrorMessage = "Post code is required!")]
    public int BillingZipPostcode { get; set; }
    [Required(ErrorMessage = "Country is required!")]
    public string BillingCountry { get; set; }
    [Required(ErrorMessage = "Property name is required!")]
    public string ShippingPropertyName { get; set; }
    [Required(ErrorMessage = "Street Adress is required!")]
    public string ShippingStreetAdress { get; set; }
    [Required(ErrorMessage = "Town/City is required!")]
    public string ShippingTownCity { get; set; }
    [Required(ErrorMessage = "Post code is required!")]
    public int ShippingPostcode { get; set; }
    [Required(ErrorMessage = "Country is required!")]
    public string ShippingCountry { get; set; }
  }
}