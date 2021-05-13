using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly AppDbContext context;

        public ServiceRepository(AppDbContext context)
        {
            this.context = context;
        }

        IEnumerable<Service> IServiceRepository.AllServices => context.Services;

        public Service Add(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return service;
        }

        public Service Update(Service service)
        {
            var serviceToUpdate = context.Services.Attach(service);
            serviceToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return service;
        }

        public Service Delete(int id)
        {
            Service service = context.Services.Find(id);
            context.Services.Remove(service);
            context.SaveChanges();
            return null;
        }
    }
}

