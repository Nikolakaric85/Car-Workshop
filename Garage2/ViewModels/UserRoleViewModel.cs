using Garage2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.ViewModels
{
    public class UserRoleViewModel
    {
        public string RoleId { get; set; }
        
        public string RoleName { get; set; }

        public AppUser AppUser { get; set; }
    }
}
