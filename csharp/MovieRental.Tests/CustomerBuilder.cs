using System.Collections.Generic;

namespace MovieRental.Tests
{
    public class CustomerBuilder
    {
        public static readonly string Name = "Roberts";

        private string _name = Name;
        private readonly List<RentalBase> _rentalsBase = new List<RentalBase>();

        public Customer Build()
        {
            Customer result = new Customer(_name);

            foreach (var rental in _rentalsBase)
            {
                result.AddRental(rental);
            }
            return result;
        }

        public CustomerBuilder WithName(string name)
        {
            this._name = name;
            return this;
        }

        public CustomerBuilder WithRentals(params RentalBase[] rentals)
        {
            this._rentalsBase.AddRange(rentals);
            return this;
        }
    }
}