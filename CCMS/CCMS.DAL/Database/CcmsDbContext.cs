using Microsoft.EntityFrameworkCore;
using CCMS.DAL.Entities;
namespace CCMS.DAL.Database
{
    public class CcmsDbContext : DbContext
    {
        public CcmsDbContext(DbContextOptions<CcmsDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Scan> scans { get; set; }
        public DbSet<FamilyMember> familyMembers { get; set; }
        public DbSet<MedicalHistory> medicalHistories { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<PateintFamilyJoin> pateintFamilyJoins { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<MedicalDevice> MedicalDevices { get; set; }
        public DbSet<LabDoctor> labDoctors { get; set; }
        public DbSet<BiomedicalEngineer> biomedicalEngineers { get; set; }
        public DbSet<WorkingSlot> workingSlots { get; set; }
        public DbSet<BiomedicalEngineer_MedicalDevice> BiomedicalEngineers_MedicalDevices { get; set; }
    }
}
