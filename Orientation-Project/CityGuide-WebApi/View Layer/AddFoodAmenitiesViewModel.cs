using CityGuide_WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.View_Layer
{
    public class AddFoodAmenitiesViewModel
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
        
        public bool HasFoodStalls { get; set; }
        public bool HasVeg { get; set; }
        public bool HasNonveg { get; set; }
        public bool HasFoodPackaging { get; set; }
        public bool HasOnlineDelivery { get; set; }
        public string FoodType { get; set; }
       

    }
}
