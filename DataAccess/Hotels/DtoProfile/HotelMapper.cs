using AutoMapper;
using DataAccess.Hotels.Dto;
using Domain;

namespace DataAccess.Hotels.DtoProfile
{
    public class HotelMapper : Profile
    {
        public HotelMapper()
        {
            CreateMap<Hotel, GetHotelDto>().ReverseMap();
            CreateMap<CreateHotelDto, Hotel>().ReverseMap();
        }
    }
}
