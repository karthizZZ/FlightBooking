using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineSeatCostRelation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RefID { get; set; }

        public int FlightID { get; set; }
        [ForeignKey("FlightID")]
        public virtual AirlineSchedule AirlineScheduleRef { get; set; }

        public int SeatTypeID { get; set; }
        [ForeignKey("SeatTypeID")]
        public virtual SeatTypes SeatType { get; set; }

        public int NoOfSeats { get; set; }

        public double TicketCost { get; set; }

        public double Tax { get; set; }
    }
}
