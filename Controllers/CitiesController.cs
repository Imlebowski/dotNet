using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    public class CitiesController : Controller
    {
        [Route("api/theDude")]
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new {
                Id = 1,
                Name = "Bengaluru",
                Desc = "Garden City"
            }); 
        }
    }
}