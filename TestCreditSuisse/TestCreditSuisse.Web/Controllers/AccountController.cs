
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestCreditSuisse.Web.Models;

namespace TestCreditSuisse.Web.Controllers
{
    public class AccountController : Controller
    {

                
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                //var result = await _userHelper.LoginAsync(model);

                if (model.Username == "test@test.com" && model.Password == "123456")
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "User or password not valid!");
                model.Password = string.Empty;
            }
            return View(model);
        }

    }
}
