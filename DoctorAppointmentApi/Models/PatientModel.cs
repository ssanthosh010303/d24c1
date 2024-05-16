# nullable disable

using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentApi.Models;

public enum Genders
{
    Male,
    Female,
    [Display(Name = "Attack Helicopter 🚁")]
    AttackHelicopter,
    [Display(Name = "Blast Furnace 🔥")]
    BlastFurnace
}

public class Patient : ModelBase
{
    [Required]
    [MaxLength(64, ErrorMessage = "Name cannot be more than 64 characters.")]
    public string Name { get; set; }

    [Required]
    [Range(1, 150, ErrorMessage = "Age cannot be less than 0 and more than 150.")]
    public byte Age { get; set; }

    public Genders Gender { get; set; }

    [Required]
    // E.164 International Telephone Number Format
    [RegularExpression(@"^\+\d{1,3}\d{5,15}$",
        ErrorMessage = "Invalid contact number format provided.")]
    [MaxLength(20,
        ErrorMessage = "Contact number cannot be more tha 20 characters.")]
    public string ContactNumber { get; set; }

    public List<Appointment> Appointments { get; set; }
}
