using System;
using System.Threading.Tasks;
using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace CCMS.PLL
{
    public static class PatientRepoManualTest
    {
        public static async Task RunAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CcmsDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-SD1B6CU\\SQLEXPRESS;Database=CCMS;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

            using var db = new CcmsDbContext(optionsBuilder.Options);
            var repo = new PatientRepo(db);

            // Test: Create Patient
            var patient = new Patient(
                fName: "ali",
                midName: "m",
                lName: "f",
                ssn: "123",
                gender: Gender.Male,
                birthDate: new DateTime(2000, 1, 1),
                bloodType: "b+",
                pType: PersonType.Patient,
                createdBy: "test"
            );

            var result = await repo.CreateAsync(patient);
            Console.WriteLine($"Patient Create Result: {result}");
            if (result)
            {
                Console.WriteLine($"Created Patient ID: {patient.Id}");
            }

            // Test: GetAll Patients
            var patients = await repo.GetAllAsync();
            Console.WriteLine($"Total Patients: {patients.Count}");
            foreach (var p in patients)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.FName} {p.LName}, SSN: {p.SSN}");
            }
        }
    }
}
