using DoctorAppointmentApi.Models;

namespace DoctorAppointmentApi.Repositories;

public class AppointmentRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<Appointment>(applicationDbContext)
{
}
