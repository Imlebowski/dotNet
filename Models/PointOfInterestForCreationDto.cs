using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {   
        [Required]
        public string Name { get; set; }
        
        // [Required(ErrorMessage = "Description is required")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}