using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;
using System.Text.RegularExpressions;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(cust => cust.Orders.Sum(s => s.Total) > limit);

        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null) throw new ArgumentNullException(nameof(customers));
            return (IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)>)customers.Select(cust => new { firstOrder = cust.Orders.Min(o => o.OrderDate) });
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
        IEnumerable<Customer> customers,
        IEnumerable<Supplier> suppliers)
        {
            if (customers == null || suppliers == null) throw new ArgumentNullException(nameof(customers));
            var customersWithFirstOrderDate = customers
              .Select(cust => new
              {
                  Customer = cust,
                  FirstOrder = cust.Orders.Min(o => o.OrderDate),
                  Turnover = cust.Orders.Sum(s => s.Total)
              })
              .OrderBy(c => c.FirstOrder.Year)
              .ThenBy(c => c.FirstOrder.Month)
              .ThenByDescending(c => c.Turnover)
              .ThenBy(c => c.Customer.CompanyName);

            return customersWithFirstOrderDate.Select(c => (c.Customer, suppliers.Where(s => s.Country == c.Customer.Country && s.City == c.Customer.City)));
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null) throw new ArgumentNullException(nameof(customers));
            var customersWithLimit = customers.Where(cust => Regex.IsMatch(cust.PostalCode, @"^\d+$") || string.IsNullOrEmpty(cust.Region) || (!cust.Phone.Contains("(")));
            return customersWithLimit.Where(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null) throw new ArgumentNullException(nameof(customers));

            throw new NotImplementedException();
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null) throw new ArgumentNullException(nameof(customers));
            throw new NotImplementedException();
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null) throw new ArgumentNullException(nameof(customers));
            var customerList = customers.ToList();
            customerList.RemoveAt(0);
            customerList.RemoveAt(0);
            customerList.RemoveAt(3);

            return customerList;
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            return products
                       .GroupBy(p => p.Category)
                       .Select(categoryGroup => new Linq7CategoryGroup
                       {
                           Category = categoryGroup.Key,
                           UnitsInStockGroup = categoryGroup
                               .GroupBy(p => p.UnitsInStock)
                               .Select(stockGroup => new Linq7UnitsInStockGroup
                               {
                                   UnitsInStock = stockGroup.Key,
                                   Prices = stockGroup.OrderBy(p => p.UnitPrice).Select(p => p.UnitPrice).ToList()
                               })
                               .ToList()
                       })
                       .ToList();
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            throw new NotImplementedException();
        }
    }
}