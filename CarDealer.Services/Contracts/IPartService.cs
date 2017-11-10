using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<PartExtendedServiceModel> GetAllParts(int page = 1, int pageSize = 12);

        PartExtendedServiceModel GetPartById(int id);

        int TotalPages();

        void Edit(int id, string name, double price, string supplier, int quatity = 1);
    }
}
