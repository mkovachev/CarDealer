using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.ServiceModels.Parts;
using CarDealer.Services.ServiceModels.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db) => this.db = db;

        public IEnumerable<SupplierBasicServiceModel> GetAllSuppliers()
            => this.db.Suppliers
                .OrderBy(s => s.Name)
                .Select(s => new SupplierBasicServiceModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();

        public IEnumerable<SupplierBasicServiceModel> GetSuppliersByType(string supplierType)
        {
            var suppliers = this.db.Suppliers.AsQueryable();

            switch (supplierType)
            {
                case "local":
                    suppliers
                        .Where(s => s.IsImporter == false)
                        .OrderBy(s => s.Name);
                    break;
                case "importers":
                    suppliers
                        .Where(s => s.IsImporter == true)
                        .OrderBy(s => s.Name);
                    break;
                default: throw new InvalidOperationException($"Invalid supplier type: {supplierType}");
            }

            return suppliers
                .OrderByDescending(c => c.Id)
                .Select(s => new SupplierBasicServiceModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Parts = s.Parts.Select(p => new PartBasicServiceModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                })
                .ToList();
        }
    }
}