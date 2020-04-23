using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NeedyBuddy.Data;
using NeedyBuddy.Data.Model;
using NeedyBuddy.Models;
using NeedyBuddy.Services;

namespace NeedyBuddy.Controllers
{
    public class UserServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;


        //public UserServicesController(ApplicationDbContext context, IRepository repository)

        private IConfiguration _configuration;
        public UserServicesController(ApplicationDbContext context, IRepository repository,IConfiguration configuration)

        {
            _context = context;
            _repository = repository;
            _configuration = configuration;
        }
        
        public List<ServiceCategory> servicesList = new List<ServiceCategory>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserServices(string area,string serviceList)
        {
           
           
            if (String.IsNullOrEmpty(User.Identity.Name))
            {
                return Redirect("/Identity/Account/Login");
            }
            var userServicesViewModel = from p in _context.Users
                                        join q in _context.Service on p.Id equals q.User.Id
                                        join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                        //where (p.Pincode.Equals(area) || p.City.Equals(area)) && r.ServiceCategoryId.Equals(serviceList)
                                        where p.Pincode.Equals(area) && r.ServiceCategoryId.Equals(Convert.ToInt64(serviceList))
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
                                            ServiceCategoryId = Convert.ToInt64(r.ServiceCategoryId.ToString())
                                        };           
            ViewBag.area = area;
            ViewBag.serviceList = serviceList;
            getServicesList();
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
                            Description = p.Descriptions,
                            serviceDetailsViewModel= new List<ServiceDetailsViewModel>()
                        };
            var detailsViewModel = detailsViewModel1.FirstOrDefault();
            ViewBag.loggedinUserDetails = detailsViewModel;



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


            var currentUserName = User.Identity.Name;
            var use = _context.Users.Where(c => c.UserName == currentUserName).FirstOrDefault();
            ViewBag.detailsForPopup = new AgentContactViewModel()
            {
                Name = use.FirstName,
                Email = use.Email,
                ContactNumber = use.PhoneNumber,
                AgentEmail = detailsViewModel.Email
            };

            

            return View();
        }

        public void getLoggedInUser()
        {

        }


        //public ActionResult AgentContact(string Email)
        //{
        //    var currentUserName = User.Identity.Name;
        //    var use = _context.Users.Where(c => c.UserName == currentUserName).FirstOrDefault();
        //    AgentContactViewModel agentContactViewModel = new AgentContactViewModel()
        //    {  Name = use.FirstName,
        //       Email = use.Email,
        //       ContactNumber = use.PhoneNumber,
        //       AgentEmail = Email
        //    };
        //    return PartialView(agentContactViewModel);
        //}
        [HttpPost]
        public ViewResult ServiceDetails(AgentContactViewModel agentContact)
        {

            MailTemplate objmail = new MailTemplate();
            string apiKey = _configuration.GetSection("Appsettings").GetSection("Apikey").Value;

            var test = objmail.MailSend(agentContact.Email, agentContact.AgentEmail, "Comunity Service Help", "Hi volunteer, <br/> My name is " + agentContact.Name + " and I stay near to your are. I urgently needs your help. Below are the contact information for your reference. <br/> Contact number: " + agentContact.ContactNumber + "<br/> Email Id: "  + agentContact.Email + " <br/> Request Description: " + agentContact.RequestDescription, apiKey);

            return View();
        }

            //[HttpPost]
            //public Task ContactAgent(AgentContactViewModel agentContactViewModel)
            //{
            //    SendMail objmail = new SendMail();

            string key = _configuration.GetSection("Appsettings").GetSection("Apikey").Value;
            Task response = objmail.MailSend(agentContactViewModel.AgentEmail, key);
            return response;
        }
        public void getServicesList()
        {

            servicesList = _context.ServiceCategory.ToList();
            ViewBag.servicesList = servicesList;
        }
    }
            //    string key = _configuration.GetSection("Appsettings").GetSection("Apikey").Value;
            //    Task response = objmail.MailSend(agentContactViewModel.AgentEmail, key);
            //    return response;
            //}
        }
}