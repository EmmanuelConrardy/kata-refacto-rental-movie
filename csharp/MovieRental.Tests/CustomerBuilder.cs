using System;
using System.Collections.Generic;

namespace MovieRental.Tests
{
    public class CustomerBuilder
    {

        public static readonly String NAME = "Roberts";

        private String name = NAME;
        private List<RentalBase> rentalsBase = new List<RentalBase>();

        public Customer build()
        {
            Customer result = new Customer(name);

            foreach (var rental in rentalsBase)
            {
                result.addRental(rental);
            }
            return result;
        }

        public CustomerBuilder withName(String name)
        {
            this.name = name;
            return this;
        }

        public CustomerBuilder withRentals(params RentalBase[] rentals)
        {
            this.rentalsBase.AddRange(rentals);
            return this;
        }
    }

}
