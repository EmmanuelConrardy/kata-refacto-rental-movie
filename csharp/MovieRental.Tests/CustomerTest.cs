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
        public void TestAddRentalBaseRegular()
        {
            var customer = new CustomerBuilder().withName("Julia").build();
            var movie = new Movie("Gone with the Wind", Movie.REGULAR);
            var rental1 = new RentalRegular(movie, 3);
            customer.addRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            var c = new Customer("David");
            Assert.AreEqual("David", c.getName());
        }

        [TestMethod]
        public void StatementForRegularBaseMovie()
        {
            //Arrange
            var regularMovie = new Movie("Gone with the Wind", Movie.REGULAR);
            var rentalRegularMovie = new RentalRegular(regularMovie, 3);
            var sallie =
                new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rentalRegularMovie)
                    .build();
            //Act
            var statement = sallie.statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tGone with the Wind\t3,5\n" +
                           "Amount owed is 3,5\n" +
                           "You earned 1 frequent renter points";
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForNewReleaseBaseMovie()
        {
            //Arrange
            var newReleaseMovie = new Movie("Star Wars", Movie.NEW_RELEASE);
            var rentalNewReleaseMovie = new RentalNewRelease(newReleaseMovie, 3);
            var sallie =
                new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rentalNewReleaseMovie)
                    .build();

            //Act
            var statement = sallie.statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tStar Wars\t9\n" +
                           "Amount owed is 9\n" +
                           "You earned 2 frequent renter points";
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForChildrensBaseMovie()
        {
            //Arrange
            var childrenMovie = new Movie("Madagascar", Movie.CHILDRENS);
            var rentalChildrenMovie = new RentalChildren(childrenMovie, 3);
            var customer2
                = new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rentalChildrenMovie)
                    .build();

            //Act
            var statement = customer2.statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tMadagascar\t1,5\n" +
                           "Amount owed is 1,5\n" +
                           "You earned 1 frequent renter points";
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForManyMoviesBase()
        {
            //Arrange
            var movie = new Movie("Madagascar", Movie.CHILDRENS);
            var rentalChildrenMovie = new RentalChildren(movie, 6);
            var newRelease = new Movie("Star Wars", Movie.NEW_RELEASE);
            var rentalNewReleaseMovie = new RentalNewRelease(newRelease, 2);
            var regular = new Movie("Gone with the Wind", Movie.REGULAR);
            var rentalRegularMovie = new RentalRegular(regular, 8);

            var david
                = new CustomerBuilder()
                    .withName("David")
                    .withRentals(rentalChildrenMovie, rentalNewReleaseMovie, rentalRegularMovie)
                    .build();

            //Act
            var statement = david.statement();

            //Assert
            var expected = "Rental Record for David\n" +
                           "\tMadagascar\t6\n" +
                           "\tStar Wars\t6\n" +
                           "\tGone with the Wind\t11\n" +
                           "Amount owed is 23\n" +
                           "You earned 4 frequent renter points";
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForPriceBreakOver10dayRentedRegularBase()
        {
            //Arrange
            var regularMovie = new Movie("Gone with the Wind", Movie.REGULAR);
            var rentalRegularMovie = new RentalRegular(regularMovie, 12);
            var sallie =
                new CustomerBuilder()
                    .withName("Sallie")
                    .withRentals(rentalRegularMovie)
                    .build();

            //Act
            var statement = sallie.statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tGone with the Wind\t16\n" +
                           "Amount owed is 16\n" +
                           "You earned 1 frequent renter points";
            Assert.AreEqual(expected, statement);
        }
    }

}
