using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models.Car
{
    public interface ICarsRepository
    {
        IEnumerable<Cars> AllCars { get; }
        Cars Add(Cars cars);
        Cars Update(Cars cars);
    }
}
