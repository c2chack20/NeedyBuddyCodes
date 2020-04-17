using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Data.Model
{
    public class ServiceCategory
    {
        public long ServiceCategoryId { get; set; }

        public string ServiceName { get; set; }

        public List<Services> Services { get; set; }

    }
}
