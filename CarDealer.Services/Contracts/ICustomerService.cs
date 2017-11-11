using CarDealer.Services.Enums;
using CarDealer.Services.ServiceModels.Customers;
using System;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerBasicServiceModel> GetCustomersByOrderType(OrderType orderType);

        CustomersMoneySpentServiceModel GetBoughtCarsByUserId(int id);

        CustomerBasicServiceModel GetCustomerById(int id);

        void Create(string name, DateTime birthDate, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);

        bool Exists(int id);

    }
}