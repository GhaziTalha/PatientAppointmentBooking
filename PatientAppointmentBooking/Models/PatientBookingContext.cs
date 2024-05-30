using System.Collections.Generic;
using System.Data.Entity;

namespace PatientAppointmentBooking.Models
{
    public class PatientBookingContext : DbContext
    {
        public PatientBookingContext() : base("PatientBookingContext")
        {
        }

        public DbSet<PatientBooking> PatientBookings { get; set; }
    }
}
