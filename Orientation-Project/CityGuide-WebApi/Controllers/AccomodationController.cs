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
    public class AccomodationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public AccomodationController(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // POST: api/Accomodation
        [HttpPost]
        [Authorize(Roles = "Admin",Policy ="CityGuide")]
        [Route("AddAccommodation")]
        public ActionResult Post([FromBody] AddAccommodationAmenitiesViewModel addAccommodation )
        {
            try{ 
                
                string Name =_context.BaseTable.Where(item => item.Name == addAccommodation.Name).Select(item => item.Name).FirstOrDefault();
                
                if(Name == null)
                {
                    BaseTable baseEntry = _mapper.Map<BaseTable>(addAccommodation);
                    AccommodationAmenities accommodationAmenities = _mapper.Map<AccommodationAmenities>(addAccommodation);
                    
                    baseEntry.CategoryId = 4;
                    
                    var result = _context.BaseTable.Add(baseEntry);
                    _context.SaveChanges();
                    
                    BaseTable getData = result.Entity;
                    Guid Id = getData.ID;
                    accommodationAmenities.Id = Id;
                    
                    _context.AccommodationAmenities.Add(accommodationAmenities);
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

        // PUT: api/Accomodation/5
        [HttpPut()]
        [Route("UpdateAccommodationEntity")]
        public ActionResult Put([FromBody] AddAccommodationAmenitiesViewModel updateAccommodation, [FromQuery] Guid Id)
        {
            if (ModelState.IsValid)
            {
                if (updateAccommodation == null)
                {
                    return BadRequest();
                }
                BaseTable getBaseData = _context.BaseTable.FirstOrDefault(item => item.ID == Id);

                if (getBaseData == null)
                {
                    return NotFound();
                }

                AccommodationAmenities accommodationAmenities = _mapper.Map<AccommodationAmenities>(updateAccommodation);
                BaseTable baseTable = _mapper.Map<BaseTable>(updateAccommodation);

                baseTable.ID = getBaseData.ID;
                accommodationAmenities.Id = getBaseData.ID;

                _context.Entry(baseTable).State = EntityState.Modified;
                _context.Entry(accommodationAmenities).State = EntityState.Modified;

                return Ok("Updated Successfull");
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            AccommodationAmenities accommodationAmenities = _context.AccommodationAmenities.Find(id);
            if(accommodationAmenities != null)
            {
                _context.AccommodationAmenities.Remove(accommodationAmenities);

                EntityImages entityImages = _context.EnitityImages.Find(id);
                if( entityImages != null)
                {
                    _context.EnitityImages.Remove(entityImages);
               
                    BaseTable baseData =_context.BaseTable.Find(id);
                
                    if(baseData != null)
                    {
                       _context.BaseTable.Remove(baseData);
                    
                    }
                }    
            }
        }
    }
}
