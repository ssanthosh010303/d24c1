using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repositories;

namespace DoctorAppointmentApi.Services;

public class AppointmentService(
    IRepositoryBase<Appointment> appointmentRepository)
        : ServiceBase<Appointment>(appointmentRepository)
{
}
