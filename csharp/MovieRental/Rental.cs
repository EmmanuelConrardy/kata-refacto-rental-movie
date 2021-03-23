using System;

namespace MovieRental
{
    public abstract class RentalBase
    {
        protected Movie _movie;
        protected int _daysRented;

        protected RentalBase(Movie movie, int daysRented)
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

    public class RentalNewRelease : RentalBase
    {
        public RentalNewRelease(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override double GetAmount()
        {
            var amount = _daysRented * 3;
            return amount;
        }
    }

    public class RentalRegular : RentalBase
    {
        public RentalRegular(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override double GetAmount()
        {
            var amount = 2.0;
            if (_daysRented > 2)
                amount += (_daysRented - 2) * 1.5;
            if (_daysRented > 10)
                amount -= (_daysRented - 10) * 0.5;
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
            var rental = SelectRental();
            return rental.GetAmount();
        }

        private RentalBase SelectRental()
        {
            switch (_movie.getPriceCode())
            {
                case Movie.REGULAR:
                    return new RentalRegular(_movie, _daysRented);
                    break;
                case Movie.NEW_RELEASE:
                    return new RentalNewRelease(_movie, _daysRented);
                    break;
                case Movie.CHILDRENS:
                    return new RentalChildren(_movie, _daysRented);
                    break;
            }

            throw new ArgumentException();
        }
    }
}
