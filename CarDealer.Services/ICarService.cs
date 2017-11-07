using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);
    }
}
