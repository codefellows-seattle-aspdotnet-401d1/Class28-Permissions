using Lab28Roles.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lab28Roles.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManger = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManger.FindByEmailAsync(lvm.Email);
                var result = await _signInManager.CheckPasswordSignInAsync(user, lvm.Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    List<Claim> myClaims = new List<Claim>();

                    //Claim for the user's name
                    Claim claim1 = new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName, ClaimValueTypes.String);
                    myClaims.Add(claim1);

                    // claim for the User's role
                    Claim claim2 = new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String);
                    myClaims.Add(claim2);

                    //10/19/2017 class lecure below

                    Claim dateOfBirth = new Claim(ClaimTypes.DateOfBirth, user.Birthday.Date.ToString(), ClaimValueTypes.Date);
                    myClaims.Add(dateOfBirth);

                    var userIdentity = new ClaimsIdentity("Registration");
                    userIdentity.AddClaims(myClaims);

                    var userPrinciple = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, userPrinciple,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                            IsPersistent = false,
                            AllowRefresh = false

                        });

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = rvm.Email, Email = rvm.Email, FirstName = rvm.FirstName, LastName = rvm.LastName, Birthday = rvm.Birthday };
                var result = await _userManger.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    //Create a list where my claims will be added to
                    List<Claim> myClaims = new List<Claim>();

                    //Claim for the user's name
                    Claim claim1 = new Claim(ClaimTypes.Name, rvm.FirstName + " " + rvm.LastName, ClaimValueTypes.String);
                    myClaims.Add(claim1);

                    // claim for the User's role
                    Claim claim2 = new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String);
                    myClaims.Add(claim2);

                    //10/19/2017 class lecure below

                    Claim dateOfBirth = new Claim(ClaimTypes.DateOfBirth, rvm.Birthday.Date.ToString(), ClaimValueTypes.Date);
                    myClaims.Add(dateOfBirth);

                    var userIdentity = new ClaimsIdentity("Registration");
                    userIdentity.AddClaims(myClaims);

                    var userPrinciple = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, userPrinciple,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                            IsPersistent = false,
                            AllowRefresh = false

                        });

                    
                    var addClaims = await _userManger.AddClaimsAsync(user, myClaims);

                    // Make sure the claims were successfully added
                    if (addClaims.Succeeded)
                    {
                        await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, true, lockoutOnFailure: false);

                        return RedirectToAction("Index", "Home");
                    }

                }


            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View("Forbidden");
        }
        [Authorize]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return View();
        }
    }
}
