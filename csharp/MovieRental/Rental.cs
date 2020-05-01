﻿using System;
using System.Collections.Generic;

namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        //missing abstraction
        private Dictionary<int, double> movieAmount = new Dictionary<int, double>();

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
            //Factory
            movieAmount.Add(Movie.REGULAR, SetAmountForRegular());
            movieAmount.Add(Movie.NEW_RELEASE, SetAmountForNewRelease());
            movieAmount.Add(Movie.CHILDRENS, SetAmountForChildren());
        }

        public int getDaysRented()
        {
            return _daysRented;
        }

        public Movie getMovie()
        {
            return _movie;
        }

        public int GetFrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((this.getMovie().getPriceCode() == Movie.NEW_RELEASE) && this.getDaysRented() > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double GetAmount()
        {
            return movieAmount[_movie.getPriceCode()];
        }

        //SRP
        private double SetAmountForChildren()
        {
            var thisAmount = 1.5;
            if (this.getDaysRented() > 3)
                thisAmount += (this.getDaysRented() - 3) * 1.5;
            return thisAmount;
        }

        //SRP
        private double SetAmountForNewRelease()
        {
            var thisAmount = this.getDaysRented() * 3;
            return thisAmount;
        }

        //SRP
        private double SetAmountForRegular()
        {
            var thisAmount = 2d;
            if (this.getDaysRented() > 2)
                thisAmount += (this.getDaysRented() - 2) * 1.5;
            return thisAmount;
        }

        public override string ToString()
        {
            var result = "\t" + this.getMovie().getTitle() + "\t" + GetAmount().ToString() + "\n";
            return result;
        }
    }
}
