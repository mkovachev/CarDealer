using CarDealer.Services;
using CarDealer.Services.Models.Enums;
using CarDealer.Web.ViewModels.CustomersViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("all/{order}", Order = 2)]
        public IActionResult All(string order)
        {
            var orderType = order.ToLower() == "descending" // convert string order to enum type
                ? OrderType.Descending
                : OrderType.Ascending;

            var orderedCustomers = this.customers.OrderedCustomers(orderType);

            return View(new AllCustomersViewModel
            {
                AllCustomers = orderedCustomers,
                OrderType = orderType
            });
        }

        [Route("{id}", Order = 1)]
        public IActionResult TotalSales(int id)
        {
            return View(this.customers.TotalSales(id));
        }
    }
}
