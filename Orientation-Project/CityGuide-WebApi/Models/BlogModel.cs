using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class BlogModel
    {

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PostedOn { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public Guid PostedBy { get; set; }
        
        [ForeignKey("PostedBy")]
        public virtual BaseTable baseModel { get; set; }

    }
}
