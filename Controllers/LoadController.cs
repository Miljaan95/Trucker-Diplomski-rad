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
    }
}
