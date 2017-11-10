using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Cars;
using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db) => this.db = db;

        public IEnumerable<CarServiceModel> GetCarsByMake(string make)
        {
            var cars = this.db.Cars.AsQueryable();

            if (make != "all")
            {
                return cars
                  .Where(c => c.Make == make)
                  .OrderBy(c => c.Model)
                  .ThenByDescending(c => c.TravelledDistance)
                  .Select(c => new CarServiceModel
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
                    .Select(c => new CarServiceModel
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance / 1000
                    })
                    .ToList();

        }

        public IEnumerable<CarWithPartsServiceModel> GetCarsWithParts()
        {
            var cars = this.db.Cars.AsQueryable();

            return cars
                   .OrderByDescending(c => c.Id)
                   .Select(s => new CarWithPartsServiceModel
                   {
                       Make = s.Make,
                       Model = s.Model,
                       Parts = s.Parts.Select(p => new PartServiceModel // TODO
                       {
                           Name = p.Part.Name,
                           Price = p.Part.Price
                       })
                   })
                .ToList();
        }
    }
}
