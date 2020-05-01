using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class Rentals : List<Rental>
    {
        public override string ToString()
        {
            string result = GetResultOfRental();
            result += "Amount owed is " + this.GetTotalAmount().ToString() + "\n";
            result += "You earned " + this.GetfrequentRenterPoints().ToString() + " frequent renter points";

            return result;
        }

        private string GetResultOfRental()
        {
            var result = string.Empty;

            foreach (Rental each in this)
            {
                result += each.ToString();
            }

            return result;
        }

        private double GetTotalAmount()
        {
            return this.Sum(r => r.GetAmount());
        }

        private int GetfrequentRenterPoints()
        {
            return this.Sum(r => r.GetFrequentRenterPoints());
        }

    }
}