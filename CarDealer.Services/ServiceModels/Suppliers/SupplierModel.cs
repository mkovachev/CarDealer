using System.Collections.Generic;

namespace CarDealer.Services.Models.Suppliers
{
    public class SupplierModel
    {
        public string Name { get; set; }

        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
