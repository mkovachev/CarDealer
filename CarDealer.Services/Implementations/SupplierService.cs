using CarDealer.Data;
using CarDealer.Services.Models;
using CarDealer.Services.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db) => this.db = db;

        public IEnumerable<SupplierModel> ByType(string supplierType)
        {
            var suppliers = this.db.Suppliers.AsQueryable();

            switch (supplierType)
            {
                case "local":
                    suppliers
                        .Where(s => s.IsImporter == false)
                        .OrderBy(s => s.Name);
                    break;
                case "importer":
                    suppliers
                        .Where(s => s.IsImporter == true)
                        .OrderBy(s => s.Name);
                    break;
                default: throw new InvalidOperationException($"Invalid supplier type: {supplierType}");
            }

            return suppliers
                .Select(s => new SupplierModel
                {
                    Name = s.Name,
                    Parts = s.Parts.Select(p => new PartsModel
                    {
                        Name = p.Name,
                        Price = (decimal)p.Price
                    })
                })
                .ToList();
        }
    }
}