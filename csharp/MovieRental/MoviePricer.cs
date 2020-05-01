﻿using System.Collections.Generic;

namespace MovieRental
{
    public class MoviePricer : Dictionary<PriceCode, MoviePrice>
    {
        public MoviePricer()
        {
            this.Add(PriceCode.REGULAR, new MovieRegular());
            this.Add(PriceCode.NEW_RELEASE, new MovieNewRelease());
            this.Add(PriceCode.CHILDRENS, new MovieChildren());
        }
    }

    public abstract class MoviePrice
    {
        protected int thresholdForReducPrice;
        protected double reducePrice;
        protected double fixedPrice;
        protected int frequentRenterPointsBase = 1;

        public MoviePrice()
        {
            Initialize();
        }

        public virtual int GetFrequentRenterPointsFor(int daysRented)
        {
            return frequentRenterPointsBase;
        }

        protected abstract void Initialize();

        public virtual double GetAmountFor(int daysRented)
        {
            var amount = fixedPrice;
            if (daysRented > thresholdForReducPrice)
                amount += (daysRented - thresholdForReducPrice) * reducePrice;
            return amount;
        }
    }

    public class MovieRegular : MoviePrice
    {
        protected override void Initialize()
        {
            thresholdForReducPrice = 2;
            reducePrice = 1.5;
            fixedPrice = 2;
        }
    }

    public class MovieChildren : MoviePrice
    {
        protected override void Initialize()
        {
            thresholdForReducPrice = 3;
            reducePrice = 1.5;
            fixedPrice = 1.5;
        }
    }

    public class MovieNewRelease : MoviePrice
    {
        private const int thresholdForFrequenteRenterPointBonus = 1;

        protected override void Initialize()
        {
            thresholdForReducPrice = 0;
            reducePrice = 3;
            fixedPrice = 0;
        }

        public override int GetFrequentRenterPointsFor(int daysRented)
        {
            if (daysRented > thresholdForFrequenteRenterPointBonus)
                return frequentRenterPointsBase + 1;

            return frequentRenterPointsBase;
        }
    }
}