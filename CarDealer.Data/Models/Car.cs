using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarDealer.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

        public ICollection<PartCar> Parts { get; set; } = new HashSet<PartCar>();
    }
}
