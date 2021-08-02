using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Database
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> context) : base(context)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EmployeePaymentHistory> EmployeePaymentHistories { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationPayment> ReservationPayments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<EmployeeImage> EmployeeImages { get; set; }
        public DbSet<RoomService> RoomServices { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Client>()
                .HasOne(c => c.Reservation)
                .WithOne(c => c.Client)
                .HasForeignKey<Reservation>(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Reservation>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Reservation)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Reservation>()
                .HasOne(c => c.Room)
                .WithMany(c => c.Reservations)
                .HasForeignKey(c => c.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Reservation>()
                .HasOne(c => c.ReservationPayment)
                .WithOne(c => c.Reservation)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<RoomService>().HasKey(c => new { c.RoomId, c.ServiceId });
            builder.Entity<RoomService>().HasOne(c => c.Room).WithMany(c => c.Services).HasForeignKey(c => c.RoomId);
            builder.Entity<RoomService>().HasOne(c => c.Service).WithMany(c => c.Rooms).HasForeignKey(c => c.ServiceId);
            builder.Entity<Room>().Property(nameof(Room.PricePerNight)).HasDefaultValue(0);
            builder.Entity<ReservationService>().HasKey(e => new { e.ServiceId, e.ReservationId });
            builder.Entity<ReservationService>().HasOne(e => e.Reservation).WithMany(e => e.Services)
                .HasForeignKey(e => e.ReservationId);
            builder.Entity<ReservationService>().HasOne(e => e.Service).WithMany(e => e.Reservation)
                .HasForeignKey(e => e.ServiceId);

            builder.Entity<ApplicationUserRole>().HasOne(e => e.User).WithMany(e => e.Roles)
                .HasForeignKey(e => e.UserId);
            builder.Entity<ApplicationUserRole>().HasOne(e => e.Role).WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId);
            builder.Entity<ApplicationUserRole>().HasKey(e => new { e.UserId, e.RoleId });

            const string userId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
            const string roleId = "d68ba8ab-7348-488f-ac65-34ff796f5476";

            //seed admin role
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Name = "Admin",
                NormalizedName = "admin".ToUpper(),
                Id = roleId,
                ConcurrencyStamp = roleId,
            });

            //create user
            var appUser = new ApplicationUser()
            {
                Id = userId,
                Email = "Sahand.Salmani@gmail.com",
                EmailConfirmed = true,
                UserName = "Sahand",
                NormalizedEmail = "Sahand.Salmani@gmail.com".ToUpper(),
                NormalizedUserName = "sahand".ToUpper(),
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Test123");

            //seed user
            builder.Entity<ApplicationUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole()
            {
                UserId = userId,
                RoleId = roleId,
            });

            //builder.ApplyConfiguration(new RolesConfigurations());
            //builder.ApplyConfiguration(new UsersConfigurations());
        }
    }
}
