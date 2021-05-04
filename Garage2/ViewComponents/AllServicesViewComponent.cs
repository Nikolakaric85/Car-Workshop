using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Garage2.ViewComponents
{
    public class AllServicesViewComponent: ViewComponent
    {
        private readonly IServiceRepository serviceRepository;

        public AllServicesViewComponent(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ServiceViewModel();
            model.ServiceEnumerable = serviceRepository.AllServices;

            return View(model);
        }
    }
}
