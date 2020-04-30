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

                // show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }
            //END - Test seams

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }

        private double GetAmount(Rental each, double thisAmount)
        {
            //determine amounts for each line
            switch (each.getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (each.getDaysRented() > 2)
                        thisAmount += (each.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += each.getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (each.getDaysRented() > 3)
                        thisAmount += (each.getDaysRented() - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }

}
