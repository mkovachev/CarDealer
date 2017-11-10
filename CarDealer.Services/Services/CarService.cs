using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using CarDealer.Services.Models.Cars;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db) => this.db = db;

        public IEnumerable<CarModel> ByMake(string make)
        {
            var cars = this.db.Cars.AsQueryable();

           if (make != "all")
            {
                return cars
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

           // if no make is given list all
            return cars
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
            var cars = this.db.Cars.AsQueryable();

            return cars
                   .Select(s => new CarWithPartsModel
                   {
                       Make = s.Make,
                       Model = s.Model,
                       Parts = s.Parts.Select(p => new PartsModel //TODO
                       {
                           Name = p.Part.Name,
                           Price = (decimal)p.Part.Price
                       })
                   })
                .ToList();
        }
    }
}
