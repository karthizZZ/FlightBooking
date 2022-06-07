using Services.AirlineBookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineBookingManagement.Repository
{
    public interface IFlightBookingRepository
    {
        bool BookFlight(BookingDetails bookingData);

        bool CancelBookedFlight(string PNR);
    }
}
