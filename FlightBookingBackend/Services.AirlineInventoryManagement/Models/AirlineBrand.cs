using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineBrand
    {
        [Key]
        public int AirlineBrandID { get; set; }

        public string BrandName { get; set; }
    }
}
