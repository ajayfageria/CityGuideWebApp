using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.View_Layer
{
    public class ImageBlogViewModel
    {
        public Guid BlogId { get; set; }
        public byte[] Image { get; set; }

    }
}
