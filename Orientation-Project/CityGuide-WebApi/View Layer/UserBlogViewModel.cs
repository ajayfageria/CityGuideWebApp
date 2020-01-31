using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.View_Layer
{
    public class UserBlogViewModel
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

        public bool LikeOrDislike { get; set; }
    }
}
