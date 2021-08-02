using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ReservationService
    {
        public Guid ReservationId { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public Reservation Reservation { get; set; }

    }
}
