using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class ReservationPayment
    {
        public Guid Id { get; set; }
        public bool IsPaid { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public Reservation Reservation { get; set; }
        public Guid ReservationId { get; set; }
    }

    public enum PaymentTypes
    {
        Online,
        InCash
    }
}
