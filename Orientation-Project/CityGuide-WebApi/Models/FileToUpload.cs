using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class FileToUpload
    {
        //public string FileName { get; set; }
        //public string FileSize { get; set; }
        //public string FileType { get; set; }
        //public long LastModifiedTime { get; set; }
        //public DateTime LastModifiedDate { get; set; }
        //public string FileAsBase64 { get; set; }
        //public byte[] FileAsByteArray { get; set; }
        public List<IFormFile> Image { get; set; }

    }
}
