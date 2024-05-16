#nullable disable

using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentApi.Models;

public enum Specializations
{
    [Display(Name = "General Practitioner")]
    GeneralPractitioner,
    Cardiologist,
    Dermatologist,
    Pediatrician,
    Neurologist,
    Gynecologist,
    [Display(Name = "Orthopedic Surgeon")]
    OrthopedicSurgeon,
    Psychiatrist,
    Ophthalmologist,
    Oncologist,
    [Display(Name = "ENT Specialist")]
    EntSpecialist,
    Urologist,
    Endocrinologist,
    Pulmonologist,
    Nephrologist
}

public class Doctor : ModelBase
{
    [Required]
    [MaxLength(64, ErrorMessage = "Name cannot be more than 64 characters.")]
    public string Name { get; set; }

    [Required]
    public Specializations Specialization { get; set; }

    // E.164 International Telephone Number Format
    [Required]
    [RegularExpression(@"^\+\d{1,3}\d{5,15}$",
        ErrorMessage = "Invalid contact number format provided.")]
    [MaxLength(20,
        ErrorMessage = "Contact number cannot be more tha 20 characters.")]
    public string ContactNumber { get; set; }

    [Required]
    [Range(0, 100)]
    public byte Experience { get; set; }

    public List<Appointment> Appointments { get; set; }

    /*
     * public IEnumerable<Appointment> ScheduledAppointments => Appointments.Where(
     *     appointmentAtIndex
     *         => appointmentAtIndex.AppointmentStatus == AppointmentStatuses.Scheduled
     * );
    */
}
