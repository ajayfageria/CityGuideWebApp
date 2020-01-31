using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class BaseTableDTO 
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Altitude { get; set; }

        public string Information { get; set; }

        public string NearestMetro { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

    }
}
