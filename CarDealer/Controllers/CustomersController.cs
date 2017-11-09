using CarDealer.Services;
using CarDealer.Services.Models;
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

        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.customers.Create(
                model.Name,
                model.BirthDate,
                model.IsYoungDriver
                );

            return RedirectToAction(nameof(All), new { orderType = OrderType.Ascending });
        }

        [Route("{id}", Order = 2)]
        public IActionResult TotalSales(int id)
        {
            return View(this.customers.GetTotalSalesById(id));
        }

        [Route("all/{orderType}", Order = 3)]
        public IActionResult All(OrderType orderType)
        {
            var orderedCustomers = this.customers.GetCustomersByOrderType(orderType);

            return View(new AllCustomersViewModel
            {
                AllCustomers = orderedCustomers,
                OrderType = orderType
            });
        }
    }
}
