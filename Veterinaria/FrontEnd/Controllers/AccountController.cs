﻿using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FrontEnd.ApiModels;

namespace FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        ISecurityHelper SecurityHelper;

        public AccountController(ISecurityHelper securityHelper)
        {
            SecurityHelper = securityHelper;
        }

        public IActionResult Login(string ReturneUrl = "/")
        {

            UserViewModel user = new UserViewModel();
            user.ReturnUrl = ReturneUrl;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var loginModel = SecurityHelper.Login(user);
                    TokenAPI tokenModel = loginModel.Token;
                  

                    var EsValido = false;
                    if (tokenModel != null)
                    {
                        EsValido = true;
                        HttpContext.Session.SetString("token", tokenModel.Token);

                    }

                    if (!EsValido)
                    {
                        ViewBag.Message = "Invalid Credentials";
                        return View(user);
                    }

                    var claims = new List<Claim>() {
                                     new Claim(ClaimTypes.NameIdentifier, loginModel.Username as string),
                                         new Claim(ClaimTypes.Name, loginModel.Username as string)
                    };

                    foreach (var item in loginModel.Roles)
                    {
                        claims.Add(
                              new Claim(ClaimTypes.Role, item as string)

                            );
                    }
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = user.RememberLogin
                    });
                    return LocalRedirect(user.ReturnUrl);
                }

                return View(user);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = SecurityHelper.Register(model);

                if (response.Status == "Success")
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("token"); 
            return RedirectToAction("Index", "Home");
        }
    }
}
