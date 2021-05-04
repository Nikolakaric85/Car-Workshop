using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.ViewComponents
{
    public class AddCategoriesViewComponent: ViewComponent
    {
        private readonly IServiceCategoryRepository categoryRepository;
        private readonly ICategoryItemsRepository categoryItemsRepository;
        private readonly IServiceItemRepositiry serviceItemRepositiry;

        public AddCategoriesViewComponent(IServiceCategoryRepository categoryRepository, ICategoryItemsRepository categoryItemsRepository, IServiceItemRepositiry serviceItemRepositiry)
        {
            this.categoryRepository = categoryRepository;
            this.categoryItemsRepository = categoryItemsRepository;
            this.serviceItemRepositiry = serviceItemRepositiry;
        }
        public IViewComponentResult Invoke()
        {
            var model = new ServiceViewModel();
            model.ServiceCategoriesEnumerable = categoryRepository.AllCategories;
            model.CategoryItemsEnumerable = categoryItemsRepository.AllCategoryItems;
            model.ServiceItemsEnumerable = serviceItemRepositiry.AllItems;

            return View(model);

        }
    }
}
