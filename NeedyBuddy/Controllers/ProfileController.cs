using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedyBuddy.Models;
using NeedyBuddy.Data.Model;
using NeedyBuddy.Data;
using Microsoft.EntityFrameworkCore;

namespace NeedyBuddy.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;


        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public ProfileController(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;


        }
        //public UserServicesViewModel loggedinUser = new UserServicesViewModel { Id = "1", UserName = "Chandan K", Email = "cksenapati05@gmail.com", ContactNumber = "8763717165", City = "Gachibowli", Descriptions = "S/W Developer", Pincode = "500032", ServiceName = "Medicine" };
        public List<ServiceCategory> servicesList = new List<ServiceCategory>();
        public List<ServiceCategory> selectedServicesList = new List<ServiceCategory>();
        public List<ServiceCategory> nonSelectedServicesList = new List<ServiceCategory>();
        public UserServicesViewModel loggedinUser = new UserServicesViewModel();



        public IActionResult Index()
        {

            getServicesList();
            getProfileDetails();
            ViewBag.servicesList = servicesList;
            ViewBag.selectedServicesList = selectedServicesList;
            ViewBag.nonSelectedServicesList = nonSelectedServicesList;
            ViewBag.loggedinUser = loggedinUser;


            ViewBag.loggedinUser = loggedinUser;
            return View();
        }
public void getProfileDetails()
        {
            var currentUserName = User.Identity.Name;
            var use = _context.Users.Where(c => c.UserName == currentUserName).FirstOrDefault();

            var servicedetails = from p in _context.Users
                                     //join q in _context.Service on p.Id equals q.User.Id
                                     //join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId

                                 //join q in _context.Service on p.Id equals q.User.Id
                                 //join r in _context.ServiceCategory on q.ServiceCategory.ServiceCategoryId equals r.ServiceCategoryId
                                 //where p.UserName.Equals(currentUserName)
                                 where p.UserName.Equals(currentUserName) 
                                 select new UserServicesViewModel
                                 {
                                     Id = p.Id,
                                     UserName = p.UserName,
                                     ContactNumber = p.PhoneNumber,
                                     Email = p.Email,
                                     City = p.City,
                                     Pincode = p.Pincode,
                                     //ServiceName = r.ServiceName,
                                     //Descriptions = q.Descriptions,
                                     ProfileImage = p.ProfileImage,
                                     FirstName = p.FirstName,
                                     LastName = p.LastName,
                                     Address = p.Address,
                                     //ServiceId = q.ServiceId

                                 };

            loggedinUser.UserName = servicedetails.FirstOrDefault().UserName;
            loggedinUser.Email = servicedetails.FirstOrDefault().Email;
            loggedinUser.ContactNumber = servicedetails.FirstOrDefault().ContactNumber;
            loggedinUser.City = servicedetails.FirstOrDefault().City;
            loggedinUser.Pincode = servicedetails.FirstOrDefault().Pincode ;
            loggedinUser.FirstName = servicedetails.FirstOrDefault().FirstName;
            loggedinUser.LastName = servicedetails.FirstOrDefault().LastName;
            loggedinUser.Address = servicedetails.FirstOrDefault().Address;
            loggedinUser.Descriptions = "helper";
            loggedinUser.ServiceName = "Food";

        } 
        public void getServicesList()
        {
            
                servicesList = _context.ServiceCategory.ToList();
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 1, ServiceName = "Test" });
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 2, ServiceName = "Food" });
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 3, ServiceName = "Medicine" });
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 4, ServiceName = "Grocessary" });
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 5, ServiceName = "Doctor" });
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 6, ServiceName = "Physical Help" });
            //servicesList.Add(new ServiceCategory() { ServiceCategoryId = 7, ServiceName = "Transportation" });

            //selectedServicesList.Add(new ServiceCategory() { ServiceCategoryId = 3, ServiceName = "Medicine" });

            foreach (ServiceCategory eachService in servicesList)
            {
                if (!selectedServicesList.Exists(x => x.ServiceCategoryId == eachService.ServiceCategoryId))
                {
                    nonSelectedServicesList.Add(eachService);
                }
                
            }
        }
        public async Task<IActionResult> Save(string FirstName,string LastName,string Email,string ContactNumber,string City,string Pincode,string Address)
        {

            string currentUserName = User.Identity.Name;
            var user = _context.Users.SingleOrDefault(u => u.UserName == currentUserName);

            if (ModelState.IsValid)
            {
                var newsPost = _context.Users.Find(user.Id);
                //if (newsPost == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
                newsPost.FirstName = FirstName;
                newsPost.LastName = LastName;
                newsPost.City = City;
                newsPost.Pincode = Pincode;
                newsPost.Address = Address;

                try
                {
                    _context.Entry(newsPost).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    // await _repository.UpdateAsync<UserServicesViewModel>(profile);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(loggedinUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(loggedinUser);
        }
        private bool PostExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        public async Task<ActionResult> AddServices(string description, long services)
        {
            string currentUserName = User.Identity.Name;
            var userid = _context.Users.SingleOrDefault(u => u.UserName == currentUserName);

            Service s = new Service();
            //ServiceCategory sc = new ServiceCategory();
            //ApplicationUser u = new ApplicationUser();
            s.Descriptions = description;
            
            s.ServiceCategory.ServiceCategoryId = services;
            //u.Id = "1";
            //s.ServiceCategory = sc;
            //s.User = u;

            await _repository.CreateAsync<Service>(s);
            //_context.Entry(Service).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Profile");
            //return View();
        }
    }
}