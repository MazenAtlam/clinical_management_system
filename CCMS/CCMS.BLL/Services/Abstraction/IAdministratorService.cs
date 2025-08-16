using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.LabDoctor;
using CCMS.BLL.ModelVM.MedicalHistory;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.ModelVM.Scan;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IAdministratorService
    {
        public Task<string?> CreateAdmin(CreateEmployee adm, string createdBy); // Admin
        public Task<string?> CreateEmployee(CreateEmployee mgr, string createdBy); // Manager
        public Task<string?> CreateEmployee(CreateDoctor doc, string createdBy); // Doctor
        public Task<string?> CreateEmployee(CreateLabDoctor lDoc, string createdBy); // LabDoctor
        public Task<string?> CreateEmployee(CreateBiomedicalEngineer bioEng, string createdBy); // BiomedicalEngineer
        public Task<(List<EmployeeDTO>?, string?)> GetAllAdmins();
        public Task<(List<EmployeeDTO>?, string?)> GetAllManagers();
        public Task<(EmployeeDTO?, string?)> GetAdminByID(int id);
        public Task<(List<EmployeeDTO>?, string?)> GetAllEmployeesCrearedBy(int id);
        public Task<string?> Update(EmployeeDTO emp, string modifiedBy);
        public Task<string?> Delete(int id, string modifiedBy);
        public Task<(List<PatientDTO>?, string?)> GetAllPatients();
        public Task<(List<DoctorDTO>?, string?)> GetAllDoctors();
        public Task<(List<LabDoctorDTO>?, string?)> GetAllLabDoctors();
        public Task<(List<EmployeeDTO>?, string?)> GetAllEmployees();
        public Task<(List<BookDTO>?, string?)> GetAllAppointments();
        public Task<(List<ScanDTO>?, string?)> GetAllScans();
        public Task<(List<MedicalHistoryDTO>?, string?)> GetAllMedicalHistories();
        public Task<string?> DeletePatient(int patientId, string modifiedBy);
        public Task<string?> DeleteDoctor(int doctorId, string modifiedBy);
        public Task<string?> DeleteLabDoctor(int labDoctorId, string modifiedBy);
    }
}
