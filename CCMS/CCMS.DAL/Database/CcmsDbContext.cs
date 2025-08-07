using Microsoft.EntityFrameworkCore;
using CCMS.DAL.Entities;
namespace CCMS.DAL.Database
{
    public class CcmsDbContext : DbContext
    {
        public CcmsDbContext(DbContextOptions<CcmsDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BiomedicalEngineer> biomedicalEngineers { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FamilyMember> familyMembers { get; set; }
        public DbSet<LabDoctor> labDoctors { get; set; }
        public DbSet<MedicalDevice> MedicalDevices { get; set; }
        public DbSet<MedicalDevice_Room> MedicalDevices_Rooms { get; set; }
        public DbSet<MedicalHistory> medicalHistories { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<PatientFamily> pateintFamilyJoins { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Scan> scans { get; set; }
        public DbSet<WorkingSlot> workingSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BiomedicalEngineer_MedicalDevice many to many relationship
            modelBuilder.Entity<BiomedicalEngineer>()
                .HasMany(bme => bme.MedicalDevices)
                .WithMany(md => md.BiomedicalEngineers);

            // Employee_WorkingSlot many to many relationship
            modelBuilder.Entity<Employee>()
                .HasMany(emp => emp.WorkingSlots)
                .WithMany(ws => ws.Employees);

            // Patient_FamilyMember many to many relationship (Explict Join)
            // Patient - PatientFamily one to many relationship
            modelBuilder.Entity<PatientFamily>()
                .HasOne(pf => pf.Patient)
                .WithMany(p => p.PatientFamilyMembers)
                .HasForeignKey(pf => pf.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // FamilyMember - PatientFamily one to many relationship
            modelBuilder.Entity<PatientFamily>()
                .HasOne(pf => pf.FamilyMember)
                .WithMany(fm => fm.PatientFamilyMembers)
                .HasForeignKey(pf => pf.FamilyMemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
