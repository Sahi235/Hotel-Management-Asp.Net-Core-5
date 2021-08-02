using DataAccess.Hotels.Dto;
using MediatR;

namespace DataAccess.Hotels.Command
{
    public class CreateHotelCommand : IRequest<GetHotelDto>
    {
        public CreateHotelDto CreateHotelDto { get; set; }

        public CreateHotelCommand(CreateHotelDto createHotelDto)
        {
            CreateHotelDto = createHotelDto;
        }
    }
}
