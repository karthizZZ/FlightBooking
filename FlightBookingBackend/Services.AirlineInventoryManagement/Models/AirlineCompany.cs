using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineCompany
    {
        [Key]
        public int AirlineCompanyID { get; set; }

        public string CompanyName { get; set; }
    }
}
