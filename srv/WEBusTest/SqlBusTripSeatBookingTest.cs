using Microsoft.EntityFrameworkCore;
using WEBus.Data;

namespace WEBusTest
{
    public class SqlBusTripSeatBookingTest : BusTripSeatBookingTest
    {
        public SqlBusTripSeatBookingTest() : base(
            new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Test_WEBUS;Trusted_Connection=True;")
                .Options
            )
        { }
    }
}
