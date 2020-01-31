using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.View_Layer
{
    public class EditBlogViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public int Likes { get; set; }

        public int Dislikes { get; set; }
        public Guid PostedBy { get; set; }

    }
}
