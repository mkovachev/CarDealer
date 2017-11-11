using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars) => this.cars = cars;

        [Route(nameof(WithParts), Order = 1)]
        public IActionResult WithParts()
        {
            var carsWithParts = this.cars.GetCarsWithParts();
            return View(carsWithParts);
        }

        [Route("{make}", Order = 2)]
        public IActionResult All(string make)
        {
            var carsbyMake = this.cars.GetCarsByMake(make);

            return View(carsbyMake);
        }
    }
}