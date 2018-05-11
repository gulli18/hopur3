using System;
using BookCave.Models.InputModels;

namespace BookCave.Services
{
  public class ContactService : IContactService
  {
    public void ProcessContact(InputPaymentModel model)
    {
      if (string.IsNullOrEmpty(model.BillingPropertyName))
      {
        throw new Exception("Property name is missing");
      }
      if (string.IsNullOrEmpty(model.BillingStreetAdress))
      {
        throw new Exception("Street Address is missing");
      }
      if (string.IsNullOrEmpty(model.BillingTownCity))
      {
        throw new Exception("Missing");
      }
    
    }

    public void ProcessContact(InputCardModel model)
    {
     /* if (string.IsNullOrEmpty(model.CardHolderName))
      {
        throw new Exception("Property name is missing");
      }*/
    }
  }
}