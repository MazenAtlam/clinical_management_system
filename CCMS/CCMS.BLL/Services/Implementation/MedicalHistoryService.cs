using CCMS.BLL.ModelVM.MedicalHistory;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        // Compile-time only implementation aligned with async repos

        public MedicalHistoryService(IMedicalHistoryRepo medicalHistoryRepo, IPatientRepo patientRepo, IDoctorRepo doctorRepo/*, INotificationService notificationService*/) { }

        public bool Create(MedicalHistoryDTO medicalHistory)
        {
            return false;
        }

        public bool Update(MedicalHistoryDTO medicalHistory)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public MedicalHistory GetById(int id)
        {
            return null;
        }

        public List<MedicalHistory> GetAll()
        {
            return new List<MedicalHistory>();
        }

        public List<MedicalHistory> GetByPatient(int patientId)
        {
            return new List<MedicalHistory>();
        }

        public List<MedicalHistory> GetByDoctor(int doctorId)
        {
            return new List<MedicalHistory>();
        }

        public bool AddPrescription(int medicalHistoryId, string prescription)
        {
            return false;
        }

        public bool UpdatePrescription(int medicalHistoryId, string prescription)
        {
            return false;
        }
    }
}
