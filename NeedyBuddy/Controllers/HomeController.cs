using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeedyBuddy.Data;
using NeedyBuddy.Data.Model;
using NeedyBuddy.Models;

namespace NeedyBuddy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _repository.FindAll<ServiceCategory>();
            return View(categories);
        }
        [HttpPost]
        public ActionResult MyAction(string searchtext, string listbox)
        {
            return RedirectToAction("Index", "Posts");
            //return View();
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
