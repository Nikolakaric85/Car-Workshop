using Garage2.Models;
using Garage2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Garage2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //REGISTER
        [HttpGet]
        public IActionResult _RegisterModalPartialView()
        {
            var model = new RegisterViewModel();
            return PartialView("_RegisterModalPartialView", model);
        }


        [HttpPost]
        public async Task<IActionResult> _RegisterModalPartialView(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    LicencePlate = model.LicencePlate,
                    Email = model.Email,
                    RoleName = "User"
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    await userManager.AddToRoleAsync(user, "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return PartialView(model);
        }

        //LOGOUT

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");

        }

        //LOGIN

        [HttpGet]
        public IActionResult _LoginModalPartialView()
        {
            //var model = new LoginViewModel();
            return View("_Login");
        }

        [HttpGet]
        public async Task<IActionResult> _Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(model.Email);
                var result = await signInManager.PasswordSignInAsync(appUser.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            TempData["error"] = "errorrrr";
            return View();
        }






    }
}
