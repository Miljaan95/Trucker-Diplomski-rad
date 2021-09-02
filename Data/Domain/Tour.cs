using AppDemo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.Repositories;

namespace AppDemo.Data.Domain
{
    public class Tour : BaseEntity
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal? Price { get; set; }
        public decimal? Distance { get; set; }
        public DateTime? DateCreated { get; set; }
        public TourType TypeTour { get; set; }

        public int? DriverProfileId { get; set; }
        public virtual DriverProfile Driver { get; set; }

        public int? LoadId { get; set; }
        public virtual Load Load { get; set; }

        public int UserId { get; set; }
        public virtual User Tenant { get; set; }
    }
}
