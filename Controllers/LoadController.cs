using AppDemo.Models.Load;
using AppDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LoadController : ControllerBase
    {
        private ILoadService _loadService { get; set; }

        public LoadController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        [HttpPost("createLoad")]
        public IActionResult CreateLoad([FromBody] LoadModel model)
        {
            var res = _loadService.CreateLoad(model);
            return new JsonResult(res);
        }

        [HttpGet("getLoads")]
        public IActionResult GetLoads()
        {
            var loads = _loadService.GetLoads();
            return Ok(new { loads });
        }


        [HttpPost("updateLoad")]
        public IActionResult UpdateLoad([FromBody] LoadModel model)
        {
            var response = _loadService.UpdateLoad(model);
            return Ok(response);

        }

        [HttpDelete("deleteLoad/{Id}")]
        public IActionResult DeleteLoad(int Id)
        {
            var load = _loadService.DeleteLoad(Id);
            if (load == true)
                return Ok();
            else
                return NotFound();
        }

    }
}
