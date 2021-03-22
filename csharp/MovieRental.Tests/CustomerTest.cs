using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            var c = new CustomerBuilder().build();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestAddRental()
        {
            var customer2 = new CustomerBuilder().withName("Julia").build();
            var movie1 = new Movie("Gone with the Wind", Movie.REGULAR);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.addRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            var c = new Customer("David");
            Assert.AreEqual("David", c.getName());
        }
        [TestMethod]
        public void StatementForRegularMovie()
        {
            var movie1 = new Movie("Gone with the Wind", Movie.REGULAR);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            var customer2 =
                    new CustomerBuilder()
                            .withName("Sallie")
                            .withRentals(rental1)
                            .build();
            var expected = "Rental Record for Sallie\n" +
                           "\tGone with the Wind\t3,5\n" +
                           "Amount owed is 3,5\n" +
                           "You earned 1 frequent renter points";
            var statement = customer2.statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForNewReleaseMovie()
        {
            var movie1 = new Movie("Star Wars", Movie.NEW_RELEASE);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            var customer2 =
                    new CustomerBuilder()
                            .withName("Sallie")
                            .withRentals(rental1)
                            .build();
            var expected = "Rental Record for Sallie\n" +
                           "\tStar Wars\t9\n" +
                           "Amount owed is 9\n" +
                           "You earned 2 frequent renter points";
            var statement = customer2.statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForChildrensMovie()
        {
            var movie1 = new Movie("Madagascar", Movie.CHILDRENS);
            var rental1 = new Rental(movie1, 3); // 3 day rental
            var customer2
                    = new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rental1)
                    .build();
            var expected = "Rental Record for Sallie\n" +
                           "\tMadagascar\t1,5\n" +
                           "Amount owed is 1,5\n" +
                           "You earned 1 frequent renter points";
            var statement = customer2.statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForManyMovies()
        {
            var movie1 = new Movie("Madagascar", Movie.CHILDRENS);
            var rental1 = new Rental(movie1, 6); // 6 day rental
            var movie2 = new Movie("Star Wars", Movie.NEW_RELEASE);
            var rental2 = new Rental(movie2, 2); // 2 day rental
            var movie3 = new Movie("Gone with the Wind", Movie.REGULAR);
            var rental3 = new Rental(movie3, 8); // 8 day rental
            var customer1
                    = new CustomerBuilder()
                    .withName("David")
                    .withRentals(rental1, rental2, rental3)
                    .build();
            var expected = "Rental Record for David\n" +
                           "\tMadagascar\t6\n" +
                           "\tStar Wars\t6\n" +
                           "\tGone with the Wind\t11\n" +
                           "Amount owed is 23\n" +
                           "You earned 4 frequent renter points";
            var statement = customer1.statement();
            Assert.AreEqual(expected, statement);
        }

        //TODO make test for price breaks in code.
        [TestMethod]
        public void StatementForPriceBreakOver10dayRentedRegular()
        {
            //Arrange
            var regularMovie = new Movie("Gone with the Wind", Movie.REGULAR);
            var rental = new Rental(regularMovie, 12); 
            var Sallie =
                new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rental)
                    .build();
            
            //Act
            var statement = Sallie.statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tGone with the Wind\t16\n" +
                           "Amount owed is 16\n" +
                           "You earned 1 frequent renter points";
            Assert.AreEqual(expected, statement);
        }
    }

}
