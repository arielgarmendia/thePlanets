using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Planets.Website.Models;

namespace Planets.Website.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        IConfiguration siteConfig;
        private readonly IApplicationUser _appUser;

        public AccountController(IConfiguration configuration, IApplicationUser appUser)
        {
            siteConfig = configuration;
            _appUser = appUser;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = null)
        {
            if (_appUser.IsSignedIn)
                return Redirect("/dashboard");
            else
            {
                ViewData["ReturnUrl"] = returnUrl;

                var pageData = new DashboardPageData()
                {
                };

                return View(pageData);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string p, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var email = Request.Form["login-form-username"];
            var password = Request.Form["login-form-password"];

            if (ModelState.IsValid)
            {
                if (email != "" && password != "")
                {
                    if (Convert.ToString(siteConfig["Login"]) == email && Convert.ToString(siteConfig["Password"]) == password)
                    {
                        var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, email) };

                        var userIdentity = new ClaimsIdentity(claims, "login");

                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(principal);

                        if (returnUrl == null)
                            return Content("<script language='javascript' type='text/javascript'>window.location = '/dashboard';</script>");
                        else
                            return Content("<script language='javascript' type='text/javascript'>window.location = '" + returnUrl + "';</script>");
                    }
                    else
                        ModelState.AddModelError("invalid", "Invalid login, please try again.");
                }
                else
                    ModelState.AddModelError("invalid", "You have empty required fields.");
            }

            var pageData = new LoginPageData()
            {
                Logout = false
            };

            return PartialView("Response", pageData);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            var pageData = new DashboardPageData()
            {
            };

            return View("Login", pageData);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
