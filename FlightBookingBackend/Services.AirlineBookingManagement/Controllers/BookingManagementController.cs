using Microsoft.AspNetCore.Mvc;
using Services.AirlineBookingManagement.Models;
using Services.AirlineBookingManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineBookingManagement.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingManagementController : ControllerBase
    {
        private readonly IFlightBookingRepository _bookingRepository;

        public BookingManagementController(IFlightBookingRepository __bookingRepository)
        {
            _bookingRepository = __bookingRepository;
        }

        [HttpPost("BookFlight")]
        public bool BookFlight(BookingDetails bookingData)
        {
            bool IsSuccess = _bookingRepository.BookFlight(bookingData);
            return IsSuccess;
        }

        [HttpPost("CancelBooking")]
        public bool CancelBooking(string PNR)
        {
            bool IsSuccess = _bookingRepository.CancelBookedFlight(PNR);
            return IsSuccess;
        }
    }
}
