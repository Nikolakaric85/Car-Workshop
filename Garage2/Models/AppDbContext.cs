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





        }


    }
    }

/*
    protected override void OnModelCreating(ModelBuilder builder)
        {
                 builder.Entity<ServiceItem>()
                .HasOne(i => i.Service)
                .WithMany(s => s.ServiceItems)
                .HasForeignKey(i => i.ServiceId);


            builder.Entity<ServiceItem>()
                .HasOne(i => i.ServiceCategory)
                .WithMany(c => c.ServiceItems)
                .HasForeignKey(i => i.CategoryId);
        }*/