using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public Hotel Hotel { get; set; }
        public Guid HotelId { get; set; }
    }
}
