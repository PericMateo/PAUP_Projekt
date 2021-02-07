using BlogPAUPLatestYT.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogPAUPLatestYT.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                /*if (HttpContext.User.Identity.IsAuthenticated)
                {
                    return View(returnUrl);
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
                    if()
                }
                */
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Panel");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(vm);
            //var result=await _signInManager.PasswordSignInAsync(vm.UserName,vm.Password,false,false);
            //return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
