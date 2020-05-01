using System;
using System.Collections.Generic;

namespace MovieRental
{
    public class MoviePricer : Dictionary<int, MoviePrice>
    {
        public MoviePricer()
        {
            this.Add(Movie.REGULAR, new MovieRegular());
            this.Add(Movie.NEW_RELEASE, new MovieNewRelease());
            this.Add(Movie.CHILDRENS, new MovieChildren());
        }
    }

    public abstract class MoviePrice
    {
        protected int thresholdForReducPrice;
        protected double reducePrice;
        protected double fixedPrice;

        public MoviePrice()
        {
            Initialize();
        }

        public abstract void Initialize();

        public virtual double GetAmountFor(int daysRented)
        {
            var thisAmount = fixedPrice;
            if (daysRented > thresholdForReducPrice)
                thisAmount += (daysRented - thresholdForReducPrice) * reducePrice;
            return thisAmount;
        }
    }

    public class MovieRegular : MoviePrice
    {
        public override void Initialize()
        {
            thresholdForReducPrice = 2;
            reducePrice = 1.5;
            fixedPrice = 2;
        }
    }

    public class MovieChildren : MoviePrice
    {
        public override void Initialize()
        {
            thresholdForReducPrice = 3;
            reducePrice = 1.5;
            fixedPrice = 1.5;
        }
    }

    public class MovieNewRelease : MoviePrice
    {
        public override void Initialize()
        {
            thresholdForReducPrice = 0;
            reducePrice = 3;
            fixedPrice = 0;
        }
    }
}