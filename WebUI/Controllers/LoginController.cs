﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel user)
        {
            AppUser appUser = new AppUser
            {
				Name = user.Name,
				Surname = user.Surname,
				UserName = user.Username,
				Email = user.Mail,
			};
            if (user.Password == user.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
					return RedirectToAction("SignIn");
				}
                else
                {
                    foreach (var item in result.Errors)
                    {
						ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel user)
        {

            if (ModelState.IsValid)
            {
                var result = (await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new {Area = "Member"});
                }
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
