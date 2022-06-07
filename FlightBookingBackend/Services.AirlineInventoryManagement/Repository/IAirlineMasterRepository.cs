using Services.AirlineInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Repository
{
    public interface IAirlineMasterRepository
    {
        bool AddNewAirlineBrand(AirlineBrand objBrand);

        bool UpdateAirlineBrand(AirlineBrand objBrand);

        bool DeleteAirlineBrand(int AirlineBrandID);

        List<AirlineBrand> GetAirlineBrandList();
        

        bool AddNewAirlineCompany(AirlineCompany CompanyData);

        bool UpdateAirlineCompany(AirlineCompany CompanyData);

        bool DeleteAirlineCompany(int AirlineCompanyID);

        List<AirlineCompany> GetAirlineCompanyList();


        bool AddNewAirlineInstrument(ArlineInstrument InstrumentData);

        bool UpdateAirlineInstrument(ArlineInstrument InstrumentData);

        bool DeleteAirlineInstrument(int AirlineInstrumentID);

        List<ArlineInstrument> GetAirlineInstrumentList();


        bool AddNewAirport(Airport AirportData);

        bool UpdateAirportDetails(Airport AirportData);

        bool DeleteAirport(int AirportID);

        List<Airport> GetAirportList();

        bool AddNewSeatType(SeatTypes SeatTypeData);

        bool UpdateSeatTypeDetails(SeatTypes SeatTypeData);

        bool DeleteSeatType(int SeatTypeID);

        List<SeatTypes> GetSeatTypeList();
    }
}
