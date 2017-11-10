using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class PartService : IPartService
    {
        public readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db) => this.db = db;

        public IEnumerable<PartListingServiceModel> GetAllParts()
        {
            return this.db
                .Parts
                .Select(p => new PartListingServiceModel
                {
                    Name = p.Name,
                    Price = (decimal)p.Price,
                    Quantity = p.Quantity,
                    Supplier = p.Supplier.ToString()
                })
                .ToList();
        }
    }
}
