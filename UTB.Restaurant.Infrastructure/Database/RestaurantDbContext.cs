using Microsoft.EntityFrameworkCore;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UTB.Restaurant.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using UTB.Restaurant.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace UTB.Restaurant.Infrastructure.Database
{
    public class RestaurantDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RestaurantDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ProductInit productInit = new ProductInit();
            modelBuilder.Entity<Product>().HasData(productInit.GetProductsFood3());

            CarouselInit carouselInit = new CarouselInit();
            modelBuilder.Entity<Carousel>().HasData(carouselInit.GetCarouselsIT3());

            TableInit tableInit = new TableInit();
            List<Table> tables = tableInit.GetTables() as List<Table>;
            modelBuilder.Entity<Table>().HasData(tables);

            UserInit userInit = new UserInit();
            List<User> users = new List<User> { userInit.GetAdmin(), userInit.GetManager(), userInit.GetCustomer() };
            modelBuilder.Entity<User>().HasData(users);

            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());

            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> managerUserRoles = userRolesInit.GetRolesForManager();
            List<IdentityUserRole<int>> customerUserRoles = userRolesInit.GetRolesForCustomer();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(customerUserRoles);
            
            ReservationInit reservationInit = new ReservationInit();
            List<Reservation> reservations = reservationInit.GetReservations(users, tables) as List<Reservation>;
            modelBuilder.Entity<Reservation>().HasOne(s => (User)s.User).WithMany().HasForeignKey(s => s.UserId);
        }
    }
}
