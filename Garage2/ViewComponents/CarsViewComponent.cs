using Garage2.Models.Car;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.ViewComponents
{
    public class CarsViewComponent: ViewComponent
    {
        private readonly ICarsRepository carsRepository;

        public CarsViewComponent(ICarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = carsRepository.AllCars;
            return View(model);
        }
    }
}
