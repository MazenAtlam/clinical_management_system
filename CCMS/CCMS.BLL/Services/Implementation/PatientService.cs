using CCMS.BLL.Helper;
using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo patientRepo;
        private readonly IBookRepo bookRepo;
        private readonly IDoctorRepo doctorRepo;
        //private readonly INotificationService notificationService;

        private readonly PatientMapper _patientMapper = new PatientMapper();

        public PatientService(IPatientRepo patientRepo, IBookRepo bookRepo, IDoctorRepo doctorRepo/*, INotificationService notificationService*/)
        {
            this.patientRepo = patientRepo;
            this.bookRepo = bookRepo;
            this.doctorRepo = doctorRepo;
            //this.notificationService = notificationService;
        }

        public async Task<string?> Create(CreatePatient pat, string createdBy)
        {
            try
            {
                string path = Upload.UploadFile("Files", pat.File);
                Patient patient = new Patient(UserType.Patient, pat.FName, pat.MidName, pat.LName,
                    pat.Ssn, pat.Gender, pat.BirthDate, pat.BloodType, path, createdBy);

                await patientRepo.Add(patient);
                await patientRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<bool> Update(PatientDTO patient)
        {
            try
            {
                var existingPatient = await patientRepo.GetById(patient.Id);
                if (existingPatient == null)
                    return false;
                if(patient.File != null)
                {
                    patient.path = Upload.UploadFile("Files", patient.File);
                    patient.File = null;
                }
                existingPatient.Edit(
                    patient.FName,
                    patient.MidName,
                    patient.LName,
                    patient.Ssn,
                    patient.Gender,
                    patient.BirthDate,
                    patient.BloodType,
                    patient.path,
                    "admin"
                );

                //return patientRepo.Update(existingPatient).Result;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            //return patientRepo.DeleteAsync(id).Result;
            return false ;
        }

        public async Task<Patient> GetById(string id)
        {
            return await patientRepo.GetById(id);
        }

        public async Task<List<Patient>> GetAll()
        {
            return await patientRepo.GetAll();
        }

        public List<Patient> GetPatientsByDoctor(string doctorId)
        {
            //return bookRepo.GetPatientsWithBooksByDoctorAsync(doctorId).Result;
            return new List<Patient>();
        }

        public List<Book> GetPatientAppointments(string patientId)
        {
            //return patientRepo.GetAllBooksOfPatient(patientId).Result;
            return new List<Book>();
        }

        public async Task<bool> RateDoctor(string patientId, string doctorId, int rating)
        {
            try
            {
                var doctor = await doctorRepo.GetById(doctorId);
                if (doctor == null)
                    return false;

                var ratingEnum = (Rating)rating;
                doctor.EditRating(ratingEnum, "admin");
                //return doctorRepo.Update(doctor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // New methods implementation
        //public Patient GetPatientInfoById(string id)
        //{
        //    return patientRepo.GetPatientInfoByIdAsync(id).Result;
        //}

        //public bool EditPatientById(string id, PatientDTO patient)
        //{
        //    try
        //    {
        //        var existingPatient = new Patient(
        //            patient.FName,
        //            patient.MidName,
        //            patient.LName,
        //            patient.Ssn,
        //            patient.Gender,
        //            patient.BirthDate,
        //            patient.BloodType,
        //            "admin"
        //        );

        //        return patientRepo.EditPatientByIdAsync(id, existingPatient).Result;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public List<FamilyMember> GetFamilyMembersOfPatient(int patientId)
        //{
        //    return patientRepo.GetFamilyMembersOfPatientAsync(patientId).Result;
        //}

        //public bool AddFamilyMemberToPatient(int patientId, FamilyMember familyMember)
        //{
        //    return patientRepo.AddFamilyMemberToPatientAsync(patientId, familyMember).Result;
        //}

        //public List<MedicalHistory> GetMedicalHistoryOfPatient(int patientId)
        //{
        //    return patientRepo.GetMedicalHistoryOfPatientAsync(patientId).Result;
        //}

        //public bool AddMedicalHistoryToPatient(int patientId, MedicalHistory medicalHistory)
        //{
        //    return patientRepo.AddMedicalHistoryToPatientAsync(patientId, medicalHistory).Result;
        //}

        //public List<Scan> GetScansOfPatient(int patientId)
        //{
        //    return patientRepo.GetScansOfPatientAsync(patientId).Result;
        //}

        //public bool AddScanToPatient(int patientId, Scan scan)
        //{
        //    return patientRepo.AddScanToPatientAsync(patientId, scan).Result;
        //}

        //public List<Book> GetAllBooksOfPatient(int patientId)
        //{
        //    return patientRepo.GetAllBooksOfPatientAsync(patientId).Result;
        //}
    }
}
