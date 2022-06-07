using Microsoft.AspNetCore.Mvc;
using Services.AirlineInventoryManagement.Models;
using Services.AirlineInventoryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Controllers
{
    [ApiController]
    [Route("api/master")]
    public class MasterManagementController : ControllerBase
    {
        private readonly IAirlineMasterRepository _airlineMaster;

        public MasterManagementController(IAirlineMasterRepository airlineMaster)
        {
            _airlineMaster = airlineMaster;
        }

        [HttpPost("AddNewBrand")]
        public bool AddNewBrand(AirlineBrand brandData)
        {
            bool IsSuccess = _airlineMaster.AddNewAirlineBrand(brandData);
            return IsSuccess;
        }

        [HttpPost("AddNewCompany")]
        public bool AddNewCompany(AirlineCompany companyData)
        {
            bool IsSuccess = _airlineMaster.AddNewAirlineCompany(companyData);
            return IsSuccess;
        }

        [HttpPost("AddNewInstrument")]
        public bool AddNewInstrument(ArlineInstrument instrumentData)
        {
            bool IsSuccess = _airlineMaster.AddNewAirlineInstrument(instrumentData);
            return IsSuccess;
        }

        [HttpPost("AddNewAirport")]
        public bool AddNewAirport(Airport airportData)
        {
            bool IsSuccess = _airlineMaster.AddNewAirport(airportData);
            return IsSuccess;
        }

        [HttpPost("AddNewSeatType")]
        public bool AddNewSeatType(SeatTypes seatTypeData)
        {
            bool IsSuccess = _airlineMaster.AddNewSeatType(seatTypeData);
            return IsSuccess;
        }
    }
}
