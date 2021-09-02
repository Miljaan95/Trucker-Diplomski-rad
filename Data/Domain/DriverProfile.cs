using AppDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Data.Domain
{
    public class DriverProfile : BaseEntity
    {
        public int? DrivingExperience { get; set; }
        public string Country { get; set; }
        public DateTime? DrivingLicenceFrom { get; set; }
        public string CompanyName { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
