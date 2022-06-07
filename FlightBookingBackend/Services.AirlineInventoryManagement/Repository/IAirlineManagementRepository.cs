using Services.AirlineInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Repository
{
    public interface IAirlineManagementRepository
    {
        bool AddNewAirlineSchedule(AirlineSchedule airlineScheduleData);

        AirlineSearchResponse AirlineSearch(AirlineSearch SearchInput);

        bool BlockAirline(int AirlineID);
    }
}
