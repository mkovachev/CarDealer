using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.ServiceModels.Customers
{
    public class CustomersMoneySpentServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Bought Cars")]
        public int BoughtCars { get; set; }

        [Display(Name = "Money Spent on Cars")]
        public double TotalSpentMoney { get; set; }

    }
}
