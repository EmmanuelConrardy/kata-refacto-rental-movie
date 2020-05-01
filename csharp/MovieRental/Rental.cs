namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private uint _daysRented_;

        public Rental(Movie movie, uint daysRented)
        {
            _movie = movie;
            _daysRented_ = daysRented;
        }

        public int GetFrequentRenterPoints()
        {
            return _movie.GetFrequentRenterPointsFor(_daysRented_);
        }

        public double GetAmount()
        {
            return _movie.GetAmountFor(_daysRented_);
        }

        public string GetMovieTitle()
        {
            return _movie.Title;
        }
    }
}
