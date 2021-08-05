using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBus.Migrations
{
    public partial class Initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Busses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusTripLocations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(500)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTripLocations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusSeats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    SeatName = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSeats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusSeats_Busses_BusId",
                        column: x => x.BusId,
                        principalTable: "Busses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusTrips",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    OriginID = table.Column<int>(type: "int", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrips", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusTrips_Busses_BusID",
                        column: x => x.BusID,
                        principalTable: "Busses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusTrips_BusTripLocations_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "BusTripLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusTrips_BusTripLocations_OriginID",
                        column: x => x.OriginID,
                        principalTable: "BusTripLocations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BusTripSeatBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusSeatId = table.Column<int>(type: "int", nullable: false),
                    BusTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTripSeatBooking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusTripSeatBooking_BusSeats_BusSeatId",
                        column: x => x.BusSeatId,
                        principalTable: "BusSeats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusTripSeatBooking_BusTrips_BusTripId",
                        column: x => x.BusTripId,
                        principalTable: "BusTrips",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusSeats_BusId",
                table: "BusSeats",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_BusID",
                table: "BusTrips",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_DestinationID",
                table: "BusTrips",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrips_OriginID",
                table: "BusTrips",
                column: "OriginID");

            migrationBuilder.CreateIndex(
                name: "IX_BusTripSeatBooking_BusSeatId_BusTripId",
                table: "BusTripSeatBooking",
                columns: new[] { "BusSeatId", "BusTripId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusTripSeatBooking_BusTripId",
                table: "BusTripSeatBooking",
                column: "BusTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusTripSeatBooking");

            migrationBuilder.DropTable(
                name: "BusSeats");

            migrationBuilder.DropTable(
                name: "BusTrips");

            migrationBuilder.DropTable(
                name: "Busses");

            migrationBuilder.DropTable(
                name: "BusTripLocations");
        }
    }
}
