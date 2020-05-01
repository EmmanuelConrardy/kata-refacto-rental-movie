using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental;
using MovieRental.Tests;

namespace GivenCustomer
{
    [TestClass]
    public class WhenRentRegularMovie
    {
        private const string REGULAR_TITLE = "Gone with the Wind";
        private const string REGULAR_BUYER = "Sallie";

        [TestMethod]
        [DataRow((uint)0, "2", "1", DisplayName = "0 day rental -- bug ?")]
        [DataRow((uint)1, "2", "1", DisplayName = "1 day rental")]
        [DataRow((uint)2, "2", "1", DisplayName = "2 day rental")]
        [DataRow((uint)3, "3,5", "1", DisplayName = "3 day rental")]
        [DataRow((uint)9, "12,5", "1", DisplayName = "9 day rental")]
        public void WithDaysRental(uint dayRental, string amount, string renterPoint)
        {
            Movie regular = new Movie(REGULAR_TITLE, PriceCode.REGULAR);
            Rental rental = new Rental(regular, dayRental);
            Customer customer =
                    new CustomerBuilder()
                            .withName(REGULAR_BUYER)
                            .withRentals(rental)
                            .build();
            string expected = $"Rental Record for {REGULAR_BUYER}\n" +
                    $"\t{REGULAR_TITLE}\t{amount}\n" +
                    $"Amount owed is {amount}\n" +
                    $"You earned {renterPoint} frequent renter points";
            string statement = customer.Statement();
            Assert.AreEqual(expected, statement);
        }
    }

    [TestClass]
    public class WhenRentNewReleaseMovie
    {
        private const string NEW_RELEASE_TITLE = "Star Wars";
        private const string NEW_RELEASE_BUYER = "Margo";

        [TestMethod]
        [DataRow((uint)0, "0", "1", DisplayName = "0 day rental -- bug ?")]
        [DataRow((uint)1, "3", "1", DisplayName = "1 day rental")]
        [DataRow((uint)2, "6", "2", DisplayName = "2 day rental")]
        [DataRow((uint)3, "9", "2", DisplayName = "3 day rental")]
        public void WithDaysRental(uint dayRental, string amount, string renterPoint)
        {
            Movie newRelease = new Movie(NEW_RELEASE_TITLE, PriceCode.NEW_RELEASE);
            Rental rental= new Rental(newRelease, dayRental);
            Customer customer2 =
                    new CustomerBuilder()
                            .withName(NEW_RELEASE_BUYER)
                            .withRentals(rental)
                            .build();
            string expected = $"Rental Record for {NEW_RELEASE_BUYER}\n" +
                    $"\t{NEW_RELEASE_TITLE}\t{amount}\n" +
                    $"Amount owed is {amount}\n" +
                    $"You earned {renterPoint} frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }
    }

    [TestClass]
    public class WhenRentChildrenMovie
    {
        private const string CHILDREN_TITLE = "Madagascar";
        private const string CHILDREN_BUYER = "David";

        [TestMethod]
        [DataRow((uint)0, "1,5", "1", DisplayName = "0 day rental -- bug ?")]
        [DataRow((uint)1, "1,5", "1", DisplayName = "1 day rental")]
        [DataRow((uint)2, "1,5", "1", DisplayName = "2 day rental")]
        [DataRow((uint)3, "1,5", "1", DisplayName = "3 day rental")]
        [DataRow((uint)4, "3", "1", DisplayName = "4 day rental")]
        [DataRow((uint)5, "4,5", "1", DisplayName = "5 day rental")]
        public void WithDaysRental(uint dayRental, string amount, string renterPoint)
        {
            Movie newRelease = new Movie(CHILDREN_TITLE, PriceCode.CHILDRENS);
            Rental rental = new Rental(newRelease, dayRental);
            Customer customer2 =
                    new CustomerBuilder()
                            .withName(CHILDREN_BUYER)
                            .withRentals(rental)
                            .build();
            string expected = $"Rental Record for {CHILDREN_BUYER}\n" +
                    $"\t{CHILDREN_TITLE}\t{amount}\n" +
                    $"Amount owed is {amount}\n" +
                    $"You earned {renterPoint} frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }
    }

    [TestClass]
    public class WhenRentManyMovie
    {
        [TestMethod]
        public void ChildrenWith6DaysRental_NewReleaseWith2DaysRental_RegularWith8DaysRental()
        {
            Movie movie1 = new Movie("Madagascar", PriceCode.CHILDRENS);
            Rental rental1 = new Rental(movie1, 6); // 6 day rental
            Movie movie2 = new Movie("Star Wars", PriceCode.NEW_RELEASE);
            Rental rental2 = new Rental(movie2, 2); // 2 day rental
            Movie movie3 = new Movie("Gone with the Wind", PriceCode.REGULAR);
            Rental rental3 = new Rental(movie3, 8); // 8 day rental
            Customer customer1
                    = new CustomerBuilder()
                    .withName("David")
                    .withRentals(rental1, rental2, rental3)
                    .build();
            string expected = "Rental Record for David\n" +
                    "\tMadagascar\t6\n" +
                    "\tStar Wars\t6\n" +
                    "\tGone with the Wind\t11\n" +
                    "Amount owed is 23\n" +
                    "You earned 4 frequent renter points";
            string statement = customer1.Statement();
            Assert.AreEqual(expected, statement);
        }
    }
}