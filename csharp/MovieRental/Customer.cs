using System.Collections.Generic;

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
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + getName() + "\n";

            foreach (Rental rental in _rentals)
            {
                double amount = 0;

                //determine amounts for each line
                //Code smell : Message Chains
                //Code smell : Switch Statements
                switch (rental.getMovie().getPriceCode())
                {
                    case Movie.REGULAR:
                        amount += 2;
                        if (rental.getDaysRented() > 2)
                            amount += (rental.getDaysRented() - 2) * 1.5;
                        if (rental.getDaysRented() > 10)
                            amount -= (rental.getDaysRented() - 10) * 0.5;
                        break;
                    case Movie.NEW_RELEASE:
                        amount += rental.getDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        amount += 1.5;
                        if (rental.getDaysRented() > 3)
                            amount += (rental.getDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((rental.getMovie().getPriceCode() == Movie.NEW_RELEASE) && rental.getDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + rental.getMovie().getTitle() + "\t" + amount.ToString() + "\n";
                totalAmount += amount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }
    }

}
