using AppDemo.Models.Review;
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
    public class ReviewController : ControllerBase
    {
        public IReviewService _reviewService { get; set; }

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("createReview")]
        public IActionResult CreateTour([FromBody] ReviewModel model)
        {
            int id = _reviewService.CreateReview(model);
            return Ok(new { id });
        }


        [HttpPost("updateReview")]
        public IActionResult UpdateReview([FromBody] ReviewModel model)
        {
            var response = _reviewService.UpdateReview(model);
            return Ok(response);

        }

        [HttpDelete("deleteReview/{Id}")]
        public IActionResult DeleteReview(int Id)
        {
            var tour = _reviewService.DeleteReview(Id);
            if (tour == true)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("GetRateAverage/{userId}")]
        public IActionResult GetRateAverage(int userId)
        {
            var response = _reviewService.GetAverageRate(userId);
            if (response != null )
                return Ok(response);
            else
                return NotFound();
        }

    }
}
