using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide_WebApi.Models;
using CityGuide_WebApi.View_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CityGuide_WebApi.Controllers
{
    [Authorize(Policy = "CityGuide")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        
        [Authorize]
        [HttpGet]
        [Route("getUserProfile")]
        public async Task<Object> GetUserProfile() {
            string userid = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userid);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }


        [Authorize]
        [HttpPost]
        [Route("ChangePassword")]

        public async Task<Object> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.CurrentPassword))
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        return Ok(new { message = "Password Changed Successfully" });
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
        }


    }
}