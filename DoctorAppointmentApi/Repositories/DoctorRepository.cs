using DoctorAppointmentApi.Models;

namespace DoctorAppointmentApi.Repositories;

public class DoctorRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<Doctor>(applicationDbContext)
{
}
