using DoctorAppointmentApi.Models;

namespace DoctorAppointmentApi.Repositories;

public class PatientRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<Patient>(applicationDbContext)
{
}
