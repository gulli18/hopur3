using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
  public class InputCardModel
    {
       [Required(ErrorMessage = "Please Enter Cardholder's Name")]
        public string CardHolderName { get; set; }
        [Required(ErrorMessage = "Please Enter Cardnumber")]
        public int CardNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Month")]
        public int Month { get; set; }
        [Required(ErrorMessage = "Please Enter Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please Enter Security Number")]
        public int SecurityNumber { get; set; }
    }
}