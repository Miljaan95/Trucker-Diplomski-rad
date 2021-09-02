using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models.Review
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DateCreated { get; set; }

        public int DriverId { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }

    }
}
