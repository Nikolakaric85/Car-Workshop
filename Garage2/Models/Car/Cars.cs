using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models.Car
{
    public class Cars
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Range(4,4, ErrorMessage = "Please insert correct year")]
        public int Year { get; set; }
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        [Display(Name = "Engine displacement")]
        public int EngineDisplacement { get; set; }
        [Display(Name = "Engine power")]
        public int EnginePower { get; set; }
        [Display(Name = "VIN number")]
        public string VinNumber { get; set; }
        [Display(Name = "Chassis number")]
        public string ChassisNumber { get; set; }
        public int ServicesId { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Licence plate")]
        public string LicencePlate { get; set; }
        [Display(Name = "Active car")]
        public bool IsActive { get; set; }
    }
}
