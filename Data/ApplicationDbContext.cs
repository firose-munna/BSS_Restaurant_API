using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CardType> CardType { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTable> EmployeeTable { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodPackage> FoodPackage { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Gender>().HasData(
                new Gender()
                {
                    Id = 1,
                    GenderName = "Male"
                },
                new Gender()
                {
                    Id = 2,
                    GenderName = "Female"
                },
                new Gender()
                {
                    Id = 3,
                    GenderName = "Others"
                });

            builder.Entity<ApplicationUser>().HasData(

                new ApplicationUser()
                {
                    Id = new Guid("165d85b8-c45b-4fdf-b812-eb27e9e67264"),
                    FirstName = "System",
                    MiddleName = "Admin",
                    LastName = "",
                    FullName = "Admin",
                    FatherName = "",
                    MotherName = "",
                    SpouseName = "",
                    NID = "",
                    DOB = Convert.ToDateTime("02/07/1993"),
                    GenderId = 1,
                    UserName = "admin@mail.com",
                    NormalizedUserName = "admin@mail.com",
                    Email = "admin@mail.com",
                    NormalizedEmail = "admin@mail.com",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEFTw0YzFmNSap0Oq8Tb4C2h1Jdvd1fMHL+pKDwaxcY+2Rg/i3jP0cAKJshnm6wy/fQ==",
                    SecurityStamp = "KOFABGFNZCSAIOQ7VCPER53GEIMMBIFK",
                    ConcurrencyStamp = "c0546a67-12e3-413e-98d7-2e981f03aa95",
                    PhoneNumber = "01956431180",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    Image = "",

                }
            );

            builder.Entity<Order>()
               .HasOne(x => x.OrderTakenBy)
               .WithMany(x => x.OrdersForEmployee)
               .HasForeignKey(x => x.OrderTakenById);

            builder.Entity<Order>()
               .HasOne(x => x.OrderedBy)
               .WithMany(x => x.OrdersForCustomer)
               .HasForeignKey(x => x.OrderedById);

        }
    }
}
