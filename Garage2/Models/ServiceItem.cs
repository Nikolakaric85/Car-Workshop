using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class ServiceItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Item { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public List<CategoryItems> CategoryItems { get; set; }

    }
}
