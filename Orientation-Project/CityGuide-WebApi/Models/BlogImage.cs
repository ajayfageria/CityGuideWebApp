using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class BlogImage
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }

        public Guid BlogId { get; set; }
        
        [ForeignKey("BlogId")]
        public virtual BlogModel BlogModel { get; set; }
    }
}
