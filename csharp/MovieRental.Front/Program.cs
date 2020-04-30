using System;

namespace MovieRental.Front
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie("Transformer", Movie.REGULAR);

            Rental rental = new Rental(movie, 3);

            Customer customer = new Customer("Arolla");
            customer.AddRental(rental);

            String statement = customer.Statement();
            Console.WriteLine(statement);
            Console.ReadKey();
        }
    }
}
