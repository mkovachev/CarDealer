using CarDealer.Services.ServiceModels.Suppliers;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ISupplierService
    {
        IEnumerable<SupplierBasicServiceModel> GetSuppliersByType(string supplierType);

        IEnumerable<SupplierBasicServiceModel> GetAllSuppliers();
    }
}
