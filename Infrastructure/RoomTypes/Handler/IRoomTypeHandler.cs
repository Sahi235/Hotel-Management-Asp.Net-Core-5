using System;
using System.Collections.Generic;
using Domain;
using Infrastructure.AbstractResults;
using Infrastructure.RoomTypes.Dto;

namespace Infrastructure.RoomTypes.Handler
{
    public interface IRoomTypeHandler
    {
        IRequestResult<GetRoomTypeDto> GetRoomType(Guid id);
        IRequestResult<List<GetRoomTypeDto>> GetAllRoomTypes();
    }
}
