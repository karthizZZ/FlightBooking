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
    [Route("api/airline")]
    public class AirlineManagementController : ControllerBase
    {
        private readonly IAirlineManagementRepository _airlineManagement;

        public AirlineManagementController(IAirlineManagementRepository airlineManagement)
        {
            _airlineManagement = airlineManagement;
        }

        [HttpPost("AddNewAirlineSchedule")]
        public bool AddNewAirlineSchedule(AirlineSchedule airlineScheduleData)
        {
            bool IsSuccess = _airlineManagement.AddNewAirlineSchedule(airlineScheduleData);
            return true;
        }

        [HttpPost("SearchAirline")]
        public AirlineSearchResponse AirlineSearch(AirlineSearch SearchInput)
        {
            var result = new AirlineSearchResponse();
            result = _airlineManagement.AirlineSearch(SearchInput);
            return result;
        }

        [HttpGet("BlockAirline")]
        public bool BlockAirline(int AirlineID)
        {
            bool IsSuccess = _airlineManagement.BlockAirline(AirlineID);
            return IsSuccess;
        }
    }
}
