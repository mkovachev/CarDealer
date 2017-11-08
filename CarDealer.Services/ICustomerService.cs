using CarDealer.Services.Models;
using CarDealer.Services.Models.Customers;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderType orderType);

        IEnumerable<CustomersTotalSalesModel> TotalSales(int id);
    }
}