namespace BookCave.Data.EntityModels
{
    public class Card
    {
        public int Id { get; set; }
        public string CardHolderName { get; set; }
        public int CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int SecurityNumber { get; set; }
        public string UserId { get; set; }
    }
}