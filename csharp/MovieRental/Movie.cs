namespace MovieRental
{
    public class Movie
    {
        public string Title { get; }
        private PriceCode _priceCode;

        public Movie(string title, PriceCode priceCode)
        {
            Title = title;
            _priceCode = priceCode;
        }

        public bool Use(PriceCode priceCode)
        {
            return _priceCode == priceCode;
        }
        public PriceCode getPriceCode()
        {
            return _priceCode;
        }
    }
}
