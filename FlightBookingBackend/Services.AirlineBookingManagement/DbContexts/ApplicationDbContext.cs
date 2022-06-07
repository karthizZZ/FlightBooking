using Microsoft.EntityFrameworkCore;
using Services.AirlineBookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AirlineBookingManagement.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookingDetails> BookingDetails { get; set; }

        public DbSet<BookingPassengerRelation> PassengerDetails { get; set; }

        public DbSet<BookingSeatNoRelation> BookingSeatNumberRelation { get; set; }
    }
}
