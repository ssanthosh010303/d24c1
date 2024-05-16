using DoctorAppointmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApi.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<ModelBase> ModelBase { get; set; }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModelBase>().UseTpcMappingStrategy();
        modelBuilder.Entity<Doctor>().ToTable("Doctor");
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Appointment>().ToTable("Appointment");
    }
}
