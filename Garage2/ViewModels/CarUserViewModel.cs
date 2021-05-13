using Garage2.Models;
using Garage2.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.ViewModels
{
    public class CarUserViewModel
    {
        public IEnumerable<Cars> CarsEnumerable { get; set; }
        public IEnumerable<AppUser> AppUsersEnumerable { get; set; }
        public Cars Cars { get; set; }
    }
}
