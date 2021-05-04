using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public interface IServiceItemRepositiry
    {
        IEnumerable<ServiceItem> AllItems {get;}
        ServiceItem Add(ServiceItem serviceItem);
        ServiceItem Update(ServiceItem serviceItem);
        ServiceItem Delete(int id);
    }
}
