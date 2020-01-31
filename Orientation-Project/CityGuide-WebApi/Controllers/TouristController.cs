using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CityGuide_WebApi.Data;
using CityGuide_WebApi.Models;
using CityGuide_WebApi.View_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityGuide_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public TouristController(IMapper mapper,ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // POST: api/Tourist 
        [Authorize(Roles = "Admin", Policy = "CityGuide")]
        [HttpPost]
        [Route("AddTourist")]
        public ActionResult Post([FromBody] AddTouristsEntryViewModel addTouristEntry)
        {
            try
            {
                string Name = _context.BaseTable.Where(item => item.Name == addTouristEntry.Name).Select(item => item.Name).FirstOrDefault();

                if (Name == null)
                {
                    BaseTable baseEntry = _mapper.Map<BaseTable>(addTouristEntry);
                    TouristsAmenities touristEntry = _mapper.Map<TouristsAmenities>(addTouristEntry);
                    baseEntry.CategoryId = 1;
                    var result =_context.BaseTable.Add(baseEntry);
                    _context.SaveChanges();

                    var getData =result.Entity;
                    Guid Id = getData.ID;
                    touristEntry.Id = Id;
                    _context.TouristsAmenities.Add(touristEntry);
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


        /* [HttpPut("{id}")]
         [Route("UpdateTouristEntities")]
         public ActionResult UpdateTouristEntities([FromBody] AddTouristsEntryViewModel updateToutrist)
         {
             if (ModelState.IsValid)
             {

             }
         }*/

        /*  [HttpDelete("{id}")]
          [Route("Deleteitems")]
          public IHttpActionResult Delete(int id)
          {
              if (id <= 0)
              {
                  return BadRequest("Not a valid id");
              }
          }*/

        [HttpGet]
        public ActionResult get([FromQuery] Guid baseId) {
            var row = _context.BaseTable.Find(baseId);
            if (row != null)
            {
                object amenities = _context.TouristsAmenities.FirstOrDefault(data => data.Id == baseId);
                if(amenities != null)
                {
                     var getTourists = _mapper.Map<AddTouristsEntryViewModel>(amenities);
                    amenities = getTourists;
                    return Ok(amenities);
                }
                else
                {
                    return Ok(row);
                }
               
            }
            else
                return BadRequest("No such entry found");
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            TouristsAmenities touristsAmenities = _context.TouristsAmenities.Find(id);
            if (touristsAmenities != null)
            {
                _context.TouristsAmenities.Remove(touristsAmenities);

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
