using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //[PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    [PrimaryKey(nameof(Id))]
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
