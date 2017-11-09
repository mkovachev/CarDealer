using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.Models
{
    public class CustomerModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
