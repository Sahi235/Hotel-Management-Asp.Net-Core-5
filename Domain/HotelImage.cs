using System;

namespace Domain
{
    public class HotelImage : Image
    {
        public Hotel Hotel { get; set; }
        public Guid HotelId { get; set; }
    }
}
