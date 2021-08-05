using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WhiteEagleBus.Models;

namespace WEBus.Models
{
    public class Bus
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Name { get; set; }
        public ICollection<BusSeat> Seats { get;}
        [JsonIgnore]
        public ICollection<BusTrip> BusTrips { get; }

        public Bus(string name)
        {
            this.Name = name;
            this.Seats = new List<BusSeat>();
            this.BusTrips = new List<BusTrip>();
        }

        public Bus()
        {

        }

        public void AddSeat(string seatName)
        {
            BusSeat busSeat = new BusSeat(this, seatName);
            if (this.Seats.Contains(busSeat))
            {
                throw new Exception("Seat already exists.");
            }
            else
                this.Seats.Add(busSeat);
        }

        public void RemoveSeat(string seatName)
        {
            this.Seats.Remove(new BusSeat(this, seatName));
        }
    }
}
