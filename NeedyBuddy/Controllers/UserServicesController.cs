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

        public ViewResult UserServices(string area,int serviceList)
        {
            var userServicesViewModel = from p in _context.Users
                                        join q in _context.Service on p.Id equals q.User.Id
                                        join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                        where p.Pincode.Equals(area) && r.ServiceCategoryId.Equals(serviceList)
                                        select new UserServicesViewModel
                                        {
                                            Id = p.Id,
                                            FirstName = p.UserName,
                                            ContactNumber = p.PhoneNumber,
                                            Email = p.Email,
                                            City = p.City,
                                            Pincode = p.Pincode,
                                            ServiceName = r.ServiceName,
                                            Descriptions = q.Descriptions,
                                            Address = p.Address,
                                            LastName = null,
                                             ProfileImage = null,
                                              UserName = p.UserName
                                        };
            return View(userServicesViewModel.ToList());
        }


        public IActionResult ServiceDetails(string userId="1")
        {
            List<DetailsViewModel> detailsViewModels = new List<DetailsViewModel>();

            List<ServiceDetailsViewModel> serviceDetailsViewModel = new List<ServiceDetailsViewModel>();
            var detailsViewModel1 = from p in _context.Users where p.Id.Equals(userId)
                                   select new DetailsViewModel
                                   {
                            Id = p.Id,
                            FirstName = p.UserName,
                            ContactNumber = p.PhoneNumber,
                            Email = p.Email,
                            City = p.City,
                            Pincode = p.Pincode,
                            Address = p.Address,
                             serviceDetailsViewModel= new List<ServiceDetailsViewModel>()
                        };
            var detailsViewModel = detailsViewModel1.FirstOrDefault();

            var servicedetails = from p in _context.Users
                                   join q in _context.Service on p.Id equals q.User.Id
                                   join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                   where p.Id.Equals(userId)
                                   select new ServiceDetailsViewModel
                                   {
                                       ServiceName = r.ServiceName,
                                       Descriptions = q.Descriptions
                                   };

            ViewBag.ServiceDetails = servicedetails.ToList();
            //foreach (ServiceDetailsViewModel sd in servicedetails.ToList())
            //{
            //    detailsViewModel.serviceDetailsViewModel.Append(sd);
            //    //detailsViewModel.SingleOrDefault().serviceDetailsViewModel.SingleOrDefault().Descriptions = sd.Descriptions;
            //    //detailsViewModel.SingleOrDefault().serviceDetailsViewModel.SingleOrDefault().ServiceName= sd.ServiceName;
            //    //detailsViewModels.SingleOrDefault().serviceDetailsViewModel.Add(new ServiceDetailsViewModel() { Descriptions = sd.Descriptions, ServiceName = sd.ServiceName });
            //}

            return View(detailsViewModel);
        }
    }
}