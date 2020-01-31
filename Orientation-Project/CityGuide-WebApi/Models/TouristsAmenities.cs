using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class TouristsAmenities
    {
        public Guid Id { get; set; }

        [ForeignKey("Id")]

        public virtual BaseTable BaseTable { get; set; }
        public int TicketPrice { get; set; }
        public bool HasWifi { get; set; }

        public bool HasPark { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasParking { get; set; }
        public bool HasElevator { get; set; }
        public bool HasMedical { get; set; }
       
        public bool HasTrekking { get; set; }
     

    }
}
