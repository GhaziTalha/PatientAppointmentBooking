using System;
using System.ComponentModel.DataAnnotations;

namespace PatientAppointmentBooking.Models
{
    public class PatientBooking
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [Phone]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string AppointmentSlot { get; set; }
    }
}
