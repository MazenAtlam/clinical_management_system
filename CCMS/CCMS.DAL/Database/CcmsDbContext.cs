﻿using Microsoft.EntityFrameworkCore;
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
    }
}
