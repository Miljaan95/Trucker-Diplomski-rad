using AppDemo.Models.Driver;
using AppDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        public IDriverService _driverService { get; set; }

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("updateProfile")]
        public IActionResult UpdateProfile([FromBody] DriverModel model)
        {
            var response = _driverService.UpdateDriverProfile(model);

            return Ok(response);
        }
    }
}
