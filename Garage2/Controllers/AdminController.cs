using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Users(string searchTerm)
        {
            if (searchTerm == null)
            {
                var users = userManager.Users;   
                return View(users);
            } else
            {

                var serchedUser = userManager.Users.Where(x => x.UserName.Contains(searchTerm) ||
                                                                        x.LastName.Contains(searchTerm) ||
                                                                        x.Email.Contains(searchTerm) ||
                                                                        x.PhoneNumber.Contains(searchTerm));
            return View(serchedUser);
            }

        }


        /*   var model = new CarUserViewModel();

            if (searchTerm == null)
            {
                model.AppUsersEnumerable = userManager.Users;
                return View(model);
            }
            else
                model.AppUsersEnumerable = userManager.Users.Where(x => x.UserName.Contains(searchTerm)||
                                                                        x.LastName.Contains(searchTerm)||
                                                                        x.Email.Contains(searchTerm)||
                                                                        x.PhoneNumber.Contains(searchTerm));
            return View(model);*/

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var users = userManager.Users.FirstOrDefault(u => u.Id == id);
            var model = new AppUser()
            {
                Id = users.Id,
                UserName = users.UserName,
                LastName = users.LastName,
                Email = users.Email,
                PhoneNumber = users.PhoneNumber,
                LicencePlate = users.LicencePlate,
            };

            var userRole = userManager.Users.FirstOrDefault(u => u.Id == id).RoleName;
            ViewBag.roleName = new SelectList(roleManager.Roles, "Name","Name", users.RoleName);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(AppUser appUser)
        {
            var user = await userManager.FindByIdAsync(appUser.Id);
            user.Id = appUser.Id;
            user.UserName = appUser.UserName;
            user.LastName = appUser.LastName;
            user.PhoneNumber = appUser.PhoneNumber;
            user.LicencePlate = appUser.LicencePlate;
            user.Email = appUser.Email;
            

            IdentityRole identityRole = new IdentityRole
            { 
                Name = appUser.RoleName,    
            };

            var userRoles = await userManager.GetRolesAsync(user);          //roles for given user

            if ((await roleManager.RoleExistsAsync(identityRole.Name)) == false && userRoles.Count == 0)             
            {
                   await roleManager.CreateAsync(identityRole);                            //Creates the specified role in the AspNetRoles => Id|Name|NormalizedName|ConcurrencyStamp
                   await userManager.AddToRoleAsync(user, identityRole.Name);              //Add the specified user to the named role AspNetUserRoles => UserId|RoleId
            }
            else
            {
                foreach (var role in userRoles)
                {
                    await userManager.RemoveFromRoleAsync(user, role);
                }
                await roleManager.CreateAsync(identityRole);
                await userManager.AddToRoleAsync(user, identityRole.Name);
            }

            user.RoleName = appUser.RoleName;

            await userManager.UpdateAsync(user);

            return RedirectToAction("Users", "Admin");
        }




    }
}

