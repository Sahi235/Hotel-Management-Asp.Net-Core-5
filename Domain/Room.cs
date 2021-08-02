using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Room
    {
        public Guid Id { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerNight { get; set; }
        public int NumberOfBed { get; set; } = 1;
        public string Description { get; set; }
        public Hotel Hotel { get; set; }
        public Guid HotelId { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<RoomService> Services { get; set; }
        public RoomType RoomType { get; set; }
        public Guid RoomTypeId { get; set; }
        public ICollection<RoomImage> RoomImages { get; set; }

    }
}
