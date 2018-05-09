namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // AuthorId
        
        public double Price { get; set; }
        public double Rating { get; set; }
        public int Quantity { get; set; }
        public string Format { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string Language { get; set; }
        public int PageCount { get; set; }

        // public int MyProperty { get; set; }

        public string Image { get; set; }
    }


    /*public class Bookecategories {
        public listi<BookListViewModel> thriller
    }*/
}