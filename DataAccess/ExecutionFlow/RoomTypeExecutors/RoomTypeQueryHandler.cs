using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.DTO.RoomTypes;
using MediatR;

namespace DataAccess.ExecutionFlow.RoomTypeExecutors
{
    public class RoomTypeQueryHandler : IRequestHandler<RoomTypeQuery ,List<GetRoomTypes>>
    {
        private readonly IExecutors _executors;

        public RoomTypeQueryHandler(IExecutors executors)
        {
            _executors = new RoomTypesExecutors();
        }
        public Task<List<GetRoomTypes>> Handle(RoomTypeQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
