using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEBus.Models
{
    public class BusSeat
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Bus")]
        [Required]
        public int BusId {get; set; }
        [JsonIgnore]
        public Bus Bus { get; set; }

        [Column(TypeName ="varchar(5)")]
        [Required]
        public string SeatName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BusSeat seat &&
                   SeatName == seat.SeatName &&
                   EqualityComparer<Bus>.Default.Equals(Bus, seat.Bus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BusId, SeatName, Bus);
        }

        public BusSeat(Bus bus, string seatName)
        {
            this.Bus = bus;
            this.SeatName = seatName;
        }

        public BusSeat()
        {

        }
    }
}
