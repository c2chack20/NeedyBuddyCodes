using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeedyBuddy.Models;

namespace NeedyBuddy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ServiceCategory> servicesList = new List<ServiceCategory>();
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Test" });
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Food" });
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Medicine" });
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Grocessary" });
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Doctor" });
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Physical Help" });
            servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Transportation" });

            ViewBag.servicesList = servicesList;

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
