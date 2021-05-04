using Garage2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.ViewModels
{
    public class ServiceViewModel
    {
        public Service Service { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public ServiceItem ServiceItem { get; set; }
        public CategoryItems CategoryItems { get; set; }
        public IEnumerable<Service> ServiceEnumerable { get; set; }
        public IEnumerable<ServiceCategory> ServiceCategoriesEnumerable { get; set; }
        public IEnumerable<ServiceItem> ServiceItemsEnumerable { get; set; }
        public IEnumerable<CategoryItems> CategoryItemsEnumerable { get; set; }


    }
}
