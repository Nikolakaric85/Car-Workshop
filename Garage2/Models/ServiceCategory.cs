using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class ServiceCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "Service Category")]
        public string Category { get; set; }
       
        public List<CategoryItems> CategoryItems { get; set; }
        


    }
}
