using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class ApplicationModel
    {
        [Key]
        [Required]
        public Guid ApplicationId { get; set; }


        public string ApplicationName { get; set; }
    }
}
