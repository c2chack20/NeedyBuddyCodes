using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedyBuddy.Models;
using NeedyBuddy.Data.Model;
using NeedyBuddy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NeedyBuddy.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;

        public ProfileController(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public List<ServiceCategory> servicesList = new List<ServiceCategory>();
        public List<ServiceCategory> selectedServicesList = new List<ServiceCategory>();
        public List<ServiceCategory> nonSelectedServicesList = new List<ServiceCategory>();
        public UserServicesViewModel loggedinUser = new UserServicesViewModel();


        public IActionResult Index()
        {
            getProfileDetails();

            getServicesList();
            ViewBag.servicesList = servicesList;
            ViewBag.selectedServicesList = selectedServicesList;
            ViewBag.nonSelectedServicesList = nonSelectedServicesList;
            ViewBag.loggedinUser = loggedinUser;

            ViewBag.Message = "Successful";

            return View();
        }
        [HttpPost]
        public void getProfileDetails()
        {
            var currentUserName = User.Identity.Name;
            var use = _context.Users.Where(c => c.UserName == currentUserName).FirstOrDefault();

            var servicedetails = from p in _context.Users

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
                                     Descriptions = p.Descriptions,
                                     ProfileImage = p.ProfileImage,
                                     FirstName = p.FirstName,
                                     LastName = p.LastName,
                                     Address = p.Address,
                                     //ServiceId = q.ServiceId

                                 };

            loggedinUser.Id = servicedetails.FirstOrDefault().Id;
            loggedinUser.UserName = servicedetails.FirstOrDefault().UserName;
            loggedinUser.Email = servicedetails.FirstOrDefault().Email;
            loggedinUser.ContactNumber = servicedetails.FirstOrDefault().ContactNumber;
            loggedinUser.City = servicedetails.FirstOrDefault().City;
            loggedinUser.Pincode = servicedetails.FirstOrDefault().Pincode;
            loggedinUser.FirstName = servicedetails.FirstOrDefault().FirstName;
            loggedinUser.LastName = servicedetails.FirstOrDefault().LastName;
            loggedinUser.Address = servicedetails.FirstOrDefault().Address;
            loggedinUser.ProfileImage = servicedetails.FirstOrDefault().ProfileImage;
            loggedinUser.Descriptions = servicedetails.FirstOrDefault().Descriptions;
            loggedinUser.UserType = servicedetails.FirstOrDefault().UserType;
            if (loggedinUser.UserType == "1")
            {
                loggedinUser.UserTypeName = "Provider";
            }
            else
            {
                loggedinUser.UserTypeName = "Needy";
            }


            var serviceProvides = from p in _context.Service
                                  join q in _context.ServiceCategory on p.ServiceCategory.ServiceCategoryId equals q.ServiceCategoryId
                                  where p.User.Id.Equals(loggedinUser.Id)
                                  select new UserServicesViewModel
                                  {
                                      ServiceCategoryId = p.ServiceCategory.ServiceCategoryId,
                                      ServiceName = p.ServiceCategory.ServiceName
                                  };

            foreach (var eachSelectedService in serviceProvides)
            {
                selectedServicesList.Add(new ServiceCategory { ServiceCategoryId = eachSelectedService.ServiceCategoryId, ServiceName = eachSelectedService.ServiceName });
            }

            ViewBag.Foto = @servicedetails.FirstOrDefault().ProfileImage;
        }
        public void getServicesList()
        {
            servicesList = _context.ServiceCategory.ToList();

            foreach (ServiceCategory eachService in servicesList)
            {
                if (!selectedServicesList.Exists(x => x.ServiceCategoryId == eachService.ServiceCategoryId))
                {
                    nonSelectedServicesList.Add(eachService);
                }
            }
        }
        public async Task<IActionResult> Save(string FirstName, string LastName,
            string Email, string ContactNumber, string City, string Pincode, string Address, string ProfileImage, string Descriptions)
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
                newsPost.ProfileImage = ProfileImage;
                newsPost.Descriptions = Descriptions;
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
        public async Task<ActionResult> AddServices(string description, string selectedvalue)
        {

            return RedirectToAction("Index", "Home");
            //return View();
        }

        public async Task<IActionResult> SaveServices(string selectedServiceIds)
        {
            string currentUserName = User.Identity.Name;
            var user = _context.Users.SingleOrDefault(u => u.UserName == currentUserName);

            selectedServiceIds = selectedServiceIds.Remove(selectedServiceIds.Length - 1, 1);
            string[] selectedIds = selectedServiceIds.Split(',');

            if (ModelState.IsValid)
            {
                try
                {
                    getProfileDetails();
                    foreach (string eachId in selectedIds)
                    {
                        if (!selectedServicesList.Exists(x => x.ServiceCategoryId == Int32.Parse(eachId)))
                        {
                            ServiceCategory selectedServiceCategory = _context.ServiceCategory.SingleOrDefault(u => u.ServiceCategoryId == Int32.Parse(eachId));
                            _context.Entry(new Service { ServiceCategory = selectedServiceCategory, Descriptions = "All", User = user }).State = EntityState.Added;
                            await _context.SaveChangesAsync();
                        }

                    }

                    //Delete old selected services(Currently not working -- Need fix)
                    foreach (ServiceCategory oldSelectedCat in selectedServicesList)
                    {
                        int i = 0;
                        for (; i < selectedIds.Length; i++)
                        {
                            if (oldSelectedCat.ServiceCategoryId == Int32.Parse(selectedIds[i]))
                                break;
                        }
                        if (i == selectedIds.Length)
                        {
                            ServiceCategory selectedServiceCategory = _context.ServiceCategory.SingleOrDefault(u => u.ServiceCategoryId == oldSelectedCat.ServiceCategoryId);
                            _context.Service.Remove(new Service { ServiceCategory = selectedServiceCategory, User = user });
                            await _context.SaveChangesAsync();
                        }
                    }

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

    }
}