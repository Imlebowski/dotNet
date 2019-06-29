using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/theDude")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public ActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [Route("{cityID}")]
        [HttpGet]
        public ActionResult GetCity(int CityID)
        {
           var cityToReturn = CitiesDataStore.Current.Cities.Where(c => c.Id == CityID).FirstOrDefault();
           if (cityToReturn == null ) {
               return null;
           }
           return Ok(cityToReturn);
        }
    }
}