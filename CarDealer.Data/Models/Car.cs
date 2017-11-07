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

        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

        public ICollection<PartCar> PartsCars { get; set; } = new HashSet<PartCar>();
    }
}
