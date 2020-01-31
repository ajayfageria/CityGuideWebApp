using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class BaseTable 
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel CategoryModel { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Altitude { get; set; }

        public string Information { get; set; }

        public string NearestMetro { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

    }
}
