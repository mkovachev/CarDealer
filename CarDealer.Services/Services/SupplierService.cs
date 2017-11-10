﻿using CarDealer.Data;
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

        public IEnumerable<SupplierServiceModel> GetSuppliersByType(string supplierType)
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
                .Select(s => new SupplierServiceModel
                {
                    Name = s.Name,
                    Parts = s.Parts.Select(p => new PartServiceModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                })
                .ToList();
        }
    }
}