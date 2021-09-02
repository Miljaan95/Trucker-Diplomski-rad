using AppDemo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models.Tour
{
    public class TourModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Price { get; set; }
        public decimal? Distance { get; set; }
        public DateTime? DateCreated { get; set; }
        public TourType Type { get; set; }

        public int UserId { get; set; }
        public int? LoadId { get; set; }
        public int? DriverId { get; set; }
    }
}
