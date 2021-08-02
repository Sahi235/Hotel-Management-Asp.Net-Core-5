using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.RoomTypes.Dto
{
    public class CreateRoomTypeDto
    {
        [Required ,MaxLength(255)]
        public string TypeName { get; set; }
    }
}
