using Microsoft.EntityFrameworkCore;
using Services.AirlineInventoryManagement.DbContexts;
using Services.AirlineInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.Repository
{
    public class AirlineMasterRepository : IAirlineMasterRepository
    {
        private readonly ApplicationDbContext _db;

        public AirlineMasterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddNewAirlineBrand(AirlineBrand objBrand)
        {
            if (objBrand != null)
            {
                _db.AirlineBrand.Add(objBrand);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewAirlineCompany(AirlineCompany CompanyData)
        {
            if (CompanyData != null)
            {
                _db.AirlineComapny.Add(CompanyData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewAirlineInstrument(ArlineInstrument InstrumentData)
        {
            if (InstrumentData != null)
            {
                _db.AirlineInstrument.Add(InstrumentData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewAirport(Airport AirportData)
        {
            if (AirportData != null)
            {
                _db.Airport.Add(AirportData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewSeatType(SeatTypes SeatTypeData)
        {
            if (SeatTypeData != null)
            {
                _db.SeatType.Add(SeatTypeData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAirlineBrand(int AirlineBrandID)
        {
            if (AirlineBrandID != 0)
            {
                var dbData = _db.AirlineBrand.FirstOrDefault(x => x.AirlineBrandID == AirlineBrandID);
                _db.AirlineBrand.Remove(dbData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAirlineCompany(int AirlineCompanyID)
        {
            if (AirlineCompanyID != 0)
            {
                var dbData = _db.AirlineComapny.FirstOrDefault(x => x.AirlineCompanyID == AirlineCompanyID);
                _db.AirlineComapny.Remove(dbData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAirlineInstrument(int AirlineInstrumentID)
        {
            if (AirlineInstrumentID != 0)
            {
                var dbData = _db.AirlineInstrument.FirstOrDefault(x => x.AirlineInstrumentID == AirlineInstrumentID);
                _db.AirlineInstrument.Remove(dbData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAirport(int AirportID)
        {
            if (AirportID != 0)
            {
                var dbData = _db.Airport.FirstOrDefault(x => x.AirportID == AirportID);
                _db.Airport.Remove(dbData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSeatType(int SeatTypeID)
        {
            if (SeatTypeID != 0)
            {
                var dbData = _db.SeatType.FirstOrDefault(x => x.SeatTypeID == SeatTypeID);
                _db.SeatType.Remove(dbData);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AirlineBrand> GetAirlineBrandList()
        {
            var lstAirlineBrand = _db.AirlineBrand.ToList();
            return lstAirlineBrand;
        }

        public List<AirlineCompany> GetAirlineCompanyList()
        {
            var lstAirlineCompany = _db.AirlineComapny.ToList();
            return lstAirlineCompany;
        }

        public List<ArlineInstrument> GetAirlineInstrumentList()
        {
            var lstAirlineInstrument = _db.AirlineInstrument.ToList();
            return lstAirlineInstrument;
        }

        public List<Airport> GetAirportList()
        {
            var lstAirports = _db.Airport.ToList();
            return lstAirports;
        }

        public List<SeatTypes> GetSeatTypeList()
        {
            var lstSeatTypes = _db.SeatType.ToList();
            return lstSeatTypes;
        }

        public bool UpdateAirlineBrand(AirlineBrand objBrand)
        {
            if (objBrand.AirlineBrandID != 0)
            {
                var dbData = _db.AirlineBrand.AsNoTracking().FirstOrDefault(x => x.AirlineBrandID == objBrand.AirlineBrandID);
                if (dbData != null)
                {
                    _db.AirlineBrand.Update(objBrand);
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

        public bool UpdateAirlineCompany(AirlineCompany CompanyData)
        {

            if (CompanyData.AirlineCompanyID != 0)
            {
                var dbData = _db.AirlineComapny.AsNoTracking().FirstOrDefault(x => x.AirlineCompanyID == CompanyData.AirlineCompanyID);
                if (dbData != null)
                {
                    _db.AirlineComapny.Update(CompanyData);
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

        public bool UpdateAirlineInstrument(ArlineInstrument InstrumentData)
        {
            if (InstrumentData.AirlineInstrumentID != 0)
            {
                var dbData = _db.AirlineInstrument.AsNoTracking().FirstOrDefault(x => x.AirlineInstrumentID == InstrumentData.AirlineInstrumentID);
                if (dbData != null)
                {
                    _db.AirlineInstrument.Update(InstrumentData);
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

        public bool UpdateAirportDetails(Airport AirportData)
        {
            if (AirportData.AirportID != 0)
            {
                var dbData = _db.Airport.AsNoTracking().FirstOrDefault(x => x.AirportID == AirportData.AirportID);
                if (dbData != null)
                {
                    _db.Airport.Update(AirportData);
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

        public bool UpdateSeatTypeDetails(SeatTypes SeatTypeData)
        {
            if (SeatTypeData.SeatTypeID != 0)
            {
                var dbData = _db.SeatType.AsNoTracking().FirstOrDefault(x => x.SeatTypeID == SeatTypeData.SeatTypeID);
                if (dbData != null)
                {
                    _db.SeatType.Update(SeatTypeData);
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
