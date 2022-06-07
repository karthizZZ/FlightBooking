using Microsoft.EntityFrameworkCore;
using Services.AirlineInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineInventoryManagement.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Airport> Airport { get; set; }

        public DbSet<AirlineBrand> AirlineBrand { get; set; }

        public DbSet<AirlineCompany> AirlineComapny { get; set; }

        public DbSet<ArlineInstrument> AirlineInstrument { get; set; }

        public DbSet<SeatTypes> SeatType { get; set; }

        public DbSet<AirlineSchedule> AirlineSchedule { get; set; }

        public DbSet<AirlineScheduleDayRelation> AirlineScheduleDayRelation { get; set; }

        public DbSet<AirlineSeatCostRelation> AirlineSeatCostRelation { get; set; }
    }
}
