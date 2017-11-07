using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date), Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
