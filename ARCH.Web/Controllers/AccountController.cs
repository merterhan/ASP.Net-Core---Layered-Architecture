﻿using ARCH.Web.Entities;
using ARCH.Web.Models;
using ARCH.Web.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ARCH.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly ISessionService _sessionService;

        public AccountController(UserManager<CustomIdentityUser> userManager,
                                 RoleManager<CustomIdentityRole> roleManager,
                                 SignInManager<CustomIdentityUser> signInManager,
                                 IStringLocalizer<AccountController> localizer,
                                 ISessionService sessionService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _localizer = localizer;
            _sessionService = sessionService;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] //see surf ataklarını engellemeye çalışıyoruz
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber
                };

                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", _localizer["Sorry! We can not add the role"]);
                            return View(registerViewModel);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }

                    return View(registerViewModel);
                }
            }

            return View(registerViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password,
                    loginViewModel.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    //get user and set it to session
                    var user = _userManager.FindByNameAsync(loginViewModel.UserName).Result;
                    _sessionService.SetUser(user);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login!");
            }
            return View(loginViewModel);
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
