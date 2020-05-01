namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private uint _daysRented_;
        private MoviePrice pricer;
        private static MoviePricer moviePricer = new MoviePricer();

        public Rental(Movie movie, uint daysRented)
        {
            _movie = movie;
            _daysRented_ = daysRented;
            pricer = moviePricer[_movie.PriceCode];
        }

        public int GetFrequentRenterPoints()
        {
            return pricer.GetFrequentRenterPointsFor(_daysRented);
        }

        public double GetAmount()
        {
            return pricer.GetAmountFor(_daysRented);
        }

        public override string ToString()
        {
            var result = "\t" + _movie.Title+ "\t" + GetAmount().ToString() + "\n";
            return result;
        }
    }
}
