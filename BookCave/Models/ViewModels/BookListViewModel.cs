namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Format { get; set; }
       
        public string Image { get; set; }
    }
}