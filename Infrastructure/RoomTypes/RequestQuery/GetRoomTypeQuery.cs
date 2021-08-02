using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.RoomTypes.Dto;
using MediatR;

namespace Infrastructure.RoomTypes.RequestQuery
{
    public class GetRoomTypeQuery : IRequest<List<GetRoomTypeDto>>, IRequest<List<GetRoomTypeQuery>>
    {
    }
}
