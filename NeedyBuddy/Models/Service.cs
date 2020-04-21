using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Models
{
    public class Service
    {
        public long ServiceId { get; set; }

        //public ServiceCategory ServiceCategory { get; set; }

        public long ServiceCategoryId { get; set; }

        public string Descriptions { get; set; }

        public string UserId { get; set; }

        // public ApplicationUser User { get; set; }

    }
}
