namespace MovieRental
{
    public abstract class RentalBase
    {
        protected Movie _movie;
        protected int _daysRented;

        public RentalBase(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public abstract double GetAmount();
    }

    public class RentalChildren : RentalBase
    {
        public RentalChildren(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override double GetAmount()
        {
            var amount = 1.5;
            if (_daysRented > 3)
                amount += (_daysRented - 3) * 1.5;
            return amount;
        }
    }
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public string getTitle()
        {
            return _movie.getTitle();
        }

        public int FrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((_movie.getPriceCode() == Movie.NEW_RELEASE) && _daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double GetAmount()
        {
            //Code smell : Switch Statements
            double amount = 0;
            switch (_movie.getPriceCode())
            {
                case Movie.REGULAR:
                    amount = CalcAmountRegular(amount);
                    break;
                case Movie.NEW_RELEASE:
                    amount = CalcAmountNewRelease(amount);
                    break;
                case Movie.CHILDRENS:
                    amount =  new RentalChildren(_movie,_daysRented).GetAmount();
                    break;
            }

            return amount;
        }

        private double CalcAmountNewRelease(double amount)
        {
            amount += _daysRented * 3;
            return amount;
        }

        private double CalcAmountRegular(double amount)
        {
            amount += 2;
            if (_daysRented > 2)
                amount += (_daysRented - 2) * 1.5;
            if (_daysRented > 10)
                amount -= (_daysRented - 10) * 0.5;
            return amount;
        }
    }
}
