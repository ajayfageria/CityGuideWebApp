using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityGuide_WebApi.Data;
using CityGuide_WebApi.Models;
using CityGuide_WebApi.Pagination;
using CityGuide_WebApi.View_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityGuide_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ApplicationContext _authenticationContext;
        private IMapper _mapper;

        public object _amenities { get; private set; }

        public BaseController(IMapper mapper, ApplicationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
            _mapper = mapper;
        }

        /// <summary>
        /// returns entity by using params: Place Name and Category Id
        /// </summary>
        /// <param name="PlaceName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetEntity")]
        public ActionResult GetEntity([FromQuery]string PlaceName, [FromQuery] int Id)
        {
            try
            {
                BaseTable row = _authenticationContext.BaseTable.Where(c => c.Name == PlaceName && c.CategoryId == Id).FirstOrDefault();
                if (row != null)
                {
                    Guid entityId = row.ID;

                    if (Id == 1)
                    {
                        AddTouristsEntryViewModel getTourists = new AddTouristsEntryViewModel();
                        _amenities = _authenticationContext.TouristsAmenities.FirstOrDefault(data => data.Id == entityId);
                        getTourists = _mapper.Map<AddTouristsEntryViewModel>(_amenities);
                        _amenities = getTourists;
                    }
                    else if (Id == 2)
                    {
                        AddActivitiesAmenitiesViewModel activities = new AddActivitiesAmenitiesViewModel();
                        _amenities = _authenticationContext.ActivitiesAmenities.FirstOrDefault(data => data.Id == entityId);
                        activities = _mapper.Map<AddActivitiesAmenitiesViewModel>(_amenities);
                        _amenities = activities;
                    }
                    else if (Id == 3)
                    {
                        AddFoodAmenitiesViewModel getFood = new AddFoodAmenitiesViewModel();
                        _amenities = _authenticationContext.FoodAmenities.FirstOrDefault(data => data.Id == entityId);
                        getFood = _mapper.Map<AddFoodAmenitiesViewModel>(_amenities);
                        _amenities = getFood;
                    }
                    else
                    {
                        AddAccommodationAmenitiesViewModel getAccommodation = new AddAccommodationAmenitiesViewModel();
                        _amenities = _authenticationContext.AccommodationAmenities.FirstOrDefault(data => data.Id == entityId);
                        getAccommodation = _mapper.Map<AddAccommodationAmenitiesViewModel>(_amenities);
                        _amenities = getAccommodation;
                    }
                    var images = _authenticationContext.EnitityImages.Where(c => c.EntityID == entityId).Select(d => d.Image).ToList();
                    List<Object> imageList = new List<Object>();
                    if (images != null)
                    {
                        foreach (byte[] image in images)
                        {
                            FileResult data = File(image, "image/png", $"Image");
                            imageList.Add(data);
                            //var base64 = Convert.ToBase64Strin g(image, 0, image.Length);
                            //var imgsrc = string.Format("data: image/png ; base64{0},",base64);
                            //imageList.Add(imgsrc);
                        }
                    }
                    var Result = new Dictionary<string, Object>();
                    Result.Add("Details", row);
                    Result.Add("Images", imageList);
                    Result.Add("Amenities", _amenities);

                    return Ok(Result);
                }
                else
                    return BadRequest(new { message = "No such entry in database" });
            }
            catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }


        // 


        /// <summary>
        ///  Get three entities and display on Home Page
        ///  GEt method to get all the entry int the database for a  specific category
        ///  Returns the name ,id and single image(if present or null) 
        ///  accepts a query parameter to depict the category id for Entity
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll/{id}")]
        public async Task<ActionResult> GetAllEntityValue(int? pageNumber, int? pageSize, int id) {
            try
            {
                var currentPageNumber = pageNumber ?? 1;
                var currentPageSize = pageSize ?? 3;
                var rows = await _authenticationContext.BaseTable.Where(c => c.CategoryId == id).Take(3).ToListAsync();

                List<Object> result = new List<object>();
                foreach (var row in rows) {
                    var image = await _authenticationContext.EnitityImages.Where(c => c.EntityID == row.ID).Select(d => d.Image).FirstOrDefaultAsync();
                    if (image != null)
                    {
                        var img = File(image, "image/png");
                        Dictionary<string, Object> EntryData = new Dictionary<string, object>();
                        EntryData.Add("name", row.Name);
                        EntryData.Add("id", row.ID);
                        EntryData.Add("image", img);
                        result.Add(EntryData);
                    }
                    else {
                        Dictionary<string, Object> EntryData = new Dictionary<string, object>();
                        EntryData.Add("name", row.Name);
                        EntryData.Add("id", row.ID);
                        EntryData.Add("image", null);
                        result.Add(EntryData);
                    }
                }
                return Ok(result);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Returns list of entity by Category Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EntityList/{id}")]
        public async Task<ActionResult> EntityList(int id)
        {
            try
            {
                var rows = await _authenticationContext.BaseTable.Where(c => c.CategoryId == id).ToListAsync();

                List<Object> result = new List<object>();
                foreach (var row in rows)
                {
                    var image = await _authenticationContext.EnitityImages.Where(c => c.EntityID == row.ID).Select(d => d.Image).FirstOrDefaultAsync();
                    if (image != null)
                    {
                        var img = File(image, "image/png");
                        Dictionary<string, Object> EntryData = new Dictionary<string, object>();
                        EntryData.Add("name", row.Name);
                        EntryData.Add("id", row.ID);
                        EntryData.Add("image", img);
                        result.Add(EntryData);
                    }
                    else
                    {
                        Dictionary<string, Object> EntryData = new Dictionary<string, object>();
                        EntryData.Add("name", row.Name);
                        EntryData.Add("id", row.ID);
                        EntryData.Add("image", null);
                        result.Add(EntryData);
                    }
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //creating the api method for the search bar in the ui
        //created by Ugain Jain for the task "new method for search api"
        //expects a searchString of type string to be saerched
        //expects a get request and return 200 with the list of dictionaries of the result if found else returns message "No search result found" with 200
        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult> SearchBox([FromQuery] string searchString) {
            try
            {
                var rows = await _authenticationContext.BaseTable.Where(c => c.Name.Contains(searchString)).ToListAsync();
                if (rows != null)
                {
                    return Ok(rows);
                }
                else
                    return Ok(new { message = "No search results found"});
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }

    }
        
  
}
