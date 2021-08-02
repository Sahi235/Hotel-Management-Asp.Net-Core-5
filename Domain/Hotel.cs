using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Domain
{
    public class Hotel
    {
        public static Expression<Func<Hotel, bool>> Expression => hotel => hotel.Rooms.Any();
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Area { get; set; }
        public int RoomNumber { get; set; }
        public int SwimmingPoolNumber { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int RestaurantNumber { get; set; }

        //hotel
        public virtual City City { get; set; }
        public Guid CityId { get; set; }

        //Rooms
        public ICollection<Room> Rooms { get; set; }

        //Employees
        public ICollection<ApplicationUser> Employees { get; set; }
        
        //Images
        public string MainImageUrl { get; set; }
        public ICollection<HotelImage> Images { get; set; }

        //tags

        public ICollection<Comment> Comments { get; set; }

    }
}
