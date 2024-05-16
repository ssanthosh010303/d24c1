using Microsoft.AspNetCore.Mvc;

using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Services;

namespace DoctorAppointmentApi.Controllers;

[Route("/api/patient")]
[ApiController]
public class PatientController(IServiceBase<Patient> service)
    : ApplicationControllerBase<Patient, IServiceBase<Patient>>(service)
{
}
