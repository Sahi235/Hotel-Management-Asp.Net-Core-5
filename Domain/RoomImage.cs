using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RoomImage : Image
    {
        public Room Room { get; set; }
        public Guid RoomId { get; set; }
    }
}
