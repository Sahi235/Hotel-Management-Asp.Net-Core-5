using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccess.DTO.RoomTypes;
using Domain;

namespace DataAccess.Profiles
{
    public class RoomTypesProfile :Profile
    {
        public RoomTypesProfile()
        {
            CreateMap<RoomType, GetRoomTypes>();
            CreateMap<CreateRoomType, RoomType>();
            CreateMap<UpdateRoomType, RoomType>();
            CreateMap<RoomType, UpdateRoomType>();
        }
    }
}
