using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("/customers/all/{order}")]
        public IActionResult All(string order)
        {
            var orderType = order.ToLower() == "descending"
                ? OrderType.Descending
                : OrderType.Ascending;

            var orderedCustomers = this.customers.OrderedCustomers(orderType);

            return View(new AllCustomersModel
            {
                Customers = orderedCustomers,
                OrderType = orderType
            });
        }
    }
}
