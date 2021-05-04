using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Display(Name = "Service Date")]
        public DateTime ServiceDate { get; set; }
        public int Mileage { get; set; }
        [Display(Name = "Service Cost")]
        public decimal ServiceCost { get; set; }
        public string Notes { get; set; }
        
       // public List<ServiceItem> ServiceItems { get; set; }
        public List<CategoryItems> CategoryItems { get; set; }


    }
}
