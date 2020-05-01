namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;
        private MoviePrice pricer;
        private static MoviePricer moviePricer = new MoviePricer();

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
            pricer = moviePricer[_movie.getPriceCode()];
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
