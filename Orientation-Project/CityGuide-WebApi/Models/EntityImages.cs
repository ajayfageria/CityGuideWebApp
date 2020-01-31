using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class EntityImages
    {
        [Key]
        public int ID { get; set; }

        public Guid EntityID { get; set; }

        [ForeignKey("EntityID")]
        public virtual BaseTable BaseTable { get; set;   }

        public byte[] Image { get; set; }
        [NotMapped]
        public string Path { get; set; }
    }
}
