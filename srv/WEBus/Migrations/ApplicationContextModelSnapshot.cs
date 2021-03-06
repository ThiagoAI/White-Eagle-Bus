// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBus.Data;

namespace WEBus.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEBus.Models.Bus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("ID");

                    b.ToTable("Busses");
                });

            modelBuilder.Entity("WEBus.Models.BusSeat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("SeatName")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("ID");

                    b.HasIndex("BusId");

                    b.ToTable("BusSeats");
                });

            modelBuilder.Entity("WhiteEagleBus.Models.BusTrip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusID")
                        .HasColumnType("int");

                    b.Property<int>("DestinationID")
                        .HasColumnType("int");

                    b.Property<int>("OriginID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BusID");

                    b.HasIndex("DestinationID");

                    b.HasIndex("OriginID");

                    b.ToTable("BusTrips");
                });

            modelBuilder.Entity("WhiteEagleBus.Models.BusTripLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BusTripLocations");
                });

            modelBuilder.Entity("WhiteEagleBus.Models.BusTripSeatBooking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusSeatId")
                        .HasColumnType("int");

                    b.Property<int>("BusTripId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BusTripId");

                    b.HasIndex("BusSeatId", "BusTripId")
                        .IsUnique();

                    b.ToTable("BusTripSeatBooking");
                });

            modelBuilder.Entity("WEBus.Models.BusSeat", b =>
                {
                    b.HasOne("WEBus.Models.Bus", "Bus")
                        .WithMany("Seats")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("WhiteEagleBus.Models.BusTrip", b =>
                {
                    b.HasOne("WEBus.Models.Bus", "Bus")
                        .WithMany("BusTrips")
                        .HasForeignKey("BusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhiteEagleBus.Models.BusTripLocation", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhiteEagleBus.Models.BusTripLocation", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("WhiteEagleBus.Models.BusTripSeatBooking", b =>
                {
                    b.HasOne("WEBus.Models.BusSeat", "BusSeat")
                        .WithMany()
                        .HasForeignKey("BusSeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhiteEagleBus.Models.BusTrip", "BusTrip")
                        .WithMany("Reservations")
                        .HasForeignKey("BusTripId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BusSeat");

                    b.Navigation("BusTrip");
                });

            modelBuilder.Entity("WEBus.Models.Bus", b =>
                {
                    b.Navigation("BusTrips");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("WhiteEagleBus.Models.BusTrip", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
