using WEBus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteEagleBus.Models
{
    public class BusTrip
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Destination")]
        [Required]
        public int DestinationID { get; set; }
        public BusTripLocation Destination { get; set; }
        [ForeignKey("Origin")]
        [Required]        
        public int OriginID { get; set; }
        public BusTripLocation Origin { get; set; }
        [ForeignKey("Bus")]
        [Required]
        public int BusID { get; set; }
        public Bus Bus { get; set; }

        public ICollection<BusTripSeatBooking> Reservations { get; }

        public BusTrip(BusTripLocation origin, BusTripLocation destination, Bus bus)
        {
            this.Origin = origin;
            this.Destination = destination;
            this.Bus = bus;
        }

        public BusTrip()
        {

        }
    }
}
