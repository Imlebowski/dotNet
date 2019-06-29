using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{

    [Route("api/theDude")]
    public class PointsOfInterestController : Controller
    {
        private IMailService mailService;
        private CityInfoContext ctx;
        public PointsOfInterestController(IMailService _mailService, CityInfoContext _ctx)
        {
            mailService = _mailService;
            ctx = _ctx;
        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult PostPointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxpointOfInterestId = city.PointsOfInterest.Count();

            var pointOfInterestToAdd = new PointOfInterestDto()
            {
                Id = ++maxpointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(pointOfInterestToAdd);

            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = maxpointOfInterestId }, pointOfInterestToAdd);
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpadtePointOfInterest(int cityId, int id, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestforStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == cityId);

            if (pointOfInterestforStore == null)
            {
                return NotFound();
            }

            pointOfInterestforStore.Name = pointOfInterest.Name;
            pointOfInterestforStore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PatchPointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForCreationDto> pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestforStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == cityId);

            if (pointOfInterestforStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToAdd = new PointOfInterestForCreationDto()
            {
                Name = pointOfInterestforStore.Name,
                Description = pointOfInterestforStore.Description
            };

            pointOfInterest.ApplyTo(pointOfInterestToAdd, ModelState);

            pointOfInterestforStore.Name = pointOfInterestToAdd.Name;
            pointOfInterestforStore.Description = pointOfInterestToAdd.Description;

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestforDelete = city.PointsOfInterest.FirstOrDefault(c => c.Id == cityId);

            if (pointOfInterestforDelete == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestforDelete);
            mailService.Send("Don't visit", pointOfInterestforDelete.Name);
            return NoContent();
        }
    }
}