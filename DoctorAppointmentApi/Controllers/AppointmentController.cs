using Microsoft.AspNetCore.Mvc;

using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Services;

namespace DoctorAppointmentApi.Controllers;

[Route("/api/appointment")]
[ApiController]
public class AppointmentController(IServiceBase<Appointment> service)
    : ApplicationControllerBase<Appointment, IServiceBase<Appointment>>(service)
{
}
