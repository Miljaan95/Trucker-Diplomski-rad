using AppDemo.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public interface IDriverService
    {
        bool UpdateDriverProfile(DriverModel model);
    }
}
