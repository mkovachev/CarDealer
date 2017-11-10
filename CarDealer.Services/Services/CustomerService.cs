using CarDealer.Data;
using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Services.Enums;
using CarDealer.Services.ServiceModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db) => this.db = db;

        public CustomerServiceModel GetById(int id)
            => this.db
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();

        public void Edit(int id, string name, DateTime birthDate, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(id);

            if(existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDate = birthDate;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();

        }

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

        public IEnumerable<CustomerServiceModel> GetCustomersByOrderType(OrderType orderType)
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
                .Select(c => new CustomerServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public IEnumerable<CustomersTotalSalesServiceModel> GetTotalSalesById(int id)
        {
            yield return this.db
                          .Customers
                          .Where(c => c.Id == id)
                          .Select(c => new CustomersTotalSalesServiceModel
                          {
                              Id = c.Id,
                              Name = c.Name,
                              TotalBoughtCars = c.Sales.Count(),
                              TotalSpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Part.Price))
                          })
                          .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.Customers.Any(c => c.Id == id);
        }

        public bool ExistsByName(string name)
        {
            return this.db.Customers.Any(c => c.Name == name);
        }
    }
}
