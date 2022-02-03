using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies_WebApp.Models;
using Movies_WebApp.Services.Interfaces;

namespace Movies_WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Check the Database to find a user that matches this username and password
                User _currentUser = await _userService.GetUserAsync(model);

                if (_currentUser != null)
                {

                    if (_currentUser.txt_desc == "Administrador")
                    {
                        return RedirectToAction("IndexAsync", "Admin");

                    }
                    else if (_currentUser.txt_desc == "Cliente")
                    {
                        return RedirectToAction("Index", "Visit");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError("", "El usuario o contraseña ingresados son incorrectos.");
            }

            return View(model);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
