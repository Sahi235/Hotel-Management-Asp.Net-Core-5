using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(1027)]
        public string ImageUrl { get; set; }
        [MaxLength(1027)]
        public string Description { get; set; }
    }
}
