namespace CarDealer.Services.Models.Customers
{
    public class CustomersTotalSalesModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalBoughtCars { get; set; }

        public double TotalSpentMoney { get; set; }

    }
}
