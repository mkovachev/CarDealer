using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars) => this.cars = cars;

        [Route(nameof(WithPartsDetails), Order = 1)]
        public IActionResult WithPartsDetails() => View(this.cars.GetCarsWithParts());

        [Route("{make}", Order = 2)]
        public IActionResult All(string make) => View(this.cars.GetCarsByMake(make));
    }
}