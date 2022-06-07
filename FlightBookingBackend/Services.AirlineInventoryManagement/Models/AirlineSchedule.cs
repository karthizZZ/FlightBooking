using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineSchedule
    {
        [Key]
        public int AirlineID { get; set; }

        public int FlightNumber { get; set; }

        public int AirlineBrand { get; set; }
        [ForeignKey("AirlineBrand")]
        public virtual AirlineBrand AirlineBrandRef { get; set; }

        public int AirlineInstrument { get; set; }
        [ForeignKey("AirlineInstrument")]
        public virtual ArlineInstrument AirlineInstrumentRef { get; set; }

        public int AirlineCompany { get; set; }
        [ForeignKey("AirlineCompany")]
        public virtual AirlineCompany AirlineCompanyRef { get; set; }

        public int? FromLocation { get; set; }
        [ForeignKey("FromLocation")]
        public virtual Airport AirportFrom { get; set; }

        public int? ToLocation { get; set; }
        [ForeignKey("ToLocation")]
        public virtual Airport AirportTo { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public string mealType { get; set; }

        public bool IsDaily { get; set; }

        public bool IsWeekly { get; set; }

        public bool IsWeekends { get; set; }

        public bool IsSpecificDays { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public List<AirlineSeatCostRelation> lstAirlineSeatCost { get; set; }

        public List<AirlineScheduleDayRelation> lstAirlineScheduleDay { get; set; }

    }
}
