using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string Pincode { get; set; }

        public UserType UserType { get; set; }

        public string Description { get; set; }

        public List<Service> Services { get; set; }
    }

    public enum UserType
    {
        Needy = 0,
        Provider = 1
    }
}
