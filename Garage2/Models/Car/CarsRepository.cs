using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models.Car
{
    public class CarsRepository : ICarsRepository
    {
        private readonly AppDbContext context;

        public CarsRepository(AppDbContext context)
        {
            this.context = context;
        }
        IEnumerable<Cars> ICarsRepository.AllCars => context.Cars;

        public Cars Add(Cars cars)
        {
            context.Cars.Add(cars);
            context.SaveChanges();
            return cars;
        }

        public Cars Update(Cars cars)
        {
            var carToUpdate = context.Cars.Attach(cars);
            carToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return cars;
        }
    }
}
