using CityGuide_WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.View_Layer
{
    public class AddAccommodationAmenitiesViewModel
    {
      

        public string Name { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Altitude { get; set; }

        public string Information { get; set; }

        public string NearestMetro { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }
       
        public bool HasInternet { get; set; }
        public bool HasMeetingRooms { get; set; }
        public bool HasFitnessFacilities { get; set; }
        public bool HasParking { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasElevator { get; set; }
        public bool HasSecurityGuard { get; set; }
        public bool HasTv { get; set; }

        public int LuxeryLevel { get; set; }
    }
}
