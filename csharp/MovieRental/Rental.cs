using System.Collections.Generic;

namespace MovieRental
{
    public abstract class RentalBase
    {
        protected Movie Movie;
        protected int DaysRented;

        protected RentalBase(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public abstract double GetAmount();

        public abstract int FrequentRenterPoints();

        public string GetMovieTitle()
        {
            return Movie.GetTitle();
        }
    }

    public class RentalChildren : RentalBase
    {
        public RentalChildren(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override int FrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            return frequentRenterPoints;
        }

        public override double GetAmount()
        {
            var amount = 1.5;
            if (DaysRented > 3)
                amount += (DaysRented - 3) * 1.5;
            return amount;
        }
    }

    public class RentalNewRelease : RentalBase
    {
        public RentalNewRelease(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }
        public override int FrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            if (DaysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }
        public override double GetAmount()
        {
            var amount = DaysRented * 3;
            return amount;
        }
    }

    public class RentalRegular : RentalBase
    {
        public RentalRegular(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }
        public override int FrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            return frequentRenterPoints;
        }
        public override double GetAmount()
        {
            var amount = 2.0;
            if (DaysRented > 2)
                amount += (DaysRented - 2) * 1.5;
            if (DaysRented > 10)
                amount -= (DaysRented - 10) * 0.5;
            return amount;
        }
    }

    public class Rentals
    {
        private readonly List<RentalBase> _rentalsBase = new List<RentalBase>();

        public void AddRental(RentalBase rental)
        {
            _rentalsBase.Add(rental);
        }

        public double GetAmount()
        {
            double amount = 0;
            foreach (var rental in _rentalsBase)
            {
                amount += rental.GetAmount();
            }

            return amount;
        }
    }
}