using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ArriveTime { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DepartureTime { get; set; }
        public bool IsApproved { get; set; } = false;
        //Client
        public Client Client { get; set; }
        [ForeignKey("ClientId_FK")]
        public Guid ClientId { get; set; }
        //Room
        public Room Room { get; set; }
        public Guid RoomId { get; set; }

        //Payment
        public ReservationPayment ReservationPayment { get; set; }

        public ICollection<ReservationService> Services { get; set; } 

    }
}
