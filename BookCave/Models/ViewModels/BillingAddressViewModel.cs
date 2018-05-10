namespace BookCave.Models.ViewModels
{
  public class BillingAddressViewModel
  {
    public int Id { get; set; }
    public string PropertyName { get; set; }
    public string StreetAdress { get; set; }
    public string TownCity { get; set; }
    public int ZipPostcode { get; set; }
    public string Country { get; set; }
    public string UserId { get; set; }
  }
}