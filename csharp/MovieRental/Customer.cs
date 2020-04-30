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
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + getName() + "\n";

            //START - Test seams
            foreach (Rental each in _rentals)
            {
                double thisAmount = 0;

                thisAmount = each.GetAmount();
                frequentRenterPoints += each.GetFrequentRenterPoints();
                
                //extract method
                result = PrintRental(result, each, thisAmount);

                totalAmount += thisAmount;
            }
            //END - Test seams

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }

        private static string PrintRental(string result, Rental each, double thisAmount)
        {
            // show figures for this rental
            result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
            return result;
        }
    }

}
