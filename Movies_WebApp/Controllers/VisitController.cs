using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_WebApp.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
