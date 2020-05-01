using System.Collections.Generic;

namespace MovieRental
{
    public class Customer
    {
        public string Name { get; }

        private Rentals _rentals = new Rentals();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Statement()
        {
            return _rentals.GetStatementFor(Name);
        }
    }

}
