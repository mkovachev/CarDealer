using CarDealer.Data;
using CarDealer.Data.Models;
using CarDealer.Services.Models;
using CarDealer.Services.Models.Customers;
using CarDealer.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db) => this.db = db;

        public void Create(string name, DateTime birthDate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = birthDate,
                IsYoungDriver = isYoungDriver
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }

        public IEnumerable<CustomerModel> GetCustomersByOrderType(OrderType orderType)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (orderType)
            {
                case OrderType.Ascending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.Name);
                    break;
                case OrderType.Descending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDate)
                         .ThenByDescending(c => c.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order type: {orderType}");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public IEnumerable<CustomersTotalSalesModel> GetTotalSalesById(int id)
        {
            yield return this.db
                          .Customers
                          .Where(c => c.Id == id)
                          .Select(c => new CustomersTotalSalesModel
                          {
                              Id = c.Id,
                              Name = c.Name,
                              TotalBoughtCars = c.Sales.Count(),
                              TotalSpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Part.Price))
                          })
                          .FirstOrDefault();
        }
    }
}
