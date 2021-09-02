using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models.Driver
{
    public class DriverModel
    {
        public int UserId { get; set; }
        public int DrivingExperience { get; set; }
        public string Country { get; set; }
        public DateTime DrivingLicenceFrom { get; set; }
        public string CompanyName { get; set; }
    }
}
