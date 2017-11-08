using CarDealer.Services.Models.Suppliers;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> ByType(string supplierType);
    }
}
