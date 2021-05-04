using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.ViewComponents
{
    public class NewServicesViewComponent: ViewComponent
    {
        private readonly IServiceCategoryRepository categoryRepository;
        private readonly IServiceItemRepositiry itemRepositiry;

        public NewServicesViewComponent(IServiceCategoryRepository categoryRepository, IServiceItemRepositiry itemRepositiry)
        {
            this.categoryRepository = categoryRepository;
            this.itemRepositiry = itemRepositiry;
        }
        public IViewComponentResult Invoke()
        {

            ViewBag.CategoryItems = new SelectList(itemRepositiry.AllItems, "Item", "Item",1, "Category");

            return View();
        }
    }
}
