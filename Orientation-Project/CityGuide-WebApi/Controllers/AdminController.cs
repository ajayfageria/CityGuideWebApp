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
    //Created By UgainJain for the issue implementation of authorization in the currently hosted web api #12
    //Controller for the task for the admin 

    [Authorize(Roles = "Admin")]
    [Authorize(Policy = "CityGuide")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSetting;
        public AdminController(UserManager<ApplicationUser> userManager, ApplicationSettings appSetting)
        {
            _userManager = userManager;
            _appSetting = appSetting;
        }
        
        
        
        // GET:  All Admins
        //Method assigned to get all the users assigned the task of Admins
        [HttpGet]
        [Route("GetAll")]
        public async Task<Object> GetAllAdmins()
        {
            var userList = await _userManager.GetUsersInRoleAsync("Admin");
            var Users = new List<Dictionary<string,string>>();
            if(userList!= null)
            foreach (var user in userList)
            {
                var value = new Dictionary<string, string>();
                value.Add("UserId", user.Id);
                value.Add("FullName", user.FullName);
                value.Add("Email", user.Email);
                Users.Add(value);
            }
            return Ok(new { Users });
            { 
            }
        }    


       
        [HttpPost]
        
        [Route("RegisterAdmin")]
        public async Task<Object> RegisterAdmin(ApplicationUserViewModel model)

        {
            model.Role = "Admin";
            var applicationUser = new ApplicationUser()
            {

                UserName = model.UserName,

                Email = model.Email,

                FullName = model.FullName

            };
            try

            {

                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);

                return Ok(result);

            }

            catch (Exception ex)

            {



                throw ex;

            }

        }
        
    }
}