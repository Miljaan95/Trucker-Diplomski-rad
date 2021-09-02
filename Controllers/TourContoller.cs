using AppDemo.Models.Tour;
using AppDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppDemo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TourContoller : ControllerBase
    {
        public ITourService _tourService { get; set; }

        public TourContoller(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet("getTours")]
        public IActionResult GetTours()
        {
            var tours = _tourService.GetTours();
            return Ok(new { tours });
        }

        [HttpPost("createTour")]
        public IActionResult CreateTour([FromBody] TourModel model)
        {
            int id = _tourService.CreateTour(model);
            return Ok(new { id });
        }


        [HttpPost("updateTour")]
        public IActionResult UpdateTour([FromBody] TourModel model)
        {
            var response = _tourService.UpdateTour(model);
            return Ok(response);

        }

        [HttpDelete("deleteTour/{Id}")]
        public IActionResult DeleteTour(int Id)
        {
            var tour = _tourService.DeleteTour(Id);
            if (tour == true)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("assignDriver")]
        public IActionResult AssignDriver([FromBody] TourModel model)
        {
            var result = _tourService.AssignDriver(model);
            if (result)
                return Ok(result);
            else
                return StatusCode(408);
        }

        [HttpPut("assignLoad")]
        public IActionResult AssignLoad([FromBody] TourModel model)
        {
            var result = _tourService.AssignLoad(model);
            if (result)
                return Ok(result);
            else
                return StatusCode(408);
        }
    }
}