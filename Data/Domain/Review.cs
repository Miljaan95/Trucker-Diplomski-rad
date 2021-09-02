using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.Repositories;

namespace AppDemo.Data.Domain
{
    public class Review : BaseEntity
    {
        public string Comment { get; set; }
        public decimal Rate { get; set; }
        public DateTime? DateCreated { get; set; }

        public int DriverProfileId { get; set; }
        public virtual DriverProfile Driver { get; set; }

        public int UserId { get; set; }
        public virtual User Reviewer { get; set; }

        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
