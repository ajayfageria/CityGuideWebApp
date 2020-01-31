using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityGuide_WebApi.Data;
using CityGuide_WebApi.Models;
using CityGuide_WebApi.View_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityGuide_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IMapper _mapper;
        private ApplicationContext _context;

        public BlogController(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/Blog
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Blog
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Post(BlogViewModel blog )
        {
            try
            {
                BlogModel blogData =_mapper.Map<BlogModel>(blog);

                var checkEntry = _context.Blogs.Where(c => c.Name == blogData.Name);
                if (checkEntry.Count() == 0)
                {
                    _context.Blogs.Add(blogData);
                    await _context.SaveChangesAsync();
                    //AddImage(formFiles);
                    return Ok(new { message = "New Entry Added" });
                }
                else
                {
                    return BadRequest(new { message = "Can't add duplicate values" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Cant Add the new entry");
                throw ex;

            }
        }
        [HttpPost]
        public ActionResult AddImage(List<IFormFile> formFiles )
        {
            try
            {
                return Ok(new { message = "New Entry Added" });
                
            }
            catch (Exception)
            {
                return BadRequest("Cant Add the new entry");
               

            }
        }


        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] EditBlogViewModel blog)
        {
            BlogModel data =await _context.Blogs.FirstOrDefaultAsync(data => data.Id == blog.Id);
            if(data != null)
            {
                data.Description = blog.Description;
                data.Name = blog.Name;
                data.PostedBy = blog.PostedBy;
                data.PostedOn = blog.PostedOn;
                _context.Blogs.Update(data);
                await _context.SaveChangesAsync();
               
                _context.Entry(data).State = EntityState.Modified ;  
            }
           
            return Ok(new { });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            BlogModel blog = await _context.Blogs.FirstOrDefaultAsync(data => data.Id == id);
            if(blog != null)
            {
             _context.Blogs.Remove(blog);
                return Ok("Deleted");
            }
            else
            {
                return BadRequest("Try Again");
            }
          
        }

        [HttpPost]
        public async Task<ActionResult> LikeDislike(UserBlogViewModel userBlog)
        {
            UserBlog userBlogEntity = _mapper.Map<UserBlog>(userBlog);

            UserBlog UserBlogData = _context.userBlogs.Add(userBlogEntity).Entity;
            await _context.SaveChangesAsync();

            if (UserBlogData != null)
            {
                BlogModel blogData = await _context.Blogs.FirstOrDefaultAsync(data => data.Id == userBlog.BlogId);
                if (userBlog.LikeOrDislike == true)
                {
                    blogData.Likes  = blogData.Likes + 1;
                    _context.Blogs.Update(blogData);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    blogData.Dislikes = blogData.Dislikes + 1;
                    _context.Blogs.Update(blogData);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            else
            {
                return BadRequest("Try Again");
            }
        }


        
        [HttpGet]
        public  ActionResult BlogOfMonth()
        {
           BlogModel maxBlogData = _context.Blogs.Aggregate((i1, i2) => i1.Likes > i2.Likes ? i1 : i2);
          
           return Ok(new {BlogOfMonth = maxBlogData });
        }
    }
}
