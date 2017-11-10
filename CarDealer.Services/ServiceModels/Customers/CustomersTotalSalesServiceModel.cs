namespace CarDealer.Services.ServiceModels.Customers
{
    public class CustomersTotalSalesServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalBoughtCars { get; set; }

        public double TotalSpentMoney { get; set; }

    }
}
