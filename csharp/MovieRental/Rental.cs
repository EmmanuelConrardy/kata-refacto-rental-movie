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

        public Movie getMovie()
        {
            return _movie;
        }

        //Move method
        public int GetFrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((this.getMovie().getPriceCode() == Movie.NEW_RELEASE) && this.getDaysRented() > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        //Move method
        public double GetAmount()
        {
            var thisAmount = 0.0;
            //determine amounts for each line
            switch (this.getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (this.getDaysRented() > 2)
                        thisAmount += (this.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += this.getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (this.getDaysRented() > 3)
                        thisAmount += (this.getDaysRented() - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }

        public override string ToString()
        {
            var result = "\t" + this.getMovie().getTitle() + "\t" + GetAmount().ToString() + "\n";
            return result;
        }
    }
}
