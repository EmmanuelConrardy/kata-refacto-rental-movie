using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRental
{
    public class Rentals : List<Rental>
    {
        public string GetStatementFor(string name)
        {
            var statement = new StringBuilder();

            statement.Append("Rental Record for " + name + "\n");
            ForEach(rental => 
                statement.Append("\t" + rental.GetMovieTitle() + "\t" + rental.GetAmount() + "\n")
            );
            statement.Append("Amount owed is " + GetTotalAmount() + "\n");
            statement.Append("You earned " + GetFrequentRenterPoints() + " frequent renter points");

            return statement.ToString();
        }

        private string GetTotalAmount()
        {
            return this.Sum(r => r.GetAmount()).ToString();
        }

        private string GetFrequentRenterPoints()
        {
            return this.Sum(r => r.GetFrequentRenterPoints()).ToString();
        }

    }
}