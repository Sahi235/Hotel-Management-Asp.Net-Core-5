using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Service
    {
        public Guid Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ServicePrice { get; set; }
        public ICollection<RoomService> Rooms { get; set; }
        [Required]
        public string Icon { get; set; }
        public ICollection<ServiceImage> ServiceImages { get; set; }
        public ICollection<ReservationService> Reservation { get; set; }
    }
}
