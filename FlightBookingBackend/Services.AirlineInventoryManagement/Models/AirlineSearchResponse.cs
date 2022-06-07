using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Models
{
    public class AirlineSearchResponse
    {
        public string AirlineName { get; set; }

        public int FlightNo { get; set; }

        public DateTime AvailableDate { get; set; }

        public double TicketCost { get; set; }
    }
}
