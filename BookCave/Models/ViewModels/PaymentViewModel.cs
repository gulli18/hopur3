namespace BookCave.Models.ViewModels
{
  public class PaymentViewModel
  {
    public int Id { get; set; }
    public string BillingPropertyName { get; set; }
    public string BillingStreetAdress { get; set; }
    public string BillingTownCity { get; set; }
    public int BillingZipPostcode { get; set; }
    public string BillingCountry { get; set; }
    public string UserId { get; set; }
    public string ShippingPropertyName { get; set; }
    public string ShippingStreetAdress { get; set; }
    public string ShippingTownCity { get; set; }
    public int ShippingPostcode { get; set; }
    public string ShippingCountry { get; set; }
  }
}