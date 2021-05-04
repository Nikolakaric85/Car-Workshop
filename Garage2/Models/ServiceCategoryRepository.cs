using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class ServiceCategoryRepository: IServiceCategoryRepository
    {
        private readonly AppDbContext context;

        public ServiceCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        IEnumerable<ServiceCategory> IServiceCategoryRepository.AllCategories => context.ServiceCategories;

        public ServiceCategory Add(ServiceCategory serviceCategory)
        {
            context.ServiceCategories.Add(serviceCategory);
            context.SaveChanges();
            return serviceCategory;
        }

        public ServiceCategory Update(ServiceCategory serviceCategory)
        {
            var category = context.ServiceCategories.Attach(serviceCategory);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return serviceCategory;
        }
    }
}


