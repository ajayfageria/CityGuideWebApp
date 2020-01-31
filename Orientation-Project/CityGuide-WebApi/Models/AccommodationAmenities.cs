using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class AccommodationAmenities
    {
        public Guid Id { get; set; }
     
        [ForeignKey("Id")]
        public virtual BaseTable BaseTable { get; set; }
        public bool HasInternet { get; set; }
        public bool HasMeetingRooms { get; set; }
        public bool HasFitnessFacilities { get; set; }
        public bool HasParking { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasElevator { get; set; }
        public bool HasSecurityGaurd { get; set; }
        public bool HasTv { get; set; }

        public int LuxeryLevel { get; set; }
    }
}
