using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using DataAccess.DTO.Rooms;
using DataAccess.MediatR.Queries.Rooms;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MediatR.Handlers.Rooms
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRooms, List<GetAllRoomsDto>>
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public GetAllRoomsHandler(IMapper mapper, DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetAllRoomsDto>> Handle(GetAllRooms request, CancellationToken cancellationToken)
        {
            var test = _context.Hotels.Where(Hotel.Expression);
            var rooms = await _context.Rooms.ToListAsync(cancellationToken);
            return _mapper.Map<List<GetAllRoomsDto>>(rooms);
        }
    }
}
