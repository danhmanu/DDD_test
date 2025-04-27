using EMRService.EMRService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EMRService.EMRService.Infrastructure
{
    public class EMRDbContext : DbContext
    {
        public EMRDbContext(DbContextOptions<EMRDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.MedicalRecords)
                .WithOne(m => m.Patient)
                .HasForeignKey(m => m.PatientId);
        }
    }
}
