using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Hotels.Command;
using DataAccess.Hotels.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        [HttpPost]
        [Route("api/[Controller]/[Action]")]
        public IActionResult CreateHotel([FromForm] CreateHotelDto dto)
        {
            var command = new CreateHotelCommand(dto);
            return Ok(command);
        }
    }
}
