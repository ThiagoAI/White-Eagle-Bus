using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteEagleBus.Models
{
    public class BusTripLocation
    {
        public enum BusTripLocationType
        {
            OriginAndDestination,
            Origin,
            Destination
        }

        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Name { get; set; }

        [Required]
        public BusTripLocationType Type { get; set; }

        public BusTripLocation(string name)
        {
            this.Name = name;
            this.Type = BusTripLocationType.OriginAndDestination;
        }

        public BusTripLocation()
        {

        }
    }
}
