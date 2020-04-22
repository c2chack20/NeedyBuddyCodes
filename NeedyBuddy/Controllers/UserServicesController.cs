using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedyBuddy.Data;
using NeedyBuddy.Data.Model;
using NeedyBuddy.Models;

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

        public ActionResult UserServices(string area,int serviceList)
        {
            if (String.IsNullOrEmpty(User.Identity.Name))
            {
                return Redirect("/Identity/Account/Login");
            }
            var userServicesViewModel = from p in _context.Users
                                        join q in _context.Service on p.Id equals q.User.Id
                                        join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                        where (p.Pincode.Equals(area)|| p.City.Equals(area))&& r.ServiceCategoryId.Equals(serviceList)
                                        select new UserServicesViewModel
                                        {
                                            Id = p.Id,
                                            FirstName = p.FirstName,
                                            LastName = p.LastName,
                                            ContactNumber = p.PhoneNumber,
                                            Email = p.Email,
                                            City = p.City,
                                            Pincode = p.Pincode,
                                            ServiceName = r.ServiceName,
                                            Descriptions = q.Descriptions,
                                            Address = p.Address,
                                        };
            return View(userServicesViewModel.ToList());
        }

        //string userId = "c91daa76-275f-4c2e-9b58-f1e266ceedf7"
        public IActionResult ServiceDetails(string usermodel)
        {
            List<DetailsViewModel> detailsViewModels = new List<DetailsViewModel>();

            List<ServiceDetailsViewModel> serviceDetailsViewModel = new List<ServiceDetailsViewModel>();
            var detailsViewModel1 = from p in _context.Users where p.Id.Equals(usermodel)
                                   select new DetailsViewModel
                                   {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            ContactNumber = p.PhoneNumber,
                            Email = p.Email,
                            City = p.City,
                            Pincode = p.Pincode,
                            Address = p.Address,
                            Description = p.Description,
                            serviceDetailsViewModel= new List<ServiceDetailsViewModel>()
                        };
            var detailsViewModel = detailsViewModel1.FirstOrDefault();

            var servicedetails = from p in _context.Users
                                   join q in _context.Service on p.Id equals q.User.Id
                                   join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                   where p.Id.Equals(usermodel)
                                   select new ServiceDetailsViewModel
                                   {
                                       ServiceName = r.ServiceName,
                                       Descriptions = q.Descriptions

                                   };

            ViewBag.ServiceDetails = servicedetails.ToList();

            return View(detailsViewModel);
        }

        public ActionResult AgentContact(string Email)
        {
            var currentUserName = User.Identity.Name;
            var use = _context.Users.Where(c => c.UserName == currentUserName).FirstOrDefault();
            AgentContactViewModel agentContactViewModel = new AgentContactViewModel()
            {  Name = use.FirstName,
               Email = use.Email,
               ContactNumber = use.PhoneNumber,
               AgentEmail = Email
            };
            return PartialView(agentContactViewModel);
        }
        //public ViewResult ContactAgent()
        //{

        //    return view();
        //}
    }
}