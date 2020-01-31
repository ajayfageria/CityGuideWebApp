using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class DistanceModel
    {
        public Guid PlaceId { get; set; }

        public double DistanceFromCurrentlocation { get; set; }

        public string Name { get; set; }

        public double Latitute { get; set; }

        public double Longitude { get; set; }
    }
}
