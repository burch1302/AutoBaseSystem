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
    }
}
