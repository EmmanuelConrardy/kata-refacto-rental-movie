﻿using System;

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

        public virtual int FrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((_movie.getPriceCode() == Movie.NEW_RELEASE) && _daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public string GetMovieTitle()
        {
            return _movie.getTitle();
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
}
