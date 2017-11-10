namespace CarDealer.Services.ServiceModels.Parts
{
    public class PartListingServiceModel: PartServiceModel
    {
        public int Quantity { get; set; }

        public string Supplier { get; set; }
    }
}
