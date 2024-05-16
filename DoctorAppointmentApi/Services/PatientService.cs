using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repositories;

namespace DoctorAppointmentApi.Services;

public class PatientService(IRepositoryBase<Patient> patientRepository)
    : ServiceBase<Patient>(patientRepository)
{
}
