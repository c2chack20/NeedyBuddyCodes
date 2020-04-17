using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NeedyBuddy.Controllers
{
    public class UserServicesController : Controller
    {
        public IActionResult UserServices()
        {
            return View();
        }

        public IActionResult ServiceDetails()
        {
            return View();
        }
    }
}