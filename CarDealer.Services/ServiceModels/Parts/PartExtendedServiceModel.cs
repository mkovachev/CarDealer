using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Parts
{
    public class PartExtendedServiceModel: PartBasicServiceModel
    {
        public int Quantity { get; set; }

        public string Supplier { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        //public IEnumerable

    }
}
