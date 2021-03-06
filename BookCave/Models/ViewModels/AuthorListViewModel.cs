using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
  public class AuthorListViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }

    public int Popularity { get; set; }

    public string Image { get; set; }
    public List<BookListViewModel> Book { get; set; }
  }
}