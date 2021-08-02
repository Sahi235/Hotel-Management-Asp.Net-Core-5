using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using DataAccess.Hotels.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]/")]
    public class HotelsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public HotelsController(DatabaseContext context,
                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GetHotelDto>>(hotels));
        }



        [Route("{id?}")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(e => e.Id == id);

            if (hotel != null)
            {
                return Ok(_mapper.Map<GetHotelDto>(hotel));
            }

            return NotFound(new {message = "The hotel that you are looking for was not found"});
        }
    }
}
