using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class SeatTypes
    {
        [Key]
        public int SeatTypeID { get; set; }

        public string SeatType { get; set; }
    }
}
