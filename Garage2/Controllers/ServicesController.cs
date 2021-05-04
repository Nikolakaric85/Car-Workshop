using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Garage2.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceCategoryRepository categoryRepository;
        private readonly IServiceItemRepositiry itemRepositiry;
        private readonly IServiceRepository serviceRepository;
        private readonly ICategoryItemsRepository categoryItemsRepository;

        public ServicesController(IServiceCategoryRepository categoryRepository, IServiceItemRepositiry itemRepositiry, IServiceRepository serviceRepository, ICategoryItemsRepository categoryItemsRepository)
        {
            this.categoryRepository = categoryRepository;
            this.itemRepositiry = itemRepositiry;
            this.serviceRepository = serviceRepository;
            this.categoryItemsRepository = categoryItemsRepository;
        }
        public IActionResult Services()
        {
            //var model = new ServiceViewModel();
            //model.ServiceItemsEnumerable = itemRepositiry.AllItems;
            return View();
        }

        //  CATEGORIES 

        public IActionResult CreateCategory(ServiceViewModel viewModel, string cat)
        {
            var category = categoryRepository.AllCategories;

            var modelCategory = new ServiceCategory();

            if (!category.Any(x => x.Category == cat))
            {
                modelCategory.Category = cat;
                categoryRepository.Add(modelCategory);
            }

            var categoryName = categoryRepository.AllCategories.Where(x => x.Category == cat).FirstOrDefault().Category;

            var items = itemRepositiry.AllItems;

            var modelItem = new ServiceItem();

            if (!items.Any(x => x.Item == viewModel.ServiceItem.Item))
            {
                modelItem.Category = categoryName;
                modelItem.Item = viewModel.ServiceItem.Item;
                itemRepositiry.Add(modelItem);
            }

            return RedirectToAction("Services");
        }

        public IActionResult EditCategory(CategoryItems categoryItems)
        {
            var cat = categoryRepository.AllCategories.Where(x => x.CategoryId == categoryItems.Id).FirstOrDefault();
            var category = new ServiceCategory()
            {
                Category = cat.Category,
                CategoryId = cat.CategoryId
            };

            return View(category);
        }

        public IActionResult UpdateCategory(ServiceCategory serviceCategory)
        {
            categoryRepository.Update(serviceCategory);
            return RedirectToAction("Services");
        }

        //  ITEMS
        public IActionResult EditItem(CategoryItems categoryItems)
        {
            var item = itemRepositiry.AllItems.Where(x => x.ItemId == categoryItems.Id).FirstOrDefault();

            var model = new ServiceItem()
            {
                ItemId = item.ItemId,
                Item = item.Item,
                Category = item.Category
            };

            return View(model);
        }

        public IActionResult UpdateItem(ServiceItem serviceItem)
        {
            itemRepositiry.Update(serviceItem);
            return RedirectToAction("Services");
        }

        public IActionResult DeleteItem(int id)
        {
            itemRepositiry.Delete(id);
            return RedirectToAction("Services");
        }

        //  SERVICES

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


        public IActionResult AddNewService(ServiceViewModel serviceViewModel, string[] array)
        {
            if (serviceViewModel.Service.ServiceId == 0) // ako je Service.ServiceId = 0 onda kreiraj nov servis ako ne onda ide update
            {
                var service = new Service()
                {
                    ServiceId = serviceViewModel.Service.ServiceId,
                    ServiceDate = serviceViewModel.Service.ServiceDate,
                    Mileage = serviceViewModel.Service.Mileage,
                    ServiceCost = serviceViewModel.Service.ServiceCost,
                    Notes = serviceViewModel.Service.Notes
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

                return RedirectToAction("Services");

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
            return RedirectToAction("Services");
        }
    }
}






/*
 
 */