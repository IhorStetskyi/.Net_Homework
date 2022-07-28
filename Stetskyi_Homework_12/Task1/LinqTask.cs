using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException("Customers can not be null");
            }
            var result = customers.Where(customer => customer.Orders.Sum(x => x.Total) > limit);
            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException("Customers and Suppliers can not be null");
            }

            var result = customers.GroupJoin(suppliers, c => c.City, s => s.City,
                (customerClass, supplierClass)
                =>
                new { customerClass = customerClass, supplierClass = supplierClass });

            foreach (var item in result)
            {
                yield return (item.customerClass, item.supplierClass);
            }
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException("Customers and Suppliers can not be null");
            }

            var result = customers.Join(suppliers, c => c.City, w => w.City,
                (key, value) => new { customerClass = key, supplierList = value }).
                GroupBy(keySelector: x => x.customerClass,
                elementSelector: y => y.supplierList,
                resultSelector: (key, value) => new { customerClass = key, supplierClass = value });

            foreach (var item in result)
            {
                yield return (item.customerClass, item.supplierClass);
            }
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException("Customers can not be null");
            }
            //Max does not fail test
            var result = customers.Where(customer => customer.Orders.Count() > 0 && customer.Orders.Max(x => x.Total) > limit);

            //This looks correct however test fails (Find all customers with the sum of all orders that exceed a certain value). Task typo?
            //var linqResult = customers.Where(customer => customer.Orders.Count() > 0 && customer.Orders.Sum(x => x.Total) > limit);
            return result;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException("Customers can not be null");
            }
            var result = customers.Where(x => x.Orders.Count() > 0).Select(Customer => new { Customer, DateTime = Customer.Orders.Min(ord => ord.OrderDate) });

            foreach (var item in result)
            {
                yield return (item.Customer, item.DateTime);
            }
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException("Customers can not be null");
            }
            var result = customers.Where(x => x.Orders.Count() > 0).
                Select(Customer => new { Customer, DateTime = Customer.Orders.Min(ord => ord.OrderDate) })
                .OrderBy(year => year.DateTime.Year).ThenBy(month => month.DateTime.Month).ThenByDescending(turnover => turnover.Customer.Orders.Sum(o => o.Total)).ThenBy(name => name.Customer.CustomerID);
            foreach (var item in result)
            {
                yield return (item.Customer, item.DateTime);
            }
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException("Customers can not be null");
            }
            var result = customers.Where(customers => customers.Region == null || !customers.Phone.Contains('(') || Regex.IsMatch(customers.PostalCode, @"[a-zA-Z]"));
            return result;
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            if (products == null)
            {
                throw new ArgumentNullException("Products can not be null");
            }

            List<Linq7CategoryGroup> categoryGroupListToReturn = new List<Linq7CategoryGroup>();

            var linqResult = products.GroupBy(keySelector: x => x.Category,
                elementSelector: y => y,
                resultSelector: (key, value) => new {
                    Category = key,
                    UnitsPriceAndStock = value
                .GroupBy(keySelector: x => x.UnitsInStock,
                elementSelector: y => y.UnitPrice,
                resultSelector: (unitsInStock, unitPrice) => new { unitsInStock = unitsInStock, unitPrice = unitPrice })
                .OrderBy(x => x.unitPrice.Sum())
                });

            foreach (var group in linqResult)
            {
                Linq7CategoryGroup categoryGroup = new Linq7CategoryGroup();
                List<Linq7UnitsInStockGroup> unitsAndStockGroupList = new List<Linq7UnitsInStockGroup>();
                foreach (var unitspriceandstock in group.UnitsPriceAndStock)
                {
                    Linq7UnitsInStockGroup stockGroup = new Linq7UnitsInStockGroup();
                    List<decimal> pricesList = new List<decimal>();
                    foreach (var price in unitspriceandstock.unitPrice)
                    {
                        pricesList.Add(price);
                    }
                    stockGroup.UnitsInStock = unitspriceandstock.unitsInStock;
                    stockGroup.Prices = pricesList;
                    unitsAndStockGroupList.Add(stockGroup);
                }
                categoryGroup.Category = group.Category;
                categoryGroup.UnitsInStockGroup = unitsAndStockGroupList;
                categoryGroupListToReturn.Add(categoryGroup);
            }
            return categoryGroupListToReturn;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {

            if (products == null)
            {
                throw new ArgumentNullException("Products can not be null");
            }

            var ranges = new[] { cheap, middle, expensive };
            var result = products.GroupBy(
                keySelector: x => ranges.FirstOrDefault(r => r >= x.UnitPrice),
                elementSelector: y => y,
                resultSelector: (key, value) => new { Price = key, Products = value }).OrderBy(x => x.Price);

            foreach (var item in result)
            {
                yield return (item.Price, item.Products);
            }
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException("Customers can not be null");
            }
            var result = customers.GroupBy(keySelector: x => x.City,
                elementSelector: y => new { TotalMoney = y.Orders.Select(x => x.Total), Count = y.Orders.Count() },
                resultSelector: (key, value) => new {
                    city = key,
                    averageIncome = value.Average(x => x.TotalMoney.Sum()),
                    averageIntensity = value.Average(x => x.Count)
                });
            foreach (var item in result)
            {
                yield return (item.city, Convert.ToInt32(item.averageIncome), Convert.ToInt32(item.averageIntensity));
            }
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                throw new ArgumentNullException("Suppliers can not be null");
            }
            var result = suppliers.GroupBy(country => country.Country.ToString(),
                resultSelector: (Country, Data) => new { Country = Country })
                .OrderBy(x => x.Country.Length)
                .ThenBy(x => x.Country)
                .Select(x => x.Country)
                .Aggregate("", (current, next) => $"{current}{next}");
            return result;
        }
    }
}