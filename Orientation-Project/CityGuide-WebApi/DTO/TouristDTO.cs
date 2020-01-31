using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class TouristDTO
    {
        public int TicketPrice { get; set; }
        public int HasWifi { get; set; }

        public int HasPark { get; set; }
        public int HasSwimmingPool { get; set; }
        public int HasParking { get; set; }
        public int HasElevator { get; set; }
        public int HasMedical { get; set; }
       
        public int HasTrekking { get; set; }
     

    }
}
