#nullable disable

using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentApi.Models;

public enum AppointmentStatuses
{
    Scheduled,
    [Display(Name = "In Progress")]
    InProgress,
    Completed,
    Cancelled
}

public class Appointment : ModelBase
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public DateTime AppointmentDateTime { get; set; }
    public AppointmentStatuses AppointmentStatus { get; set; }
        = AppointmentStatuses.Scheduled;
}
