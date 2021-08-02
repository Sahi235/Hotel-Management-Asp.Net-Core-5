using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DTO.Rooms;
using MediatR;

namespace DataAccess.MediatR.Queries.Rooms
{
    public class GetAllRooms : IRequest<List<GetAllRoomsDto>>
    {
    }
}
