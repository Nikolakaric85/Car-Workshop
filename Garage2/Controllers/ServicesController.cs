using Garage2.Models;
using Garage2.Models.Car;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Garage2.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceCategoryRepository categoryRepository;
        private readonly IServiceItemRepositiry itemRepositiry;
        private readonly IServiceRepository serviceRepository;
        private readonly ICategoryItemsRepository categoryItemsRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly ICarsRepository carsRepository;

        public ServicesController(IServiceCategoryRepository categoryRepository,
            IServiceItemRepositiry itemRepositiry,
            IServiceRepository serviceRepository,
            ICategoryItemsRepository categoryItemsRepository,
            UserManager<AppUser> userManager,
            ICarsRepository carsRepository
            )
        {
            this.categoryRepository = categoryRepository;
            this.itemRepositiry = itemRepositiry;
            this.serviceRepository = serviceRepository;
            this.categoryItemsRepository = categoryItemsRepository;
            this.userManager = userManager;
            this.carsRepository = carsRepository;
        }

        //  SERVICES

        //Show all users 
        public IActionResult Services(string searchTerm)
        {
            var model = new CarUserViewModel();

            if (searchTerm == null)
            {
                model.AppUsersEnumerable = userManager.Users;
                return View(model);
            }
            else
            {

                model.AppUsersEnumerable = userManager.Users.Where(x => x.UserName.Contains(searchTerm)||
                                                                        x.LastName.Contains(searchTerm)||
                                                                        x.Email.Contains(searchTerm)||
                                                                        x.PhoneNumber.Contains(searchTerm));
                return View(model);
            }
        }

        //Show cars for curent user
        public IActionResult UserCars(string id)
        {
            var model = new CarUserViewModel();
            model.CarsEnumerable = carsRepository.AllCars.Where(x => x.UserId == id);

            ViewBag.curentUser = userManager.Users.FirstOrDefault(x => x.Id == id).UserName;

            return View(model);
        }

        //Show services for selected user car
        public IActionResult ShowServices(int id)
        {
            var model = new ServiceViewModel();
            model.ServiceEnumerable = serviceRepository.AllServices.Where(x => x.CarId == id);

            ViewBag.carModel = carsRepository.AllCars.FirstOrDefault(x => x.Id == id).Model;

            return View(model);
        }
        //Create new service
        [HttpGet]
        public IActionResult NewService(int id)
        {
            if (id == 0)
            {
                ViewBag.CategoryItems = new SelectList(itemRepositiry.AllItems, "Item", "Item", 1, "Category");
                return View("_AddNewService");
            }
            else
            {
                var catItems = categoryItemsRepository.AllCategoryItems.Where(x => x.ServiceId == id).Select(x => x.Items);

                ViewBag.CategoryItems = new MultiSelectList(itemRepositiry.AllItems, "Item", "Item", catItems, "Category");

                var service = serviceRepository.AllServices.FirstOrDefault(x => x.ServiceId == id);

                var model = new ServiceViewModel()
                {
                    Service = service
                };
                return View("_AddNewService", model);
            }
        }


        public IActionResult AddNewService(ServiceViewModel serviceViewModel, string[] array, string returnUrl)
        {
            if (serviceViewModel.Service.ServiceId == 0) // ako je Service.ServiceId = 0 onda kreiraj nov servis ako ne onda ide update
            {
                var service = new Service()
                {
                    ServiceId = serviceViewModel.Service.ServiceId,
                    ServiceDate = serviceViewModel.Service.ServiceDate,
                    Mileage = serviceViewModel.Service.Mileage,
                    ServiceCost = serviceViewModel.Service.ServiceCost,
                    Notes = serviceViewModel.Service.Notes,
                    CarId = serviceViewModel.Service.CarId

                };

                serviceRepository.Add(service);

                foreach (var item in array)
                {
                    var itemId = itemRepositiry.AllItems.Where(x => x.Item == item).FirstOrDefault().ItemId;

                    var cat = itemRepositiry.AllItems.Where(x => x.Item == item).FirstOrDefault().Category;

                    var catId = categoryRepository.AllCategories.Where(x => x.Category == cat).FirstOrDefault().CategoryId;

                    var categoryItem = new CategoryItems()
                    {
                        Items = item,
                        ServiceId = service.ServiceId,
                        ItemId = itemId,
                        CategoryId = catId,
                        Category = cat
                    };

                    categoryItemsRepository.Add(categoryItem);
                }

                return RedirectToAction("ShowServices", new { id = serviceViewModel.Service.CarId });

            }
            else // odavde ide update
            {
                serviceRepository.Update(serviceViewModel.Service); // update service model

                //first delete categories items which we want to update
                var catItemsId = categoryItemsRepository.AllCategoryItems.Where(x => x.ServiceId == serviceViewModel.Service.ServiceId).Select(x => x.Id).ToList(); // need to be toList() in order to delete 

                foreach (var id in catItemsId)
                {
                    categoryItemsRepository.Delete(id);
                }

                //create updated categories items 
                foreach (var item in array)
                {
                    var itemId = itemRepositiry.AllItems.Where(x => x.Item == item).FirstOrDefault().ItemId;

                    var cat = itemRepositiry.AllItems.Where(x => x.Item == item).FirstOrDefault().Category;

                    var catId = categoryRepository.AllCategories.Where(x => x.Category == cat).FirstOrDefault().CategoryId;

                    var categoryItem = new CategoryItems()
                    {
                        Items = item,
                        ServiceId = serviceViewModel.Service.ServiceId,
                        ItemId = itemId,
                        CategoryId = catId,
                        Category = cat
                    };

                    categoryItemsRepository.Add(categoryItem);
                }
            }

            return RedirectToAction("ShowServices", new { id = serviceViewModel.Service.CarId });
        }

        public IActionResult DeleteService(int Id)
        {
            var catItem = categoryItemsRepository.AllCategoryItems.Where(x => x.ServiceId == Id).Select(x => x.Id).ToList();

            foreach (var id in catItem)
            {
                categoryItemsRepository.Delete(id);
            }

            var carId = serviceRepository.AllServices.FirstOrDefault(x => x.ServiceId == Id).CarId;

            serviceRepository.Delete(Id);

            return RedirectToAction("ShowServices", new { id = carId });
        }
    // CUSTOMER SERVICES

        [HttpGet]
        public IActionResult CustomerServices()
        {
            ViewBag.user = userManager.GetUserName(HttpContext.User);

            var userId = userManager.GetUserId(HttpContext.User);
            var usersCar = carsRepository.AllCars.Where(x => x.UserId == userId && x.IsActive == true);
            ViewBag.userCars = new SelectList(usersCar,"Id","Model");

            return View();
        }

        [HttpPost]
        public IActionResult CustomerServices(int id)
        {
            ViewBag.user = userManager.GetUserName(HttpContext.User);

            var userId = userManager.GetUserId(HttpContext.User);
            var usersCar = carsRepository.AllCars.Where(x => x.UserId == userId && x.IsActive == true);
            ViewBag.userCars = new SelectList(usersCar, "Id", "Model");

            ViewBag.selectedCar = carsRepository.AllCars.FirstOrDefault(x => x.Id == id).Model;

            var model = new ServiceViewModel();
            model.ServiceEnumerable = serviceRepository.AllServices.Where(x => x.CarId == id);
            return View(model);
        }

      
        public IActionResult ServiceDetails(int id)
        {            
            var model = categoryItemsRepository.AllCategoryItems.Where(x => x.ServiceId == id);
            return View("_ServiceDetails", model );
        }


    }
}






/*
 
 */