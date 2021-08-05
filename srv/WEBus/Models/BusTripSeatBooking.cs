using WEBus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WhiteEagleBus.Models
{
    public class BusTripSeatBooking
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("BusSeat")]
        [Required]
        public int BusSeatId { get; set; }
        [JsonIgnore]
        public BusSeat BusSeat { get; set; }

        [ForeignKey("BusTrip")]
        [Required]
        public int BusTripId { get; set; }
        [JsonIgnore]
        public BusTrip BusTrip { get; set; }

    }
}
