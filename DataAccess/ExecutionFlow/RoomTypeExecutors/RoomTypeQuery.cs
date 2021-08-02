using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DTO.RoomTypes;
using MediatR;

namespace DataAccess.ExecutionFlow.RoomTypeExecutors
{
    public class RoomTypeQuery : IRequest<List<GetRoomTypes>>
    {
    }
}
