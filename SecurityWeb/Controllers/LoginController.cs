using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SecurityWeb.Models;
using SecurityWeb.Services;

namespace SecurityWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service) => _service = service;

        public IActionResult Index()
        {
            if (User.Identity.Name != null)
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }       

        [HttpPost]
        public IActionResult Login(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var login = _service.Login(model);

                if (login != null)
                {                    
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, login.UserId.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, login.Name));
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal/*, new AuthenticationProperties { IsPersistent = model.RememberMe }*/);

                    return Redirect("~/Home/Index");
                }

            }

            return View("Index", model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("~/Login");
        }
    }
}