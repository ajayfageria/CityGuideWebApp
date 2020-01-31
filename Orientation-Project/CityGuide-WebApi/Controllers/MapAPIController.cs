//using System;
//using System.Collections.Generic;
//using System.Linq;
//using CityGuide_WebApi.Data;
//using CityGuide_WebApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using Nest;


//namespace CityGuide_WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MapAPIController : ControllerBase
//    {
//        private ApplicationContext _context;

//        public MapAPIController(ApplicationContext applicationContext)
//        {
//            _context = applicationContext;


//        }
//        [HttpGet]
//        [Route("MyPlaces")]
       
//             public IEnumerable<DistanceModel> GetPlacesOnMyLocation([FromQuery] double currentLatitude, [FromQuery] double currentLongitude)
//              {
//            var sourcePoint = string.Format("POINT({0} {1})", currentLongitude.ToString().Replace(',', '.'), currentLatitude.ToString().Replace(',', '.'));
//            var origin = DbGeography.PointFromText(sourcePoint, 4326);

          
//            List<DistanceModel> Caldistance = new List<DistanceModel>();
//                  var query = (from c in _context.BaseTable
//                               let BaseL= PointFromText(string.Format("POINT({0} {1})", c.Longitude,c.Latitude))
//                               where BaseL.Distance(origin)<=10
//                               select c).ToList();
//                  foreach (var place in query)
//            {
              
//                GeoCoordinate startingPoint = new GeoCoordinate(currentLatitude, currentLongitude);
//                GeoCoordinate endingPoint = new GeoCoordinate(place.Latitude, place.Longitude);

//                double distance = Distance(currentLatitude, currentLongitude, place.Latitude, place.Longitude);
//           // double distance= startingPoint.GetDistanceTo(endingPoint);

//                if (distance >22 && distance <25)          //nearbyplaces in  km
//                      {
//                          DistanceModel dist = new DistanceModel();
//                          dist.Name = place.Name;
//                          dist.Latitute =  place.Latitude;
//                          dist.Longitude = place.Longitude;
//                          dist.DistanceFromCurrentlocation = distance;
//                          dist.PlaceId = place.ID;
//                          yield return dist;
//                      }
//                  }


//              }

//            private double Distance(double lat1, double lon1, double lat2, double lon2)
//        {
//            double theta = lon1 - lon2;
//            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
//            dist = Math.Acos(dist);
//            dist = rad2deg(dist);
//            dist = (dist * 60 * 1.1515) / 0.6213711922;          //miles to kms


//            return (dist);
//        }

//        private double deg2rad(double deg)
//        {
//            return (deg * Math.PI / 180.0);
//        }

//        private double rad2deg(double rad)
//        {
//            return (rad * 180.0 / Math.PI);
//        }


//        // GET: api/MapAPI
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET: api/MapAPI/5
//        [HttpGet("{id}", Name = "Get")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST: api/MapAPI
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT: api/MapAPI/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
