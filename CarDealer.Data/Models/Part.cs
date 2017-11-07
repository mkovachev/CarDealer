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

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCar> PartsCars { get; set; } = new HashSet<PartCar>();

        public Supplier Supplier { get; set; }
    }
}
