using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars) => this.cars = cars;

        [Route("cars/parts", Order = 1)]
        public IActionResult Parts()
        {
            var carsWithParts = this.cars.WithParts();
            return View(carsWithParts);
        }

        [Route("cars/{make}", Order = 2)]
        public IActionResult Make(string make)
        {
            var carsbyMake = this.cars.ByMake(make);

            return View(carsbyMake);
        }
    }
}