using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
  public class InputCardModel
    {
       [Required(ErrorMessage = "Cardholder name is required!")]
        public string CardHolderName { get; set; }
        [Required(ErrorMessage = "Cardnumber is required!")]
        public int CardNumber { get; set; }
        [Required(ErrorMessage = "Month is required!")]
        public int Month { get; set; }
        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Security is required!")]
        public int SecurityNumber { get; set; }
    }
}