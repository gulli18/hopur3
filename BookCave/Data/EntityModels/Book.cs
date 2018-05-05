namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorsId { get; set; }
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
}