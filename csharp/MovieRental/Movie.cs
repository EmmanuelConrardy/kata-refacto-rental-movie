namespace MovieRental
{
    public class Movie
    {
        public string Title { get; }

        private static MoviePricer moviePricer = new MoviePricer();
        private MoviePrice pricer;

        public Movie(string title, PriceCode priceCode)
        {
            Title = title;
            pricer = moviePricer[priceCode];
        }

        public int GetFrequentRenterPointsFor(uint daysRented)
        {
            return pricer.GetFrequentRenterPointsFor(daysRented);
        }

        public double GetAmountFor(uint daysRented)
        {
            return pricer.GetAmountFor(daysRented);
        }
    }
}
