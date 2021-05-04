using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class CategoryItems
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Items { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int ServiceId { get; set; }
        public ServiceItem ServiceItem { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public Service Service { get; set; }

    }
}

