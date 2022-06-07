using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineBookingManagement.Models
{
    public class BookingSeatNoRelation
    {
        [Key]
        public int RefID { get; set; }

        public int BookingNumber { get; set; }
        [ForeignKey("BookingNumber")]
        public virtual BookingDetails BookingDetailsRef { get; set; }

        public int SeatNumber { get; set; }
    }
}
