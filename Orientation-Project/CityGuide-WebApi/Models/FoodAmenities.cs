using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class FoodAmenities
    {
        public Guid Id { get; set; }
        
        [ForeignKey("Id")]
        public virtual BaseTable BaseTable { get; set; }
        public bool HasFoodStalls { get; set; }
        public bool HasVeg { get; set; }
        public bool HasNonveg { get; set; }
        public bool HasFoodPackaging { get; set; }
        public bool HasOnlineDelivery { get; set; }
        public string FoodType { get; set; }
       

    }
}
