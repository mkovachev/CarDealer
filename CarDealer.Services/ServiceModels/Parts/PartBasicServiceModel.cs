using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Parts
{
    public class PartBasicServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public string Supplier { get; set; }
    }
}
