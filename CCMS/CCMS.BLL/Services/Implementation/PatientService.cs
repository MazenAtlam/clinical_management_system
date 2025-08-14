using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo patientRepo;
        private readonly IBookRepo bookRepo;
        private readonly IDoctorRepo doctorRepo;
        //private readonly INotificationService notificationService;

        public PatientService(IPatientRepo patientRepo, IBookRepo bookRepo, IDoctorRepo doctorRepo/*, INotificationService notificationService*/)
        {
            this.patientRepo = patientRepo;
            this.bookRepo = bookRepo;
            this.doctorRepo = doctorRepo;
            //this.notificationService = notificationService;
        }

        public bool Create(PatientDTO patient)
        {
            try
            {
                var newPatient = new Patient(
                    patient.FName,
                    patient.MidName,
                    patient.LName,
                    patient.Ssn,
                    patient.Gender,
                    patient.BirthDate,
                    patient.BloodType,
                    "admin"
                );
                
                // Set the UserId if provided
                if (!string.IsNullOrEmpty(patient.UserId))
                {
                    //newPatient.UserId = patient.UserId;
                }
                
                return patientRepo.CreateAsync(newPatient).Result;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PatientDTO patient)
        {
            try
            {
                var existingPatient = patientRepo.GetByIdAsync(patient.UID).Result;
                if (existingPatient == null)
                    return false;

                existingPatient.Edit(
                    patient.FName,
                    patient.MidName,
                    patient.LName,
                    patient.Ssn,
                    patient.Gender,
                    patient.BirthDate,
                    patient.BloodType,
                    "admin"
                );

                // Update UserId if provided
                if (!string.IsNullOrEmpty(patient.UserId))
                {
                    //existingPatient.UserId = patient.UserId;
                }

                return patientRepo.UpdateAsync(existingPatient).Result;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            return patientRepo.DeleteAsync(id).Result;
        }

        public Patient GetById(int id)
        {
            return patientRepo.GetByIdAsync(id).Result;
        }

        public List<Patient> GetAll()
        {
            return patientRepo.GetAllAsync().Result;
        }

        public List<Patient> GetPatientsByDoctor(int doctorId)
        {
            //return bookRepo.GetPatientsWithBooksByDoctorAsync(doctorId).Result;
            return new List<Patient>();
        }

        public List<Book> GetPatientAppointments(int patientId)
        {
            return patientRepo.GetAllBooksOfPatientAsync(patientId).Result;
        }

        public bool RateDoctor(int patientId, int doctorId, int rating)
        {
            try
            {
                var doctor = doctorRepo.GetById(doctorId);
                if (doctor == null)
                    return false;

                var ratingEnum = (Rating)rating;
                doctor.EditRating(ratingEnum, "admin");
                return doctorRepo.Update(doctor);
            }
            catch
            {
                return false;
            }
        }

        // New methods implementation
        public Patient GetPatientInfoById(int id)
        {
            return patientRepo.GetPatientInfoByIdAsync(id).Result;
        }

        public bool EditPatientById(int id, PatientDTO patient)
        {
            try
            {
                var existingPatient = new Patient(
                    patient.FName,
                    patient.MidName,
                    patient.LName,
                    patient.Ssn,
                    patient.Gender,
                    patient.BirthDate,
                    patient.BloodType,
                    "admin"
                );

                return patientRepo.EditPatientByIdAsync(id, existingPatient).Result;
            }
            catch
            {
                return false;
            }
        }

        public List<FamilyMember> GetFamilyMembersOfPatient(int patientId)
        {
            return patientRepo.GetFamilyMembersOfPatientAsync(patientId).Result;
        }

        public bool AddFamilyMemberToPatient(int patientId, FamilyMember familyMember)
        {
            return patientRepo.AddFamilyMemberToPatientAsync(patientId, familyMember).Result;
        }

        public List<MedicalHistory> GetMedicalHistoryOfPatient(int patientId)
        {
            return patientRepo.GetMedicalHistoryOfPatientAsync(patientId).Result;
        }

        public bool AddMedicalHistoryToPatient(int patientId, MedicalHistory medicalHistory)
        {
            return patientRepo.AddMedicalHistoryToPatientAsync(patientId, medicalHistory).Result;
        }

        public List<Scan> GetScansOfPatient(int patientId)
        {
            return patientRepo.GetScansOfPatientAsync(patientId).Result;
        }

        public bool AddScanToPatient(int patientId, Scan scan)
        {
            return patientRepo.AddScanToPatientAsync(patientId, scan).Result;
        }

        public List<Book> GetAllBooksOfPatient(int patientId)
        {
            return patientRepo.GetAllBooksOfPatientAsync(patientId).Result;
        }
    }
}
