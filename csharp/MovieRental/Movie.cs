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
        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        private string _title;
        private PriceCode _priceCode_;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
            _priceCode_ = (PriceCode)priceCode;
        }

        public Movie(string title, PriceCode priceCode)
        {
            _title = title;
            _priceCode_ = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public PriceCode getPriceCode_()
        {
            return _priceCode_;
        }

        public string getTitle()
        {
            return _title;
        }
    }
}
