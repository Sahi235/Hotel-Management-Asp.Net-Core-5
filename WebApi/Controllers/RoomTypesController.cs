using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.CustomMapper;
using DataAccess.Database;
using DataAccess.DTO.RoomTypes;
using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;
using WebApi.ModelBinders;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]/")]
    public class RoomTypesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public RoomTypesController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetPaginatedRoomTypes(int pageNumber , int pageSize)
        {
            var roomTypes = await _context.RoomTypes.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync();
            var model = _mapper.Map<IEnumerable<GetRoomTypes>>(roomTypes);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomType()
        {
            var config = new MapperConfiguration(e => e.CreateMap<GetRoomTypes, RoomType>().ReverseMap());

            var roomTypes = await _context.RoomTypes.ProjectTo<GetRoomTypes>(config).ToListAsync();
            //var roomTypes = _context.RoomTypes;
            if (roomTypes == null)
            {
                return NotFound(new {Message = "There is no room type at the moment"});
            }
            return Ok(_mapper.Map<IEnumerable<GetRoomTypes>>(roomTypes));
        }

        [HttpGet("({ids})")]
        public async Task<IActionResult> GetRoomTypes([ModelBinder(binderType:typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest("Please enter id");
            }

            var roomTypes = await _context.RoomTypes.Where(rt => ids.Contains(rt.Id)).ToListAsync();

            if (roomTypes.Count != ids.Count())
            {
                return BadRequest("Invalid id");
            }

            var model = _mapper.Map<IEnumerable<GetRoomTypes>>(roomTypes);
            return Ok(model);
        }

        [Route("{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetRoomType(Guid id)
        {
            var roomType = await _context.RoomTypes.FirstOrDefaultAsync(e => e.Id == id);
            if (roomType == null)
            {
                return NotFound(new {Message = "Room type with that id was not found"});
            }


            return Ok(_mapper.Map<GetRoomTypes>(roomType));
        }

        [NullReferencesCheck] 
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomType roomType)
        {
            if (string.IsNullOrWhiteSpace(roomType.TypeName))
            {
                return StatusCode(500, new{Message = "Room type can not be empty."});
            }

            var newRoomType = _mapper.Map<RoomType>(roomType);
            await _context.RoomTypes.AddAsync(newRoomType);
            await _context.SaveChangesAsync();

            var model = _mapper.Map<GetRoomTypes>(newRoomType);
            return CreatedAtRoute(nameof(GetRoomType), new {id = model.Id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateInBulk([FromBody]IEnumerable<CreateRoomType> roomTypes)
        {
            if (roomTypes == null)
            {
                return BadRequest("Values can not be empty");
            }

            var roomTypesEntities = _mapper.Map<IEnumerable<RoomType>>(roomTypes);
            if (roomTypesEntities == null)
            {
                return BadRequest("Invalid entries");
            }

            await _context.RoomTypes.AddRangeAsync(roomTypesEntities);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                return StatusCode(500, new {Message = "Internal Error"});
            }

            var roomTypesToReturn = _mapper.Map<IEnumerable<GetRoomTypes>>(roomTypesEntities);
            var ids = string.Join(',', roomTypesToReturn.Select(e => e.Id));


            return CreatedAtRoute("GetRoomTypes", new { ids });

        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var roomType = await _context.RoomTypes.FirstOrDefaultAsync(e => e.Id == id);
            if (roomType == null)
            {
                return NotFound(new {Message = "Room type that you are looking for was not found"});
            }

            _context.RoomTypes.Remove(roomType);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                return StatusCode(500, new{Message = "Something went wrong"});
            }

            return Ok(new {Message = $"The room type with id : {id} was deleted"});

        }


        [HttpPut("{id?}")]
        public async Task<IActionResult> Update(Guid id, UpdateRoomType roomTypeModel)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _mapper.Map(roomTypeModel, roomType);
            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPatch("{id?}")]
        public async Task<IActionResult> PatchRoomType(Guid id, JsonPatchDocument<UpdateRoomType> patchDocument)
        {
            var roomType = await _context.RoomTypes.FirstOrDefaultAsync(e => e.Id == id);
            if (roomType == null)
            {
                return NotFound();
            }

            var roomPatched = _mapper.Map<UpdateRoomType>(roomType);

            patchDocument.ApplyTo(roomPatched, ModelState);

            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(roomPatched, roomType);

            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();
            return NoContent();

        }


        [HttpGet]
        public IActionResult GetUserAgentDetails()
        {
            //var userAgentDetails = Request.Headers["User-Agent"].ToString();
            //var requestProvider = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            //var culture = requestProvider.RequestCulture.Culture;
            var firstOrDefault = _context.RoomTypes.FirstOrDefault();
            //Sapper<firstOrDefault, Room> roSapper = new Sapper<firstOrDefault, Room>();
            //roSapper.GetOut();

            Console.WriteLine("finished");

            return Ok();
        }

    }
}
