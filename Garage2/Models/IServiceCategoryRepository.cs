using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public interface IServiceCategoryRepository
    {
        IEnumerable<ServiceCategory> AllCategories { get; }
        ServiceCategory Add(ServiceCategory serviceCategory);
        ServiceCategory Update(ServiceCategory serviceCategory);

    }
}
