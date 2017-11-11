using CarDealer.Services.ServiceModels.Cars;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarBasicServiceModel> GetCarsByMake(string make);

        IEnumerable<CarWithPartsServiceModel> GetCarsWithParts();
    }
}
