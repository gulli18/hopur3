using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
  public class InputPaymentModel
  {
    [Required(ErrorMessage = "Please Enter Property Name")]
    public string BillingPropertyName { get; set; }
    [Required(ErrorMessage = "Please Enter Street Address")]
    public string BillingStreetAdress { get; set; }
    [Required(ErrorMessage = "Please Enter City")]
    public string BillingTownCity { get; set; }
    [Required(ErrorMessage = "Please Enter Post Code")]
    public int BillingZipPostcode { get; set; }
    [Required(ErrorMessage = "Please Enter Country")]
    public string BillingCountry { get; set; }
    [Required(ErrorMessage = "Please Enter Property Name")]
    public string ShippingPropertyName { get; set; }
    [Required(ErrorMessage = "Please Enter Street Address")]
    public string ShippingStreetAdress { get; set; }
    [Required(ErrorMessage = "Please Enter City")]
    public string ShippingTownCity { get; set; }
    [Required(ErrorMessage = "Please Enter Post Code")]
    public int ShippingPostcode { get; set; }
    [Required(ErrorMessage = "Please Enter Country")]
    public string ShippingCountry { get; set; }
  }
}