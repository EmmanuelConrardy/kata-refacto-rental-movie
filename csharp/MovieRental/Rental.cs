using System;
using System.Collections.Generic;

namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        //missing abstraction
        private Dictionary<int, double> moviePrice = new Dictionary<int, double>();
        private MoviePricer moviePrice_ = new MoviePricer();

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
            //Factory
            moviePrice.Add(Movie.REGULAR, SetAmountForRegular());
            moviePrice.Add(Movie.NEW_RELEASE, SetAmountForNewRelease());
            moviePrice.Add(Movie.CHILDRENS, SetAmountForChildren());
        }

        public int GetFrequentRenterPoints()
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((_movie.getPriceCode() == Movie.NEW_RELEASE) && _daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double GetAmount()
        {
            return moviePrice_[_movie.getPriceCode()].GetAmountFor(_daysRented);
            return moviePrice[_movie.getPriceCode()];
        }

        //SRP
        private double SetAmountForChildren()
        {
            var thisAmount = 1.5;
            if (_daysRented > 3)
                thisAmount += (_daysRented - 3) * 1.5;
            return thisAmount;
        }

        //SRP
        private double SetAmountForNewRelease()
        {
            var thisAmount = _daysRented * 3;
            return thisAmount;
        }

        //SRP
        private double SetAmountForRegular()
        {
            var thisAmount = 2d;
            if (_daysRented > 2)
                thisAmount += (_daysRented - 2) * 1.5;
            return thisAmount;
        }

        public override string ToString()
        {
            var result = "\t" + _movie.getTitle() + "\t" + GetAmount().ToString() + "\n";
            return result;
        }
    }
}
