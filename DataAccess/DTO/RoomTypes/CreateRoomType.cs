using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO.RoomTypes
{
    public class CreateRoomType
    {
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string TypeName { get; set; }
    }
}
