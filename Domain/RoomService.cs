﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RoomService
    {
        public Guid RoomId { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public Room Room { get; set; }

    }
}
