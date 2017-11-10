using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class PartService : IPartService
    {
        private const int PageSize = 25;

        public readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db) => this.db = db;

        public void Edit(int id, string name, double price, string supplier, int quatity = 1)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Name = name;
            part.Price = price;
            part.Quantity = quatity;
            part.Supplier.Name = supplier;

            db.SaveChanges();
        }

        public IEnumerable<PartListingServiceModel> GetAllParts(int page = 1)
        {
            return this.db
                .Parts
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(p => new PartListingServiceModel
                {
                    Id = p.Id, // important: always map id
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Supplier = p.Supplier.Name
                })
                .ToList();
        }

        public PartListingServiceModel GetPartById(int id)
        {
            return this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new PartListingServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Supplier = p.Supplier.Name
                })
                .FirstOrDefault();
        }
    }
}
