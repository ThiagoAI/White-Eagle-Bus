using WEBus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteEagleBus.Models;

namespace WEBus.Data
{
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove conflicting cascade deletes
            modelBuilder.Entity<BusTrip>()
                .HasOne(b => b.Origin)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusTripSeatBooking>()
                .HasOne(b => b.BusTrip)
                .WithMany(t => t.Reservations)
                .OnDelete(DeleteBehavior.NoAction);

            // Reservations are unique by trip and seat
            modelBuilder.Entity<BusTripSeatBooking>()
                .HasIndex(r => new { r.BusSeatId, r.BusTripId }).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bus> Busses { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }
        public DbSet<BusTripSeatBooking> BusTripSeatBooking { get; set; }
        public DbSet<BusTrip> BusTrips { get; set; }
        public DbSet<BusTripLocation> BusTripLocations { get; set; }
    }
}
