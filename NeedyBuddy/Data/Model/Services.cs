using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Data.Model
{
    public class Services
    {
        public long Id { get; set; }

        public ServiceCategory Service { get; set; }

        public string Descriptions { get; set; }

        public ApplicationUser User { get; set; }

    }
}
