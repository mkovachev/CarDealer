using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Services.ServiceModels.Suppliers
{
    public class SupplierServiceModel
    {
        public string Name { get; set; }

        public IEnumerable<PartBasicServiceModel> Parts { get; set; }
    }
}
