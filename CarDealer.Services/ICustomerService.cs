using CarDealer.Services.Models;
using CarDealer.Services.Models.Customers;
using CarDealer.Services.Models.Enums;
using System;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetCustomersByOrderType(OrderType orderType);

        IEnumerable<CustomersTotalSalesModel> GetTotalSalesById(int id);

        CustomerModel GetById(int id);

        void Create(string name, DateTime birthDate, bool isYoungDriver);

        void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);

        bool Exists(int id);

        bool ExistsByName(string name);

    }
}