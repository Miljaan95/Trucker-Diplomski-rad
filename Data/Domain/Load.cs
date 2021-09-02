using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.Repositories;

namespace AppDemo.Data.Domain
{
    public class Load : BaseEntity
    {
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
    }
}
