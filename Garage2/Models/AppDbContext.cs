using Garage2.Models.Car;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<CategoryItems> CategoryItems { get; set; }
        public DbSet<Cars> Cars { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CategoryItems>()
                .HasOne(c => c.Service)
                .WithMany(s => s.CategoryItems)
                .HasForeignKey(c => c.ServiceId);

            builder.Entity<CategoryItems>()
                .HasOne(c => c.ServiceCategory)
                .WithMany(i => i.CategoryItems)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<CategoryItems>()
                .HasOne(c => c.ServiceItem)
                .WithMany(i => i.CategoryItems)
                .HasForeignKey(c => c.ItemId);

            //*********** USERS AND USERS ROLES **************//

            //Seeding a  'Administrator' role to AspNetRoles table
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            }, new IdentityRole {
                Id = "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8",
                Name = "User",
                NormalizedName = "USER".ToUpper()
            });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            builder.Entity<AppUser>().HasData(
            new AppUser { 
                Id= "8e445865-a24d-4543-a6c6-9443d048cdb9", 
                UserName="Admin",
                LastName="Admin",
                NormalizedUserName="ADMIN",
                PasswordHash = hasher.HashPassword(null,"password"),
                Email="admin@gmail.com",
                NormalizedEmail="ADMIN@GMAIL.COM",
                LicencePlate="SD-000-XX",
                RoleName = "Admin"
            }, new AppUser
            {
                Id = "165412e8-86ab-4ade-b351-75494216e814",
                UserName = "User",
                LastName ="User",
                NormalizedUserName = "USER",
                PasswordHash = hasher.HashPassword(null, "password"),
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                LicencePlate = "SD-000-XX",
                RoleName = "User"

            });

            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { 
                    RoleId= "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId= "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }, 
                new IdentityUserRole<string>
                {
                    RoleId= "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8",
                    UserId= "165412e8-86ab-4ade-b351-75494216e814"
                });

            //*********** CATEGORY AND ITEMS **************//

            builder.Entity<ServiceCategory>().HasData(
                new ServiceCategory
                {
                    CategoryId=1,
                    Category= "Oil Change"
                },
                new ServiceCategory
                {
                    CategoryId=2,
                    Category= "Timing Belt"
                },
                new ServiceCategory
                {
                    CategoryId=3,
                    Category= "Wheel Aligment"
                });

            builder.Entity<ServiceItem>().HasData(
                new ServiceItem
                {
                    ItemId=1,
                    Item= "Air Filter",
                    CategoryId=1,
                    Category= "Oil Change",
                },
                new ServiceItem
                {
                    ItemId = 2,
                    Item = "Oil Filter",
                    CategoryId = 1,
                    Category = "Oil Change",
                },
                new ServiceItem
                {
                    ItemId = 3,
                    Item = "Cabin Filter",
                    CategoryId = 1,
                    Category = "Oil Change",
                },
                new ServiceItem
                {
                    ItemId = 4,
                    Item = "Fuel Filter",
                    CategoryId = 1,
                    Category = "Oil Change",
                },
                new ServiceItem
                {
                    ItemId = 5,
                    Item = "Water Pump",
                    CategoryId = 2,
                    Category = "Timing Belt",
                },
                new ServiceItem
                {
                    ItemId = 6,
                    Item = "PK Belt",
                    CategoryId = 2,
                    Category = "Timing Belt",
                },
                new ServiceItem
                {
                    ItemId = 7,
                    Item = "Wheel Aligment",
                    CategoryId = 3,
                    Category = "Wheel Aligment",
                });

            //*********** CARS **************//

            builder.Entity<Cars>().HasData(
                new Cars
                {
                    Id=1,
                    Model= "Fiat Punto",
                    Year=2005,
                    FuelType="Petrol",
                    EngineDisplacement=1242,
                    EnginePower=60,
                    VinNumber= "SFGDGF54164165",
                    EngineNumber= "188A4000B6531651",
                    UserId= "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    LicencePlate="SD-000-XX",
                    IsActive=true
                },
                new Cars
                {
                    Id = 2,
                    Model = "Yamaha MT-07",
                    Year = 2014,
                    FuelType = "Petrol",
                    EngineDisplacement = 689,
                    EnginePower = 75,
                    VinNumber = "56161616DSGVFDS",
                    EngineNumber = "15616DSFCDSW",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    LicencePlate = "SD-00-000",
                    IsActive = true
                });

            //*********** SERVICE **************//

            builder.Entity<Service>().HasData(
                new Service { 
                    ServiceId = 1,
                    ServiceDate= DateTime.Now,
                    Mileage=78000,
                    ServiceCost=10000,
                    Notes="Selenia Gold",
                    CarId = 1
                });

            //*********** CATEGORY_ITEMS **************//
            builder.Entity<CategoryItems>().HasData(
                new CategoryItems
                {
                    Id=1,
                    ItemId=1,
                    Items= "Air Filter",
                    CategoryId=1,
                    Category= "Oil Change",
                    ServiceId=1  
                },
                new CategoryItems
                {
                    Id = 2,
                    ItemId = 2,
                    Items = "Oil Filter",
                    CategoryId = 1,
                    Category = "Oil Change",
                    ServiceId = 1
                });
        }
    }
}





        
 
 
