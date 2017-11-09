﻿using CarDealer.Services;
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

        public CustomersController(ICustomerService customers) => this.customers = customers;

        //page edit/{id}
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit() => View();

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerModel
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

        // page create
        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CustomerModel model)
        {
            // TODO check if user exit

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
        public IActionResult TotalSales(int id) => View(this.customers.GetTotalSalesById(id));

        [Route("all/{orderType}", Order = 2)]
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
