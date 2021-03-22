namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int getDaysRented()
        {
            return _daysRented;
        }

        public int getPriceCode()
        {
            return _movie.getPriceCode();
        }

        public string getTitle()
        {
            return _movie.getTitle();
        }

        public int FrequentRenterPoints(int priceCode, int daysRented)
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((priceCode == Movie.NEW_RELEASE) && daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double GetAmount(int priceCode, int daysRented)
        {
            //Code smell : Switch Statements
            double amount = 0;
            switch (priceCode)
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * 1.5;
                    if (daysRented > 10)
                        amount -= (daysRented - 10) * 0.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3) * 1.5;
                    break;
            }

            return amount;
        }
    }
}
