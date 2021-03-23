using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            var c = new CustomerBuilder().Build();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestAddRentalBaseRegular()
        {
            var customer = new CustomerBuilder().WithName("Julia").Build();
            var movie = new Movie("Gone with the Wind", Movie.Regular);
            var rental1 = new RentalRegular(movie, 3);
            customer.AddRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            var c = new Customer("David");
            Assert.AreEqual("David", c.GetName());
        }

        [TestMethod]
        public void StatementForRegularBaseMovie()
        {
            //Arrange
            var regularMovie = new Movie("Gone with the Wind", Movie.Regular);
            var rentalRegularMovie = new RentalRegular(regularMovie, 3);
            var sallie =
                new CustomerBuilder()
                    .WithName("Sallie")
                    .WithRentals(rentalRegularMovie)
                    .Build();
            //Act
            var statement = sallie.Statement();

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
            var newReleaseMovie = new Movie("Star Wars", Movie.NewRelease);
            var rentalNewReleaseMovie = new RentalNewRelease(newReleaseMovie, 3);
            var sallie =
                new CustomerBuilder()
                    .WithName("Sallie")
                    .WithRentals(rentalNewReleaseMovie)
                    .Build();

            //Act
            var statement = sallie.Statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tStar Wars\t9\n" +
                           "Amount owed is 9\n" +
                           "You earned 2 frequent renter points";
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForChildrenBaseMovie()
        {
            //Arrange
            var childrenMovie = new Movie("Madagascar", Movie.Children);
            var rentalChildrenMovie = new RentalChildren(childrenMovie, 3);
            var customer2
                = new CustomerBuilder()
                    .WithName("Sallie")
                    .WithRentals(rentalChildrenMovie)
                    .Build();

            //Act
            var statement = customer2.Statement();

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
            var movie = new Movie("Madagascar", Movie.Children);
            var rentalChildrenMovie = new RentalChildren(movie, 6);
            var newRelease = new Movie("Star Wars", Movie.NewRelease);
            var rentalNewReleaseMovie = new RentalNewRelease(newRelease, 2);
            var regular = new Movie("Gone with the Wind", Movie.Regular);
            var rentalRegularMovie = new RentalRegular(regular, 8);

            var david
                = new CustomerBuilder()
                    .WithName("David")
                    .WithRentals(rentalChildrenMovie, rentalNewReleaseMovie, rentalRegularMovie)
                    .Build();

            //Act
            var statement = david.Statement();

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
            var regularMovie = new Movie("Gone with the Wind", Movie.Regular);
            var rentalRegularMovie = new RentalRegular(regularMovie, 12);
            var sallie =
                new CustomerBuilder()
                    .WithName("Sallie")
                    .WithRentals(rentalRegularMovie)
                    .Build();

            //Act
            var statement = sallie.Statement();

            //Assert
            var expected = "Rental Record for Sallie\n" +
                           "\tGone with the Wind\t16\n" +
                           "Amount owed is 16\n" +
                           "You earned 1 frequent renter points";
            Assert.AreEqual(expected, statement);
        }
    }
}