using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CityGuide_WebApi.Data;
using CityGuide_WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CityGuide_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        string rootPath="~Images/";
        private ApplicationContext _context;

        public ImagesController(ApplicationContext context)
        {
            _context = context;

        }

        // GET: api/AddByAdmin
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("GetImages/{id}")]
        public FileResult GetImages(Guid id)
        {
            var byteArray = _context.EnitityImages.FirstOrDefault(Id => Id.EntityID == id).Image;
            return File(byteArray, "image/png", $"Image{id}");  
        }

        

        [HttpGet]
        [Route("GetImg/{id}")]
        [AllowAnonymous]
        public IActionResult Get(Guid id)
        {
            try
            {
                EntityImages s_bitImage = _context.EnitityImages.FirstOrDefault(Id => Id.EntityID == id);
                string byteImage = s_bitImage.Image.ToString();

                s_bitImage.Path = $"api/Images/GetImages/{id}";
                s_bitImage.Image = null;
                return Ok(new { data = s_bitImage });

            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

        // POST: api/AddByAdmin
        [HttpPost]
        public ActionResult Post([FromQuery] Guid Id )
        {
           
            try
            {
                var file = Request.Form.Files[0];
                if(file != null)
                {
                     string folderName = "Upload";
               
                     string newPath = Path.Combine(rootPath, folderName);
                     if (!Directory.Exists(newPath))
                     {
                        Directory.CreateDirectory(newPath);
                     }
                     foreach (var files in Request.Form.Files)
                     {
                       
                        if (files.Length > 0)
                         {
                            byte[] p1= null;
                            using (var fs1 = files.OpenReadStream())
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                            string fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
                            string fullPath = Path.Combine(newPath, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                files.CopyTo(stream);
                            }
                            EntityImages entityImages = new EntityImages()
                            {
                                EntityID = Id,
                                Image = p1
                            };
                            _context.EnitityImages.Add(entityImages);
                            _context.SaveChanges();
                         }
                        
                     } 
                   
                     return Ok("Upload Successful.");
                }

                else 
                {
                    return BadRequest("No files are there to upload.");
                }
                
                //}
               
            }
            catch (System.Exception ex)
            {
                return Ok("Upload Failed: " + ex.Message);
            }

}

            private void Json(string v)
        {
            throw new NotImplementedException();
        }










        // PUT: api/AddByAdmin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
