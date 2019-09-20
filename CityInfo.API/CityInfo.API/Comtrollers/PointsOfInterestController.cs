using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Comtrollers
{
    [ApiController]
    [Route("api/cities")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id==cityId);

            if(city==null)
            {
                return NotFound();
            }
            return Ok(city.PointOfInterests);
        }
        [HttpGet("{cityId}/pointsOfInterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(p => p.Id == id);
            if(pointOfInterest==null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

    }
}