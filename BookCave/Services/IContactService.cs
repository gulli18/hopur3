using BookCave.Models.InputModels;

namespace BookCave.Services
{
  public interface IContactService
  {
      void ProcessContact(InputPaymentModel model);
      void ProcessContact(InputCardModel model);
  }
}