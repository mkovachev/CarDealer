using CarDealer.Services.Models;
using CarDealer.Services.Models.Enums;
using System.Collections.Generic;

namespace CarDealer.Web.ViewModels.CustomersViewModels
{
    public class AllCustomersViewModel
    {
        public IEnumerable<CustomerModel> AllCustomers { get; set; }

        public OrderType OrderType { get; set; }
    }
}
