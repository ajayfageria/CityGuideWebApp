using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CityGuide_WebApi.Data;
using CityGuide_WebApi.Models;
using CityGuide_WebApi.View_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityGuide_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public FoodController(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        
        // POST: api/Food
        [Authorize(Roles = "Admin", Policy = "CityGuide")]
        [HttpPost]
        [Route("AddFood")]
        public ActionResult Post([FromBody]  AddFoodAmenitiesViewModel addFood)
        {
            try
            {
                string Name = _context.BaseTable.Where(item => item.Name == addFood.Name).Select(item=> item.Name).FirstOrDefault();

                if (Name == null)
                {
                    BaseTable baseEntry = _mapper.Map<BaseTable>(addFood);
                    FoodAmenities foodAmenities = _mapper.Map<FoodAmenities>(addFood);
                    baseEntry.CategoryId = 3;
                    var result = _context.BaseTable.Add(baseEntry);
                    _context.SaveChanges();

                    var getData = result.Entity;
                    Guid Id = getData.ID;
                    foodAmenities.Id = Id;
                    _context.FoodAmenities.Add(foodAmenities);
                    _context.SaveChanges();
                }
                else
                {
                    return BadRequest("Failed to Add Duplicate Data");
                }
            }
            catch (Exception )
            {
                return BadRequest("Failed to Add Accomodation Data");
            }
            return Ok("Successfully Posted");
        }

        // PUT: api/Food/5
        [HttpPut("{id}")]
        [Route("UpdateFoodEntitiy")]
        public ActionResult Put([FromBody] AddFoodAmenitiesViewModel updateFood, [FromQuery] Guid Id)
        {
            if (ModelState.IsValid)
            {
                if (updateFood == null)
                {
                    return BadRequest();
                }
                BaseTable getBaseData = _context.BaseTable.FirstOrDefault(item => item.ID == Id);

                if (getBaseData == null)
                {
                    return NotFound();
                }

                FoodAmenities foodAmenities = _mapper.Map<FoodAmenities>(updateFood);
                BaseTable baseTable = _mapper.Map<BaseTable>(updateFood);
                
                baseTable.ID = getBaseData.ID;
                foodAmenities.Id = getBaseData.ID;
                
                _context.Entry(baseTable).State = EntityState.Modified;
                _context.Entry(foodAmenities).State = EntityState.Modified;

                return Ok("Updated Successfull");
            }
            return BadRequest();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            FoodAmenities foodAmenities = _context.FoodAmenities.Find(id);
            if (foodAmenities != null)
            {
                _context.FoodAmenities.Remove(foodAmenities);

                EntityImages entityImages = _context.EnitityImages.Find(id);
                if (entityImages != null)
                {
                    _context.EnitityImages.Remove(entityImages);

                    BaseTable baseData = _context.BaseTable.Find(id);

                    if (baseData != null)
                    {
                        _context.BaseTable.Remove(baseData);

                    }
                }
            }
        }
    }
}
