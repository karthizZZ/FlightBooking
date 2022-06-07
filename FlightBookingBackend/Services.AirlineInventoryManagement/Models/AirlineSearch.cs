using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineSearch
    {
        public int FromLocation { get; set; }

        public int ToLocation { get; set; }

        public DateTime FlightTime { get; set; }

        public int SeatType { get; set; }

        public int TripType { get; set; }
    }
}
