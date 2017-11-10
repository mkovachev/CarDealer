using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Services.ServiceModels.Cars
{
    public class CarWithPartsServiceModel : CarServiceModel
    {
        public IEnumerable<PartServiceModel> Parts { get; set; }
    }
}
