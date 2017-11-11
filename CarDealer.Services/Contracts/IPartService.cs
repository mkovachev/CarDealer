using CarDealer.Services.ServiceModels.Parts;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<PartWithSuppliersServiceModel> GetAllParts(int page = 1, int pageSize = 12);

        PartWithSuppliersServiceModel GetPartById(int id);

        int TotalPages();

        void Add(string name, double price, int quantity, int supplierId);

        void Edit(int id, string name, double price, int quantity, int supplierId);

        bool Exists(int id);
    }
}
