using Services.AirlineInventoryManagement.DbContexts;
using Services.AirlineInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Repository
{
    public class AirlineManagementRepository : IAirlineManagementRepository
    {
        private readonly ApplicationDbContext _db;

        public AirlineManagementRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddNewAirlineSchedule(AirlineSchedule airlineScheduleData)
        {
            if (airlineScheduleData != null)
            {
                _db.AirlineSchedule.Add(airlineScheduleData);
                _db.SaveChanges();

                int AirlineNO = airlineScheduleData.AirlineID;
                foreach (var item in airlineScheduleData.lstAirlineSeatCost)
                {
                    item.FlightID = AirlineNO;
                }
                try
                {
                    _db.AirlineSeatCostRelation.AddRange(airlineScheduleData.lstAirlineSeatCost);
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

        public AirlineSearchResponse AirlineSearch(AirlineSearch SearchInput)
        {
            AirlineSearchResponse result1 = new AirlineSearchResponse();
            var result = from person in _db.AirlineSchedule
                         join detail in _db.AirlineBrand on person.AirlineBrand equals detail.AirlineBrandID into Details
                         from m in Details.DefaultIfEmpty()
                         join company in _db.AirlineComapny on person.AirlineCompany equals company.AirlineCompanyID
                         join Instrument in _db.AirlineInstrument on person.AirlineInstrument equals Instrument.AirlineInstrumentID
                         join ticketcost in _db.AirlineSeatCostRelation on person.AirlineID equals ticketcost.FlightID
                         where person.IsDaily == true && person.IsBlocked==false && ticketcost.SeatTypeID == SearchInput.SeatType
                         && person.FromLocation == SearchInput.FromLocation && person.ToLocation == SearchInput.ToLocation
                         select new
                         {
                             AirlineName = company.CompanyName + " " +  m.BrandName + " " + Instrument.InstrumentName,
                             FlightNo = person.FlightNumber,
                             TicketCost = ticketcost.TicketCost + ticketcost.Tax
                         };
            var jj=result.ToList();
           foreach(var item in jj)
            {
                result1.AirlineName = item.AirlineName;
                result1.AvailableDate = SearchInput.FlightTime;
                result1.FlightNo = item.FlightNo;
                result1.TicketCost = item.TicketCost;
            }
            return result1;
        }

        public bool BlockAirline(int AirlineID)
        {
            if (AirlineID != 0)
            {
                var _dbItem = _db.AirlineSchedule.Where(x => x.AirlineID == AirlineID).FirstOrDefault();
                if (_dbItem != null)
                {
                    _dbItem.IsBlocked = true;
                    _db.AirlineSchedule.Update(_dbItem);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
