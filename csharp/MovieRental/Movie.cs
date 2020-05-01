using System;

namespace MovieRental
{
    public enum PriceCode
    {
        REGULAR = 0,
        NEW_RELEASE = 1,
        CHILDRENS = 2
    }
    public class Movie
    {
        private string _title;
        private PriceCode _priceCode;

        public Movie(string title, PriceCode priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public PriceCode getPriceCode()
        {
            return _priceCode;
        }

        public string getTitle()
        {
            return _title;
        }
    }
}
