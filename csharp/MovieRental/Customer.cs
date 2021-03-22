﻿using System.Collections.Generic;

namespace MovieRental
{
    public class Customer
    {

        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        //Code smell : Long method
        public string statement()
        {
            double totalAmount = 0;
            string result = "Rental Record for " + getName() + "\n";
            var frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                //Code smell : Inappropriate Intimacy
                var priceCode = rental.getPriceCode();
                var daysRented = rental.getDaysRented();
                //Code smell : Feature Envy
                var amount = GetAmount(priceCode, daysRented);
                frequentRenterPoints += FrequentRenterPoints(priceCode, daysRented);

                // show figures for this rental
                result += "\t" + rental.getTitle() + "\t" + amount.ToString() + "\n";
                totalAmount += amount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }

        private static int FrequentRenterPoints(int priceCode, int daysRented)
        {
            var frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((priceCode == Movie.NEW_RELEASE) && daysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        private double GetAmount(int priceCode, int daysRented)
        {
            //Code smell : Switch Statements
            double amount = 0;
            switch (priceCode)
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * 1.5;
                    if (daysRented > 10)
                        amount -= (daysRented - 10) * 0.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3) * 1.5;
                    break;
            }

            return amount;
        }
    }

}
