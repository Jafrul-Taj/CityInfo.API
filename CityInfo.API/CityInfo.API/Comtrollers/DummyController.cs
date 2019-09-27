using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Comtrollers
{
    public class DummyController : Controller
    {
        private CityInfoContext Context;
        public DummyController(CityInfoContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}