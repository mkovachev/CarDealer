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

        public void Edit(int id, string name, double price, string supplier, int quatity = 1)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Name = name;
            part.Price = price;
            part.Supplier.Name = supplier; // TODO
            part.Quantity = quatity;

            this.db.SaveChanges();
        }

        //witn pagination
        public IEnumerable<PartExtendedServiceModel> GetAllParts(int page = 1, int pageSize = 12)
        {
            return this.db
                .Parts
                .OrderByDescending(p => p.Id) // the most newest on top
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PartExtendedServiceModel
                {
                    Id = p.Id, // important: always map id
                    Name = p.Name,
                    Price = p.Price,
                    Supplier = p.Supplier.Name,
                    Quantity = p.Quantity
                })
                .ToList();
        }

        public PartExtendedServiceModel GetPartById(int id)
        {
            return this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new PartExtendedServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Supplier = p.Supplier.Name,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();
        }

        public int TotalPages() => this.db.Parts.Count();
    }
}
