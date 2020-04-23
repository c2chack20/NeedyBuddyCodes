using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NeedyBuddy.Models
{
    public class Service
    {
        public long ServiceId { get; set; }

        [ForeignKey("ServiceCategoryId")]
        public ServiceCategory ServiceCategory { get; set; }
        public long ServiceCategoryId { get; set; }

        public string Descriptions { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        
        public string UserId { get; set; }

    }
}
