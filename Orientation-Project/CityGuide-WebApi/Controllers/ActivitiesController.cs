using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ActivitiesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public ActivitiesController(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

      
        


        // POST: api/Activities
        //[Authorize(Roles = "Admin", Policy = "CityGuide")]
        [HttpPost]
        [Route("AddActivities")]
        public ActionResult Post([FromBody] AddActivitiesAmenitiesViewModel addActivities)
        {
            try
            {
               string name  = _context.BaseTable.Where(item => item.Name == addActivities.Name).Select(item => item.Name).FirstOrDefault();

                if (name == null)
                {
                    BaseTable baseEntry = _mapper.Map<BaseTable>(addActivities);
                    ActivitiesAmenities activitiesAmenities = _mapper.Map<ActivitiesAmenities>(addActivities);
                    baseEntry.CategoryId = 2;
                    var result = _context.BaseTable.Add(baseEntry);
                    _context.SaveChanges();

                    var getData = result.Entity;
                    Guid Id = getData.ID;
                    activitiesAmenities.Id = Id;
                    _context.ActivitiesAmenities.Add(activitiesAmenities);
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


        // PUT: api/Activities/5
        [HttpPut("{id}")]
        [Route("UpdateActivitiesEntity")]
        public ActionResult Put([FromBody] AddActivitiesAmenitiesViewModel updateActivities, [FromQuery] Guid Id)
        {
            if (ModelState.IsValid)
            {
                if (updateActivities == null)
                {
                    return BadRequest();
                }
                BaseTable getBaseData = _context.BaseTable.FirstOrDefault(item => item.ID == Id);

                if (getBaseData == null)    
                {
                    return NotFound();
                }

                ActivitiesAmenities activitiesAmenities = _mapper.Map<ActivitiesAmenities>(updateActivities);
                BaseTable baseTable = _mapper.Map<BaseTable>(updateActivities);

                baseTable.ID = getBaseData.ID;
                activitiesAmenities.Id = getBaseData.ID;

                _context.Entry(baseTable).State = EntityState.Modified;
                _context.Entry(activitiesAmenities).State = EntityState.Modified;

                return Ok("Updated Successfull");
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            ActivitiesAmenities activitiesAmenities = _context.ActivitiesAmenities.Find(id);
            if (activitiesAmenities != null)
            {
                _context.ActivitiesAmenities.Remove(activitiesAmenities);

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
