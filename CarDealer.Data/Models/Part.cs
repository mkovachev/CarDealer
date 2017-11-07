using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Data.Models
{
    public class Part
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "money")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCar> PartsCars { get; set; } = new HashSet<PartCar>();

        public Supplier Supplier { get; set; }
    }
}
