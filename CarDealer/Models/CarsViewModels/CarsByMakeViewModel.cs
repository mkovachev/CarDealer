using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Web.Models.CarViewModels
{
    public class CarsByMakeViewModel: CarModel
    {
        public IEnumerable<CarModel> CarsByMake { get; set; }
    }
}
