using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineScheduleDayRelation
    {
        [Key]
        public int RefID { get; set; }

        public int AirlineScheduleID { get; set; }
        [ForeignKey("AirlineID")]
        public virtual AirlineSchedule AirlineSchedule { get; set; }

        public string weekDay { get; set; }
    }
}
