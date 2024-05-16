using Microsoft.AspNetCore.Mvc;

using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Services;

namespace DoctorAppointmentApi.Controllers;

[Route("/api/doctor")]
[ApiController]
public class DoctorController(IServiceBase<Doctor> service)
    : ApplicationControllerBase<Doctor, IServiceBase<Doctor>>(service)
{
}
