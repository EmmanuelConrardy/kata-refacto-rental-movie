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
            string result = "Rental Record for " + getName() + "\n";
            var frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                //Code smell : Inappropriate Intimacy
                var priceCode = rental.getPriceCode();
                var daysRented = rental.getDaysRented();
                //Code smell : Feature Envy
                var amount = rental.GetAmount(priceCode, daysRented);
                frequentRenterPoints += rental.FrequentRenterPoints(priceCode, daysRented);

                // show figures for this rental
                result += "\t" + rental.getTitle() + "\t" + amount.ToString() + "\n";
                totalAmount += amount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }
    }

}
