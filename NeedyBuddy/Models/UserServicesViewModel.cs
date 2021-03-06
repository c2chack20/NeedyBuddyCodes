﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Data.Model
{
    public class UserServicesViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Pincode { get; set; }

        public string Descriptions { get; set; }

        public string ServiceName { get; set; }

        public long ServiceCategoryId { get; set; }

        public int ServiceId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }

        public string Address { get; set; }
        public string UserType { get; set; }

        public string UserTypeName { get; set; }
    }
}
