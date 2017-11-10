using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Data.Models
{
    public class Part
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCar> Parts { get; set; } = new HashSet<PartCar>();

        public Supplier Supplier { get; set; }
    }
}
