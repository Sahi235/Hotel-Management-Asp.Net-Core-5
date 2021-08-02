using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccess.DTO.Rooms;
using DataAccess.DTO.RoomTypes;
using DataAccess.MediatR.Queries.Rooms;
using Domain;

namespace DataAccess.Profiles
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<GetAllRoomsDto, Room>().ReverseMap();
        }
    }
}
