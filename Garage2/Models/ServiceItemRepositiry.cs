using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class ServiceItemRepositiry: IServiceItemRepositiry
    {
        private readonly AppDbContext context;

        public ServiceItemRepositiry(AppDbContext context)
        {
            this.context = context;
        }

        IEnumerable<ServiceItem> IServiceItemRepositiry.AllItems => context.ServiceItems;

        public ServiceItem Add(ServiceItem serviceItem)
        {
            context.ServiceItems.Add(serviceItem);
            context.SaveChanges();
            return serviceItem;
        }

        public ServiceItem Update(ServiceItem serviceItem)
        {
            var item = context.ServiceItems.Attach(serviceItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return serviceItem;

        }

        public ServiceItem Delete(int id)
        {
            ServiceItem serviceItem = context.ServiceItems.Find(id);
            context.ServiceItems.Remove(serviceItem);
            context.SaveChanges();
            return serviceItem;
        }
    }
}
