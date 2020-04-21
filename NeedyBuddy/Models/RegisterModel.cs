using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NeedyBuddy.Models
{
    public class RegisterModel
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }

        //public string City { get; set; }
        //public string Area { get; set; }
        //public string Pincode { get; set; }

        //public string CreatedOn { get; set; }
        //public string ModfiedOn { get; set; }

    }
}
