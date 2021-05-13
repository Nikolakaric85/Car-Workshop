using Garage2.Models.Car;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsRepository carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public IActionResult AddCars()
        {
            return View();
        }

        public IActionResult CreateCars(Cars cars)
        {
            carsRepository.Add(cars);
            return RedirectToAction("UserCars","Services",new { id = cars.UserId});
        }

        public IActionResult EditCar(int Id)
        {
            var model = carsRepository.AllCars.FirstOrDefault(x => x.Id == Id);

            var car = new CarUserViewModel();
            car.Cars = model;

            return View("AddCars", car);
        }

        public IActionResult UpdateCar(Cars cars)
        {
            carsRepository.Update(cars);
            return RedirectToAction("UserCars","Services", new { id = cars.UserId});
        }

    }
}
