using CarDealer.Services.Models;
using CarDealer.Services.Models.Cars;
using System.Collections.Generic;

namespace CarDealer.Contracts.Services
{
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> WithParts();
    }
}
