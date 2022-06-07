using Services.AirlineBookingManagement.DbContexts;
using Services.AirlineBookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineBookingManagement.Repository
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        private readonly ApplicationDbContext _db;

        public FlightBookingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool BookFlight(BookingDetails bookingData)
        {
            if (bookingData != null)
            {
                bookingData.PNR = Guid.NewGuid().ToString();
                _db.BookingDetails.Add(bookingData);
                _db.SaveChanges();
                var BookedID = bookingData.BookingID;
                try
                {
                    foreach (var Item in bookingData.BookedSeatList)
                    {
                        Item.BookingNumber = BookedID;
                    }
                    _db.BookingSeatNumberRelation.AddRange(bookingData.BookedSeatList);
                    _db.SaveChanges();

                    foreach (var Item in bookingData.PassengerList)
                    {
                        Item.BookingRefNumber = BookedID;
                    }
                    _db.PassengerDetails.AddRange(bookingData.PassengerList);
                    _db.SaveChanges();
                }catch(Exception ex)
                {

                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CancelBookedFlight(string PNR)
        {
            if (PNR != null)
            {
                var _dbDetails = _db.BookingDetails.Where(x => x.PNR == PNR).FirstOrDefault();
                if (_dbDetails != null)
                {
                    _dbDetails.IsCancelled = true;
                    _db.BookingDetails.Update(_dbDetails);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
