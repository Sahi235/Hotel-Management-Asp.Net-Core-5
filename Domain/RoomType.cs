using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class RoomType : BaseEntity
    {
        [Required]
        public string TypeName { get; set; }
        public ICollection<Room> Rooms { get; set; }

    }
}
