using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class UserBlog
    {
        [Key]
        public int Id { get; set; }
        public bool LikeOrDislike { get; set; }

        [ForeignKey("UserId")]
        public virtual BaseTable BaseModel { get; set; }

        [ForeignKey("BlogId")]
        public virtual BlogModel BlogModel { get;set; }
    }
}
