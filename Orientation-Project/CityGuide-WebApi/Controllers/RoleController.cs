using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide_WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CityGuide_WebApi.Controllers
{
    [Authorize(Policy = "CityGuide")]
    [Route("api/[controller]")]

    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        // GET: api/CreateRoles 
        // [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        //// GET: api/CreateRoles/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        // POST: api/CreateRoles
        //Create a new Role into the Database and returns 400 if role already exist
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateRoleViewModel Role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = Role.RoleName
                };
                var roleexists = await _roleManager.RoleExistsAsync(Role.RoleName);
                if (!roleexists)
                {
                    await _roleManager.CreateAsync(identityRole);
                    return Ok();
                }
                else {
                    return BadRequest(new { message = "Role already exists" });
                        }
                
            }
            return BadRequest();
        }
        //}

        // PUT: api/CreateRoles/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE: api/ApiWithActions/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
    }
}
