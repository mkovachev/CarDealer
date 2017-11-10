using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Cars
{
    public class CarServiceModel
    {
        public string Model { get; set; }

        public string Make { get; set; }

        [Display(Name = "Travelled distance")]
        public long TravelledDistance { get; set; }
    }
}
