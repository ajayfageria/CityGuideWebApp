using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class CategoryModel
    {
        [Key]
        public int ID { get; set; }

        public string CategoryName { get; set; }

    }
}
