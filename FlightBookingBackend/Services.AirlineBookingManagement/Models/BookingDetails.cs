using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineBookingManagement.Models
{
    public class BookingDetails
    {
        [Key]
        public int BookingID { get; set; }

        public int AirlineID { get; set; }

        public int FlightNumber { get; set; }

        public string AirlineName { get; set; }

        public DateTime BookingDate { get; set; }

        public bool MealOpted { get; set; }

        public int NoOfPassengers { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string SeatType { get; set; }

        public string PNR { get; set; }

        public string PaymentStatus { get; set; }

        public bool IsCancelled { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<BookingPassengerRelation> PassengerList { get; set; }

        public List<BookingSeatNoRelation> BookedSeatList { get; set; }
    }
}
