using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Hotels.Dto
{
    public class CreateHotelDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Area { get; set; }
        public int RoomNumber { get; set; }
        public int SwimmingPoolNumber { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int RestaurantNumber { get; set; }
        public IFormFile File { get; set; }
    }
}
