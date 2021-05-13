using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        [Display(Name = "Service Date")]
        [Column(TypeName = "datetime")]
        public DateTime ServiceDate { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        [Display(Name = "Service Cost")]
        public decimal ServiceCost { get; set; }
        public string Notes { get; set; }

        public int CarId { get; set; }
        
       // public List<ServiceItem> ServiceItems { get; set; }
        public List<CategoryItems> CategoryItems { get; set; }


    }
}
