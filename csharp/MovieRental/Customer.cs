using System.Collections.Generic;

namespace MovieRental
{
    public class Customer
    {

        private string _name;
        //Missing abstraction
        private List<Rental> _rentals = new List<Rental>();
        private Rentals _rentals_ = new Rentals();


        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
            _rentals_.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
           
            string result = "Rental Record for " + getName() + "\n";

            //START - Test seams
            //double totalAmount = 0;
            //int frequentRenterPoints = 0;
            //foreach (Rental each in _rentals)
            //{
            //    totalAmount += each.GetAmount();
            //    frequentRenterPoints += each.GetFrequentRenterPoints();
            //    result += each.ToString();
            //}
            //END - Test seams
            result += _rentals_.ToString();
           // add footer lines
           result += "Amount owed is " + _rentals_.GetTotalAmount().ToString() + "\n";
            result += "You earned " + _rentals_.GetfrequentRenterPoints().ToString() + " frequent renter points";

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
