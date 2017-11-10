using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<PartListingServiceModel> GetAllParts();
    }
}
