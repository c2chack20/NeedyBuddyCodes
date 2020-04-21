using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedyBuddy.Data;
using NeedyBuddy.Data.Model;

namespace NeedyBuddy.Controllers
{
    public class UserServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;
        public UserServicesController(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }


        public IActionResult Index()
        {
            return View();
        }

        //string area, string serviceName
        public ViewResult UserServices()
        {
            var userServicesViewModel = from p in _context.Users
                                        join q in _context.Service on p.Id equals q.User.Id
                                        join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                        //where p.Pincode.Equals(area) && r.ServiceName.Equals(serviceName)
                                        select new UserServicesViewModel
                                        {
                                            Id = p.Id,
                                            UserName = p.UserName,
                                            ContactNumber = p.PhoneNumber,
                                            Email = p.Email,
                                            City = p.City,
                                            Pincode = p.Pincode,
                                            ServiceName = r.ServiceName,
                                            Descriptions = q.Descriptions
                                        };
            return View(userServicesViewModel.ToList());
        }

        public IActionResult ServiceDetails(UserServicesViewModel contact)
        {

            return View();
        }
    }
}