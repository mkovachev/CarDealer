using CarDealer.Services.Enums;
using CarDealer.Services.ServiceModels.Customers;
using System.Collections.Generic;

namespace CarDealer.Web.ViewModels.CustomersViewModels
{
    public class AllCustomersViewModel
    {
        public IEnumerable<CustomerBasicServiceModel> AllCustomers { get; set; }

        public OrderType OrderType { get; set; }
    }
}
