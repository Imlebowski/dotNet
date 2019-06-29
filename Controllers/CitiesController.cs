using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/theDude")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new CityDto()
            {
                Id = 1,
                Name = "Bengaluru",
                Description = "Garden City"
            });
        }

        [Route("{id}")]
        [HttpGet]
        public JsonResult GetCity(int CityID)
        {
            return new JsonResult(new
            {
                Id = 1,
                Name = "Bengaluru",
                Desc = "Garden City"
            });
        }
    }
}