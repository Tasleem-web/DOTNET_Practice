using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Task1.DoNotChange;

namespace Task1.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(6250, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = 6)]
        [TestCase(-1, ExpectedResult = 10)]
        [TestCase(1, ExpectedResult = 5)]
        public int GetHighValueCustomers_Limit_ReturnsCustomersCount(decimal limit)
        {
            return LinqTask.GetHighValueCustomers(DataSource.Customers, limit).Count();
        }

        [Test]
        public void GetHighValueCustomers_NullSource_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.GetHighValueCustomers(null, 42).ToList(), Throws.ArgumentNullException);
        }

        //[Test]
        //public void GetClientsWithFirstOrderDate_CustomersAndSuppliers_2CustomersHaveSuppliers()
        //{
        //    var result = LinqTask.GetClientsWithFirstOrderDate(DataSource.Customers, DataSource.Suppliers).ToList();

        //    Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count));
        //    foreach (var (customer, suppliers) in result)
        //    {
        //        foreach (var supplier in suppliers)
        //        {
        //            StringAssert.AreEqualIgnoringCase(customer.City, supplier.City);
        //            StringAssert.AreEqualIgnoringCase(customer.Country, supplier.Country);
        //        }
        //    }
        //}

        [Test]
        public void GetClientsWithFirstOrderDate_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.GetClientsWithFirstOrderDate(null, null).ToList(), Throws.ArgumentNullException);
        }

        //[Test]
        //public void GetClientsWithFirstOrderDateUsingGroup_CustomersAndSuppliers_2CustomersHaveSuppliers()
        //{
        //    var result = LinqTask.GetClientsWithFirstOrderDateUsingGroup(DataSource.Customers, DataSource.Suppliers).ToList();

        //    Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count));
        //    foreach (var (customer, suppliers) in result)
        //    {
        //        foreach (var supplier in suppliers)
        //        {
        //            StringAssert.AreEqualIgnoringCase(customer.City, supplier.City);
        //            StringAssert.AreEqualIgnoringCase(customer.Country, supplier.Country);
        //        }
        //    }
        //}

        [Test]
        public void GetClientsWithFirstOrderDateUsingGroup_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.GetClientsWithFirstOrderDateUsingGroup(null, null).ToList(), Throws.ArgumentNullException);
        }

        //[TestCase(800, ExpectedResult = 2)]
        //[TestCase(0, ExpectedResult = 6)]
        //[TestCase(-1, ExpectedResult = 6)]
        //[TestCase(1, ExpectedResult = 5)]
        //public int GetClientsWithFirstOrderDateOrdered_Limit_ReturnsCustomersCount(decimal limit)
        //{
        //    return LinqTask.GetClientsWithFirstOrderDateOrdered(DataSource.Customers, limit).Count();
        //}

        [Test]
        public void GetClientsWithFirstOrderDateOrdered_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.GetClientsWithFirstOrderDateOrdered(null, 42).ToList(), Throws.ArgumentNullException);
        }

        //[Test]
        //public void GetClientsWithInvalidDetails_Customers_CustomersAndDateOfEntry()
        //{
        //    var result = LinqTask.GetClientsWithInvalidDetails(DataSource.Customers).ToList();

        //    Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count - 4));
        //    foreach (var (customer, dateOfEntry) in result)
        //    {
        //        Assert.That(FindCustomerOrdersMinDate(customer), Is.EqualTo(dateOfEntry));
        //    }
        //}

        //[Test]
        //public void GetClientsWithInvalidDetails_NullCustomer_ThrowsArgumentNullException()
        //{
        //    Assert.That(() => LinqTask.GetClientsWithInvalidDetails(null).ToList(), Throws.ArgumentNullException);
        //}

        //[Test]
        //public void GroupProductsByCategoryAndAvailability_Customers_CustomersAndDateOfEntry()
        //{
        //    var result = LinqTask.GroupProductsByCategoryAndAvailability(DataSource.Customers).ToList();

        //    Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count - 4));
        //    foreach (var (customer, dateOfEntry) in result)
        //    {
        //        Assert.That(FindCustomerOrdersMinDate(customer), Is.EqualTo(dateOfEntry));
        //    }

        //    Assert.That(result[0].customer, Is.EqualTo(DataSource.Customers[6]));
        //    Assert.That(result[1].customer, Is.EqualTo(DataSource.Customers[1]));
        //    Assert.That(result[2].customer, Is.EqualTo(DataSource.Customers[3]));
        //    Assert.That(result[3].customer, Is.EqualTo(DataSource.Customers[2]));
        //    Assert.That(result[4].customer, Is.EqualTo(DataSource.Customers[4]));
        //    Assert.That(result[5].customer, Is.EqualTo(DataSource.Customers[0]));
        //}

        [Test]
        public void GroupProductsByCategoryAndAvailability_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.GroupProductsByCategoryAndAvailability(null).ToList(), Throws.ArgumentNullException);
        }

        [Test]
        public void Linq6_Customers_ReturnsFilteredCustomers()
        {
            var expectedResult = DataSource.Customers.ToList();
            expectedResult.RemoveAt(0);
            expectedResult.RemoveAt(0);
            expectedResult.RemoveAt(3);

            var result = LinqTask.Linq6(DataSource.Customers).ToList();

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void Linq6_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.Linq6(null).ToList(), Throws.ArgumentNullException);
        }

        [Test]
        public void CalculateCityProfitabilityAndRateCategoryGroup_Customers_Returns5()
        {
            var expectedResult = new[]
            {
                new Linq7CategoryGroup
                {
                    Category = "Beverages",
                    UnitsInStockGroup = new[]
                    {
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 39,
                            Prices = new [] { 19.0000M }
                        },
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 17,
                            Prices = new [] { 18.0000M }
                        }
                    }
                },
                new Linq7CategoryGroup
                {
                    Category = "Condiments",
                    UnitsInStockGroup = new[]
                    {
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 15,
                            Prices = new [] { 10.0000M, 40.0000M }
                        },
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 13,
                            Prices = new [] { 30.0000M }
                        }
                    }
                }
            };

            var result = LinqTask.CalculateCityProfitabilityAndRate(DataSource.Products);

            foreach (var categoryGroup in result)
            {
                var expectedCategoryGroup = expectedResult.Single(_ => _.Category == categoryGroup.Category);
                foreach (var unitInStockGroup in categoryGroup.UnitsInStockGroup)
                {
                    var expectedUnitInStockGroup = expectedCategoryGroup
                        .UnitsInStockGroup.Single(_ => _.UnitsInStock == unitInStockGroup.UnitsInStock);
                    CollectionAssert.AreEqual(expectedUnitInStockGroup.Prices, unitInStockGroup.Prices);
                }
            }
        }

        [Test]
        public void CalculateCityProfitabilityAndRate_NullProducts_ThrowsArgumentNullException()
        {
            Assert.That(() => LinqTask.CalculateCityProfitabilityAndRate(null).ToList(), Throws.ArgumentNullException);
        }

        //[Test]
        //public void Linq8_Products_ReturnsGroupedProducts()
        //{
        //    decimal cheap = 10, middle = 30, expensive = 40;
        //    var result = LinqTask.Linq8(DataSource.Products, cheap, middle, expensive).ToList();

        //    var cheapProducts = result.Single(_ => _.category == cheap).products;
        //    Assert.That(cheapProducts.Count(), Is.EqualTo(1));
        //    var middleProducts = result.Single(_ => _.category == middle).products;
        //    Assert.That(middleProducts.Count(), Is.EqualTo(3));
        //    var expensiveProducts = result.Single(_ => _.category == expensive).products;
        //    Assert.That(expensiveProducts.Count(), Is.EqualTo(1));
        //}

        //[Test]
        //public void Linq8_NullProducts_ThrowsArgumentNullException()
        //{
        //    Assert.That(() => LinqTask.Linq8(null, 42, 42, 42).ToList(), Throws.ArgumentNullException);
        //}

        //[Test]
        //public void Linq9_Customers_ReturnsGroupedProducts()
        //{
        //    var expected = new List<(string city, int averageIncome, int averageIntensity)>
        //    {
        //        ("Berlin", 2023, 3),
        //        ("Mexico D.F.", 680, 2),
        //        ("London", 690, 1),
        //        ("Warszawa", 1, 0),
        //        ("Sao Paulo", 0, 0),
        //        ("USA", 0, 0)
        //    };

        //    var result = LinqTask.Linq9(DataSource.Customers).ToList();

        //    foreach (var valueTuple in result)
        //    {
        //        var expectedValue = expected.Single(_ => _.city == valueTuple.city);
        //        Assert.That(expectedValue.averageIncome, Is.EqualTo(valueTuple.averageIncome));
        //        Assert.That(expectedValue.averageIntensity, Is.EqualTo(valueTuple.averageIntensity));
        //    }
        //}

        //[Test]
        //public void Linq9_NullCustomers_ThrowsArgumentNullException()
        //{
        //    Assert.That(() => LinqTask.Linq9(null).ToList(), Throws.ArgumentNullException);
        //}

        //[Test]
        //public void GetHighValueCustomers0_Suppliers_ReturnsAggregateString()
        //{
        //    string result = LinqTask.GetHighValueCustomers0(DataSource.Suppliers);
        //    StringAssert.AreEqualIgnoringCase("UKUSAJapanSpainBrazilSwedenGermanyAustralia", result);
        //}

        //[Test]
        //public void GetHighValueCustomers0_NullSuppliers_ThrowsArgumentNullException()
        //{
        //    Assert.That(() => LinqTask.GetHighValueCustomers0(null).ToList(), Throws.ArgumentNullException);
        //}

        private static DateTime FindCustomerOrdersMinDate(Customer customer)
        {
            var min = DateTime.MaxValue;
            foreach (var order in customer.Orders)
            {
                if (order.OrderDate < min)
                {
                    min = order.OrderDate;
                }
            }

            return min;
        }
    }
}
