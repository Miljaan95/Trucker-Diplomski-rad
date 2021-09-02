using AppDemo.Data;
using AppDemo.Data.Domain;
using AppDemo.Helpers;
using AppDemo.Models.Driver;
using AppDemo.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public class DriverService : IDriverService
    {
        private DemoDbContext _context;
        private IRepository<DriverProfile> _driverRepo;
        private readonly AppSettings _appSettings;

        public DriverService(
            DemoDbContext context,
            IOptions<AppSettings> appSettings,
            IRepository<DriverProfile> driverRepo)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _driverRepo = driverRepo;
        }

        public bool UpdateDriverProfile(DriverModel model)
        {
            try
            { 
            _context.DriverProfile.Where(x => x.UserId == model.UserId).FirstOrDefault();
                //var driver = _context.DriverProfile.Where(x => x.UserId == model.UserId).FirstOrDefault();
                var driver = _driverRepo.GetAll().Where(x => x.UserId == model.UserId).FirstOrDefault();

                driver.CompanyName = model.CompanyName;
                driver.Country = model.Country;
                driver.DrivingExperience = model.DrivingExperience;
                driver.DrivingLicenceFrom = model.DrivingLicenceFrom;

                _context.DriverProfile.Update(driver);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
