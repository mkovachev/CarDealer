﻿using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars) => this.cars = cars;

        [Route("cars/parts", Order = 1)]
        public IActionResult WithParts()
        {
            var carsWithParts = this.cars.GetCarsWithParts();
            return View(carsWithParts);
        }

        [Route("cars/{make}", Order = 2)]
        public IActionResult Make(string make)
        {
            var carsbyMake = this.cars.GetCarsByMake(make);

            return View(carsbyMake);
        }
    }
}