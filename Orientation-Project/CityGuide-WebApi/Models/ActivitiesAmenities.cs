using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class ActivitiesAmenities
    {
       
        public Guid Id { get; set; }
        
        [ForeignKey("Id")]
        public virtual BaseTable BaseTable { get; set; }
        public int TicketPrice { get; set; }
        public bool HasElevator { get; set; }
        public string Type { get; set; }
        public int NoOfHoursTaken { get; set; }

        public bool HasWashroomFacilities { get; set; }
    }
}
