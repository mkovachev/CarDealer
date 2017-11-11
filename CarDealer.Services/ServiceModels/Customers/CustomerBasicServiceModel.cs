using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Customers
{
    public class CustomerBasicServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Young Driver")]
        public bool IsYoungDriver { get; set; }
    }
}
