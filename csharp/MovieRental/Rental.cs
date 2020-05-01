﻿using System;
using System.Collections.Generic;

namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;
        private MoviePricer moviePricer = new MoviePricer();
        private MoviePricer_ moviePricer_ = new MoviePricer_();

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetFrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if (((_movie.getPriceCode() == Movie.NEW_RELEASE)
                || _movie.getPriceCode_() == PriceCode.NEW_RELEASE)
                && _daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double GetAmount()
        {
            return moviePricer_[_movie.getPriceCode_()].GetAmountFor(_daysRented);
            return moviePricer[_movie.getPriceCode()].GetAmountFor(_daysRented);
        }

        public override string ToString()
        {
            var result = "\t" + _movie.getTitle() + "\t" + GetAmount().ToString() + "\n";
            return result;
        }
    }
}
