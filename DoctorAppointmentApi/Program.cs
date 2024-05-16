using Microsoft.EntityFrameworkCore;

using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repositories;
using DoctorAppointmentApi.Services;

internal class Program
{
    private static void ConfigureDic(IServiceCollection services)
    {
        services.AddScoped<IRepositoryBase<Doctor>, DoctorRepository>();
        services.AddScoped<IRepositoryBase<Patient>, PatientRepository>();
        services.AddScoped<IRepositoryBase<Appointment>, AppointmentRepository>();

        services.AddScoped<IServiceBase<Doctor>, DoctorService>();
        services.AddScoped<IServiceBase<Patient>, PatientService>();
        services.AddScoped<IServiceBase<Appointment>, AppointmentService>();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString(
                "Development"
            ), ServerVersion.AutoDetect(
                builder.Configuration.GetConnectionString("Development")
            ));
        });
        ConfigureDic(builder.Services);

        builder.Services.AddControllers();

        // https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
