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

        void Create(string Name, DateTime BirthDate, bool isYoungDriver);
    }
}