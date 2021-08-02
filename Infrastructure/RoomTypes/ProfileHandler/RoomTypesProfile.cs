using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain;
using Infrastructure.RoomTypes.Dto;

namespace Infrastructure.RoomTypes.ProfileHandler
{
    public class RoomTypesProfile : Profile
    {
        public RoomTypesProfile()
        {
            CreateMap<List<GetRoomTypeDto>, List<RoomType>>().ReverseMap();
        }
    }
}
