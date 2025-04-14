using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBase.Domain.Entities;

namespace AutoBase.Domain {
    public class AutoBaseSystemContext: DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<TripReport> TripReports { get; set; }

        public AutoBaseSystemContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Отключаем каскадные удаления, чтобы не было конфликтов
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Request)
                .WithOne(req => req.Ride)
                .HasForeignKey<Ride>(r => r.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Driver)
                .WithOne()
                .HasForeignKey<Car>(c => c.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rides)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TripReport>()
                .HasOne(t => t.Ride)
                .WithOne(r => r.TripReport)
                .HasForeignKey<TripReport>(t => t.RideId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
