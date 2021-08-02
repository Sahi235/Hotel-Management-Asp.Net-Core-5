using System;

namespace Domain
{
    public class ServiceImage : Image
    {
        public Service Service { get; set; }
        public Guid ServiceId { get; set; }
    }
}
