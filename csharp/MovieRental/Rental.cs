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

        public virtual int FrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((Movie.GetPriceCode() == Movie.NewRelease) && DaysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

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
}