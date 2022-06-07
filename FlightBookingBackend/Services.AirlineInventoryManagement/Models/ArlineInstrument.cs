using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class ArlineInstrument
    {
        [Key]
        public int AirlineInstrumentID { get; set; }

        public string InstrumentName { get; set; }
    }
}
