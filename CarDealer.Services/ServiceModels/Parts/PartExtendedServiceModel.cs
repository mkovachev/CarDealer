using CarDealer.Services.ServiceModels.Suppliers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Parts
{
    public class PartExtendedServiceModel: PartBasicServiceModel
    {
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public string Supplier { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        // dropdown suppliers data
        public IEnumerable<SupplierBasicServiceModel> Suppliers { get; set; }

    }
}
