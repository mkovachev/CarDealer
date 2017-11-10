using CarDealer.Services.Enums;
using CarDealer.Services.ServiceModels.Customers;
using System;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerServiceModel> GetCustomersByOrderType(OrderType orderType);

        CustomersTotalSalesServiceModel GetBoughtCarsByUserId(int id);

        CustomerServiceModel GetCustomerById(int id);

        void Create(string name, DateTime birthDate, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);

        bool Exists(int id);

    }
}