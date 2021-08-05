using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using WEBus.Controllers;
using WEBus.Data;
using WEBus.Models;
using WhiteEagleBus.Models;
using Xunit;

namespace WEBusTest
{
    public abstract class BusTripSeatBookingTest
    {
        protected DbContextOptions<ApplicationContext> ContextOptions { get; }
        protected BusTripSeatBookingTest(DbContextOptions<ApplicationContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Bus and seats
                var bus = new Bus("ItemOne");
                bus.AddSeat("Z1");
                bus.AddSeat("Z2");
                bus.AddSeat("Z3");

                // Locations
                var locationOne = new BusTripLocation("Cidade Teste Um");
                var locationTwo = new BusTripLocation("Cidade Teste Dois");

                // Trips
                var tripOne = new BusTrip(locationOne, locationTwo, bus);

                context.AddRange(bus, locationOne, locationTwo, tripOne);

                context.SaveChanges();
            }
        }

        [Fact]
        public void Can_post_booking()
        {
            using (ApplicationContext context = new ApplicationContext(ContextOptions))
            {
                BusTripSeatBookingsController controller = new BusTripSeatBookingsController(context);

                BusTripSeatBooking booking = new BusTripSeatBooking();
                booking.BusSeatId = 1;
                booking.BusTripId = 1;
                //Request
                ActionResult<BusTripSeatBooking> result = controller.PostBusTripSeatBooking(booking).Result;
                CreatedAtActionResult r = (CreatedAtActionResult) result.Result;
                BusTripSeatBooking v = (BusTripSeatBooking) r.Value;
                // Asserts status code and values
                Assert.Equal(r.StatusCode, (int) HttpStatusCode.Created);
                Assert.Equal(v.BusSeatId, booking.BusSeatId);
                Assert.Equal(v.BusTripId, booking.BusTripId);
            }
        }

        [Fact]
        public void Cant_post_same_booking()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new BusTripSeatBookingsController(context);

                var booking = new BusTripSeatBooking();
                booking.BusSeatId = 2;
                booking.BusTripId = 1;
                // First should go ok
                var result = controller.PostBusTripSeatBooking(booking).Result;
                CreatedAtActionResult r = (CreatedAtActionResult)result.Result;
                BusTripSeatBooking v = result.Value;
                Assert.Equal(r.StatusCode, (int) HttpStatusCode.Created);
                // Second should fail with 400
                var result2 = controller.PostBusTripSeatBooking(booking).Result;
                BadRequestObjectResult r2 = (BadRequestObjectResult)result2.Result;
                Assert.Equal(r2.StatusCode, (int) HttpStatusCode.BadRequest);
            }
        }
    }
  
}
