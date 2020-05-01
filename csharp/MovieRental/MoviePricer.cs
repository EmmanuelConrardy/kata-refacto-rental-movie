using System.Collections.Generic;

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
        private const int bonusPoint = 1;
        protected int thresholdForReducPrice;
        protected double reducePrice;
        protected double fixedPrice;
        protected int frequentRenterPointsBase;
        protected int thresholdForFrequenteRenterPointBonus = int.MaxValue;

        public MoviePrice()
        {
            Initialize();
        }

        protected abstract void Initialize();

        public virtual int GetFrequentRenterPointsFor(uint daysRented)
        {
            if (ShouldAddBonusPointFor(daysRented))
                return frequentRenterPointsBase + bonusPoint;

            return frequentRenterPointsBase;
        }
     
        public virtual double GetAmountFor(uint daysRented)
        {
            var amount = fixedPrice;
            if (daysRented > thresholdForReducPrice)
                amount += (daysRented - thresholdForReducPrice) * reducePrice;
            return amount;
        }

        private bool ShouldAddBonusPointFor(uint daysRented)
        {
            return daysRented > thresholdForFrequenteRenterPointBonus;
        }

    }

    public class MovieRegular : MoviePrice
    {
        protected override void Initialize()
        {
            thresholdForReducPrice = 2;
            reducePrice = 1.5;
            fixedPrice = 2;
            frequentRenterPointsBase = 1;
        }
    }

    public class MovieChildren : MoviePrice
    {
        protected override void Initialize()
        {
            thresholdForReducPrice = 3;
            reducePrice = 1.5;
            fixedPrice = 1.5;
            frequentRenterPointsBase = 1;
        }
    }

    public class MovieNewRelease : MoviePrice
    {
        protected override void Initialize()
        {
            thresholdForReducPrice = 0;
            reducePrice = 3;
            fixedPrice = 0;
            frequentRenterPointsBase = 1;
            thresholdForFrequenteRenterPointBonus = 1;
        }
    }
}