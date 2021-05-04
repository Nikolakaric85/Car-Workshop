using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
   public interface IServiceRepository
    {
        IEnumerable<Service> AllServices { get; }
        Service Add(Service service);
        Service Update(Service service);
    }
}
