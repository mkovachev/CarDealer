using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Web.ViewModels.PartsViewModels
{
    public class PartPaginationViewModel
    {
        public IEnumerable<PartExtendedServiceModel> Parts { get; set; }

        public int Current { get; set; }

        public int Previous => this.Current == 1 ? 1 : this.Current - 1;

        public int TotalPages { get; set; }

        public int Next => this.Current == TotalPages ? this.TotalPages : Current + 1;

        
    }
}
