using CCMS.BLL.ModelVM.MedicalHistory;
using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IMedicalHistoryService
    {
        bool Create(MedicalHistoryDTO medicalHistory);
        bool Update(MedicalHistoryDTO medicalHistory);
        bool Delete(int id);
        MedicalHistory GetById(int id);
        List<MedicalHistory> GetAll();
        List<MedicalHistory> GetByPatient(int patientId);
        List<MedicalHistory> GetByDoctor(int doctorId);
        bool AddPrescription(int medicalHistoryId, string prescription);
        bool UpdatePrescription(int medicalHistoryId, string prescription);
    }
}
