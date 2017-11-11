using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Parts
{
    public class PartWithSuppliersServiceModel: PartBasicServiceModel
    {
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        // dropdown suppliers data
        public IEnumerable<SelectListItem> Suppliers { get; set; }

    }
}
