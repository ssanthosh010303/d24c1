using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repositories;

namespace DoctorAppointmentApi.Services;

public class DoctorService(IRepositoryBase<Doctor> doctorRepository)
    : ServiceBase<Doctor>(doctorRepository)
{
}
