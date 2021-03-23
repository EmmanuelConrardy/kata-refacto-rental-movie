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

        public string statement()
        {
            double totalAmount = 0;
            string result = "Rental Record for " + getName() + "\n";
            var frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                result += "\t" + rental.getTitle() + "\t" + rental.GetAmount() + "\n";
               
                frequentRenterPoints += rental.FrequentRenterPoints();
                
                totalAmount += rental.GetAmount();
            }

            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }

}
