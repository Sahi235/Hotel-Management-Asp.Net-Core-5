using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.RoomTypes.Dto;
using Infrastructure.RoomTypes.Repository;
using Infrastructure.RoomTypes.RequestQuery;
using MediatR;

namespace Infrastructure.RoomTypes.QueryHandler
{
    public class RoomTypesQueryHandler : IRequestHandler<GetRoomTypeQuery, List<GetRoomTypeDto>>
    {
        private readonly IRoomTypesRepository _repository;
        private readonly IMapper _mapper;

        public RoomTypesQueryHandler(IRoomTypesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetRoomTypeDto>> Handle(GetRoomTypeQuery request, CancellationToken cancellationToken)
        {
            var roomTypes = await _repository.GetAll();
            return _mapper.Map<List<GetRoomTypeDto>>(roomTypes);
        }
    }
}
