using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Web.Models.CarViewModels;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars) => this.cars = cars;

        [Route("cars/{make}")]
        public IActionResult Make(string make)
        {
            var carsbyMake = this.cars.ByMake(make);

            return View(new CarsByMakeViewModel
            {
                CarsByMake = carsbyMake
            });
        }
    }
}