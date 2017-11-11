using CarDealer.Data;
using CarDealer.Data.Models;
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

        public void Add(string name, double price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity : 1,
                SupplierId = supplierId
            };

            this.db.Add(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, string name, double price, int quatity, int supplierId)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Name = name;
            part.Price = price;
            part.Quantity = quatity;
            part.SupplierId = supplierId;

            this.db.SaveChanges();
        }

        //witn pagination
        public IEnumerable<PartWithSuppliersServiceModel> GetAllParts(int page = 1, int pageSize = 12)
        {
            return this.db
                .Parts
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PartWithSuppliersServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Supplier = p.Supplier.Name,
                    Quantity = p.Quantity
                })
                .ToList();
        }

        public PartWithSuppliersServiceModel GetPartById(int id)
        {
            return this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new PartWithSuppliersServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SupplierId = p.Supplier.Id,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if(part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public int TotalPages() => this.db.Parts.Count();

        public bool Exists(int id)
        {
            return this.db.Suppliers.Any(s => s.Id == id);
        }
    }
}
