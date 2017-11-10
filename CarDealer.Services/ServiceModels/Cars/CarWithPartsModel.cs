using System.Collections.Generic;

namespace CarDealer.Services.Models.Cars
{
    public class CarWithPartsModel : CarModel
    {
        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
