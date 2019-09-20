using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Comtrollers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            //var temp = new JsonResult(CityDataStore.Current.Cities);
            //temp.StatusCode = 200;
            return Ok(new JsonResult(CityDataStore.Current.Cities));

        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
                
        }
    }
}