using NeedyBuddy.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Models
{
    public class Custom
    {
        //public Profile profiles { get; set; }

        public List<ServiceCategory> categories { get; set; }
        public List<UserServicesViewModel> servicedetails { get; set; }
    }
}
