using System.Collections.Generic;

namespace MovieRental
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<RentalBase> _rentalsBase = new List<RentalBase>();
        private readonly Rentals _rentals = new Rentals();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(RentalBase arg)
        {
            _rentalsBase.Add(arg);
            _rentals.AddRental(arg);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            string result = "Rental Record for " + GetName() + "\n";
            var frequentRenterPoints = 0;

            foreach (var rental in _rentalsBase)
            {
                result += "\t" + rental.GetMovieTitle() + "\t" + rental.GetAmount() + "\n";

                frequentRenterPoints += rental.FrequentRenterPoints();
            }

            var totalAmount = _rentals.GetAmount();

            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}