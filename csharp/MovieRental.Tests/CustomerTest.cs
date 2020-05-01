using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental;
using MovieRental.Tests;

namespace MovieRental.Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            Customer c = new CustomerBuilder().build();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestAddRental()
        {
            Customer customer2 = new CustomerBuilder().withName("Julia").build();
            Movie movie1 = new Movie("Gone with the Wind", PriceCode.REGULAR);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            Customer c = new Customer("David");
            Assert.AreEqual("David", c.Name);
        }
    }
}