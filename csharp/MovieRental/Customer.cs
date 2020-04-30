﻿using System.Collections.Generic;

namespace MovieRental
{
    public class Customer
    {

        private string _name;
        private Rentals _rentals_ = new Rentals();

        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals_.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
            string result = "Rental Record for " + getName() + "\n";
            result += _rentals_.ToString();

            return result;
        }
    }

}
