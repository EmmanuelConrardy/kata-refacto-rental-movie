namespace MovieRental
{
    public class Movie
    {
        public string Title { get; }
        public PriceCode PriceCode { get; }

        public Movie(string title, PriceCode priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
    }
}
