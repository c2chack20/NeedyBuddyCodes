using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeedyBuddy.Data;
using NeedyBuddy.Data.Model;
using NeedyBuddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Net;

namespace NeedyBuddy.Controllers
{
    public class ProfileController : Controller
    {

       
      
        //test
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;


        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public ProfileController(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;

          
        }
        public async Task<IActionResult> Index()
        {


            //string currentUserName = User.Identity.Name;

            string currentUserName = "m@gmail.com";
            //string currentUserName = null;


            var regid = _context.Users.SingleOrDefault(e => e.UserName == currentUserName);
            if (regid == null)
            {
                return View();
            }

            var profileDetails = await _context.Users.Where(m => m.Id == regid.Id).FirstOrDefaultAsync();

            var servicedetails = from p in _context.Users
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
                                            Descriptions = q.Descriptions,
                                            ProfileImage=p.ProfileImage,
                                            FirstName=p.FirstName,
                                            LastName=p.LastName,
                                            Address=p.Address,
                                           
                                        };
           // return View(userServicesViewModel.ToList());

            var categories = await _repository.FindAll<ServiceCategory>();

            Custom viewModel = new Custom();
            //viewModel.profiles = profileDetails;//first table content
            viewModel.categories = categories;//second table content
            viewModel.servicedetails = servicedetails.ToList();//third table content
            return View(viewModel);
            //return View(profileDetails);

            //return View();



        }
        public async Task<IActionResult> ProfileCreate(ApplicationUser profile)
        {

            //string currentUserName = User.Identity.Name;
            //var user = _context.Users.SingleOrDefault(u => u.Id == id);


            profile.Id = "1";
            //if (id != profile.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                var newsPost = _context.Users.Find(profile.Id);
                //if (newsPost == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
                newsPost.FirstName = profile.FirstName;
                newsPost.LastName = profile.LastName;
                newsPost.City = profile.City;
                newsPost.Address = profile.Address;
                newsPost.Pincode = profile.Pincode;
                newsPost.ProfileImage = profile.ProfileImage;

                try
                {
                    _context.Entry(newsPost).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    // await _repository.UpdateAsync<UserServicesViewModel>(profile);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(profile.Id))
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
            return RedirectToAction("Index", "Profile");
        }





        //GET: Posts/Edit/5
        public async Task<IActionResult> Editme(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var profileEdit= _context.Users.Where(c => c.Id == id.ToString()).FirstOrDefault();
            //var profileEdit = await _repository.FindById<ApplicationUser>((id);
            if (profileEdit == null)
            {
                return NotFound();
            }
            return View(profileEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public async Task<IActionResult> Editme(string id,  ApplicationUser profile)
        {
          
            string currentUserName = User.Identity.Name;
            var user = _context.Users.SingleOrDefault(u => u.Id == id);


            profile.Id = "1";
            //if (id != profile.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                var newsPost = _context.Users.Find(profile.Id);
                //if (newsPost == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
                newsPost.FirstName = profile.FirstName;
                newsPost.LastName = profile.LastName;
                newsPost.City = profile.City;
                newsPost.Address = profile.Address;
                newsPost.Pincode = profile.Pincode;
                newsPost.ProfileImage = profile.ProfileImage;
                
                try
                {
                     _context.Entry(newsPost).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                   // await _repository.UpdateAsync<UserServicesViewModel>(profile);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(profile.Id))
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
            return View(profile);
        }

        private bool PostExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        //public async Task<IActionResult> ServiceDetailsCreate(int serviceList,string description,string quantity)
        //{
        //    ServiceDetailsByUsers profile = new ServiceDetailsByUsers();
        //    profile.Description = description;
        //    profile.ServiceCategoryId = serviceList;
        //    profile.Quantity = quantity;
        //    profile.ID = 1;
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(profile);
        //        await _repository.CreateAsync<ServiceDetailsByUsers>(profile);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(profile);
        //}

        public async Task<ActionResult> MyAction(string description, int serviceList)
        {
            string currentUserName = User.Identity.Name;
            var userid = _context.Users.SingleOrDefault(u => u.UserName == currentUserName);

            Service s = new Service();
            ServiceCategory sc = new ServiceCategory();
            ApplicationUser u = new ApplicationUser();
            s.Descriptions = description;
            sc.ServiceCategoryId = serviceList;
            //u.Id = "1";
            s.ServiceCategory = sc;
            //s.User = u;
           
            await _repository.CreateAsync<Service>(s);
            //_context.Entry(Service).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Posts");
            //return View();
        }
    }
}