using System.Collections.Generic;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;
using CarDealer.Services.Models.Cars;

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

        public IEnumerable<CarWithPartsModel> WithParts()
        {
            return this.db
                          .Cars
                          .Select(c => new CarWithPartsModel
                          {
                              Make = c.Make,
                              Model = c.Model,
                              TravelledDistance = c.TravelledDistance / 1000,
                              Parts = c.Parts.Select(p => new PartsModel
                              {
                                  Name = p.Part.Name,
                                  Price = p.Part.Price
                              })
                          })
                          .ToList();
        }
    }
}
