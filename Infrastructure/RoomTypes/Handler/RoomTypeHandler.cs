using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.AbstractResults;
using Infrastructure.RoomTypes.Dto;
using Infrastructure.RoomTypes.Repository;

namespace Infrastructure.RoomTypes.Handler
{
    public class RoomTypeHandler : IRoomTypeHandler
    {
        private readonly IRoomTypesRepository _repository;

        public RoomTypeHandler(IRoomTypesRepository repository)
        {
            _repository = repository;
        }
        public IRequestResult<GetRoomTypeDto> GetRoomType(Guid id)
        {
            return null;
        }

        public IRequestResult<List<GetRoomTypeDto>> GetAllRoomTypes()
        {
            return null;
        }
    }
}
