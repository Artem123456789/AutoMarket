using AutoMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket
{
    public class AppDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarDetails)
                .WithOne(c => c.Car);
            modelBuilder.Entity<CarDetail>()
                .HasMany(d => d.Items)
                .WithOne(i => i.CarDetail);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
            modelBuilder.Entity<Order>()
                .Ignore(o => o.CompletedView)
                .Ignore(o => o.Price)
                .Ignore(o => o.CreatedView);
            modelBuilder.Entity<CarDetail>()
                .Ignore(c => c.DetailCar);
        }
    }
}
