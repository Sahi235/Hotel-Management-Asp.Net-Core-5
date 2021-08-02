using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class EmployeePaymentHistory
    {
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Amount { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime AtDate { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
