using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IServiceItemRepositiry itemRepositiry;
        private readonly IServiceCategoryRepository categoryRepository;

        public CategoriesController(IServiceItemRepositiry itemRepositiry, IServiceCategoryRepository categoryRepository)
        {
            this.itemRepositiry = itemRepositiry;
            this.categoryRepository = categoryRepository;
        }

        //CATEGORIES
        public IActionResult Categories()
        {
            var model = new ServiceViewModel();
            model.ServiceCategoriesEnumerable = categoryRepository.AllCategories;
            model.ServiceItemsEnumerable = itemRepositiry.AllItems;
            return View(model);
        }


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

            return RedirectToAction("Categories");
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
            return RedirectToAction("Categories");
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
            return RedirectToAction("Categories");
        }

        public IActionResult DeleteItem(int id)
        {
            itemRepositiry.Delete(id);
            return RedirectToAction("Categories");
        }

    }
}
