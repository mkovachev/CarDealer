using System.Collections.Generic;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db) => this.db = db;

        public IEnumerable<CarModel> ByMake(string make)
        {
            return this.db
                          .Cars
                          .Where(c => c.Make == make)
                          .OrderBy(c => c.Model)
                          .ThenByDescending(c => c.TravelledDistance)
                          .Select(c => new CarModel
                          {
                              Make = c.Make,
                              Model = c.Model,
                              TravelledDistance = c.TravelledDistance / 1000
                          })
                          .ToList();

        }
    }
}
