using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Parts
{
    public class PartBasicServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
