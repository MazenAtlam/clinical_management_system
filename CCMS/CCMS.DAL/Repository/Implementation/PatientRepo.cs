using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly CcmsDbContext db;

        public PatientRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(Patient patient) => db.patients.Add(patient);

        // In PatientService
        //public async Task<bool> DeleteAsync(string id)
        //{
        //    try
        //    {
        //        var patient = await db.patients.FirstOrDefaultAsync(a => a.UID == id);
        //        if (patient == null)
        //            return false;
        //        patient.Delete("admin");
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<Patient>> GetAll() => db.patients.Where(a => !a.IsDeleted).ToList();

        public async Task<Patient> GetById(string id)
        {
            Patient? patient = db.patients.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefault();
            
            return patient == null
                ? throw new ArgumentException($"There is no patient with this ID", "id")
                : patient;
        }

        public async Task Save() => db.SaveChanges();

        // In PatientService
        //public async Task<bool> UpdateAsync(Patient patient)
        //{
        //    try
        //    {
        //        var pat = await db.patients.FirstOrDefaultAsync(a => a.UID == patient.UID);
        //        if (pat == null)
        //            return false;
        //        // The Edit method has been updated
        //        //pat.Edit(
        //        //    patient.FName,
        //        //    patient.MidName,
        //        //    patient.LName,
        //        //    patient.Ssn,
        //        //    patient.Gender,
        //        //    patient.BirthDate,
        //        //    patient.BloodType
        //        //);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        // New methods implementation
        // In PatientService
        //public async Task<Patient> GetPatientInfoByIdAsync(string id)
        //{
        //    return await db.patients
        //        .Include(p => p.PatientFamilyMembers)
        //        .Include(p => p.MedicalHistories)
        //        .Include(p => p.Scans)
        //        .Include(p => p.Books)
        //        .FirstOrDefaultAsync(p => p.UID == id && p.IsDeleted == false);
        //}

        // In PatientService
        //public async Task<List<FamilyMember>> GetFamilyMembersOfPatientAsync(int patientId)
        //{
        //    var patient = await db.patients
        //        .Include(p => p.PatientFamilyMembers)
        //        .ThenInclude(pf => pf.FamilyMember)
        //        .FirstOrDefaultAsync(p => p.UID == patientId);

        //    return patient?.PatientFamilyMembers
        //        .Where(pf => pf.IsDeleted == false)
        //        .Select(pf => pf.FamilyMember)
        //        .ToList() ?? new List<FamilyMember>();
        //}

        // In PatientService
        //public async Task<bool> AddFamilyMemberToPatientAsync(int patientId, FamilyMember familyMember)
        //{
        //    try
        //    {
        //        var patient = await db.patients.FirstOrDefaultAsync(p => p.UID == patientId);
        //        if (patient == null)
        //            return false;

        //        var patientFamily = new PatientFamily("Family", patientId, familyMember.Id, "admin");
        //        await db.pateintFamilyJoins.AddAsync(patientFamily);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        // In PatientService
        //public async Task<List<MedicalHistory>> GetMedicalHistoryOfPatientAsync(int patientId)
        //{
        //    var patient = await db.patients
        //        .Include(p => p.MedicalHistories)
        //        .FirstOrDefaultAsync(p => p.UID == patientId);

        //    return patient?.MedicalHistories
        //        .Where(mh => mh.IsDeleted == false)
        //        .ToList() ?? new List<MedicalHistory>();
        //}

        // In PatientService
        //public async Task<bool> AddMedicalHistoryToPatientAsync(int patientId, MedicalHistory medicalHistory)
        //{
        //    try
        //    {
        //        var patient = await db.patients.FirstOrDefaultAsync(p => p.UID == patientId);
        //        if (patient == null)
        //            return false;

        //        // Create a new medical history with the patient ID since PatientId is private set
        //        var newMedicalHistory = new MedicalHistory(medicalHistory.IsAcceptable, medicalHistory.DiseaseName, patientId, "admin");
        //        await db.medicalHistories.AddAsync(newMedicalHistory);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        // In PatientService
        //public async Task<List<Scan>> GetScansOfPatientAsync(int patientId)
        //{
        //    var patient = await db.patients
        //        .Include(p => p.Scans)
        //        .FirstOrDefaultAsync(p => p.UID == patientId);

        //    return patient?.Scans
        //        .Where(s => s.IsDeleted == false)
        //        .ToList() ?? new List<Scan>();
        //}

        // In PatientService
        //public async Task<bool> AddScanToPatientAsync(int patientId, Scan scan)
        //{
        //    try
        //    {
        //        var patient = await db.patients.FirstOrDefaultAsync(p => p.UID == patientId);
        //        if (patient == null)
        //            return false;

        //        // Create a new scan with the patient ID since PatientId is private set
        //        var newScan = new Scan(scan.ScanType, scan.ScanTech, scan.Results, scan.SDate, scan.LDID, patientId, "admin");
        //        await db.scans.AddAsync(newScan);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        // In PatientService
        //public async Task<List<Book>> GetAllBooksOfPatientAsync(int patientId)
        //{
        //    var patient = await db.patients
        //        .Include(p => p.Books)
        //        .FirstOrDefaultAsync(p => p.UID == patientId);

        //    return patient?.Books
        //        .Where(b => b.IsDeleted == false)
        //        .ToList() ?? new List<Book>();
        //}
    }
}
