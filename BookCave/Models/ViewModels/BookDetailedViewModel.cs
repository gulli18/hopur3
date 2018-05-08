namespace BookCave.Models.ViewModels
{
    public class BookDetailedViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Format { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string Language { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
    }
}