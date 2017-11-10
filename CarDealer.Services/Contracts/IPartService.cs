using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<PartListingServiceModel> GetAllParts(int page = 1);

        PartListingServiceModel GetPartById(int id);

        void Edit(int id, string name, double price, string supplier, int quatity = 1);
    }
}
