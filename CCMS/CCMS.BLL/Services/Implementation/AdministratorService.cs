using CCMS.BLL.Helper;
using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.LabDoctor;
using CCMS.BLL.ModelVM.MedicalHistory;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.ModelVM.Scan;
using CCMS.BLL.ModelVM.User;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace CCMS.BLL.Services.Implementation
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly ILabDoctorRepo _labDoctorRepo;
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IBiomedicalEngineerRepo _biomedicalEngineerRepo;
        private readonly IBookRepo _bookRepo;
        private readonly IScanRepo _scanRepo;
        private readonly IMedicalHistoryRepo _medicalHistoryRepo;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly EmployeeMapper employeeMapper = new EmployeeMapper();
        private readonly PatientMapper patientMapper = new PatientMapper();
        private readonly DoctorMapper doctorMapper = new DoctorMapper();
        private readonly LabDoctorMapper labDoctorMapper = new LabDoctorMapper();
        private readonly BookMapper bookMapper = new BookMapper();
        private readonly ScanMapper scanMapper = new ScanMapper();
        private readonly MedicalHistoryMapper medicalHistoryMapper = new MedicalHistoryMapper();

        public AdministratorService(
            IPatientRepo patientRepo,
            IDoctorRepo doctorRepo,
            ILabDoctorRepo labDoctorRepo,
            IEmployeeRepo employeeRepo,
            IBiomedicalEngineerRepo biomedicalEngineerRepo,
            IBookRepo bookRepo,
            IScanRepo scanRepo,
            IMedicalHistoryRepo medicalHistoryRepo,
            RoleManager<IdentityRole> roleManager)
        {
            _patientRepo = patientRepo;
            _doctorRepo = doctorRepo;
            _labDoctorRepo = labDoctorRepo;
            _employeeRepo = employeeRepo;
            _biomedicalEngineerRepo = biomedicalEngineerRepo;
            _bookRepo = bookRepo;
            _scanRepo = scanRepo;
            _medicalHistoryRepo = medicalHistoryRepo;
            _roleManager = roleManager;
        }

        // The IAdministratorService interface in this project uses async Task<string?> signatures.
        // Provide minimal wrappers to satisfy interface while internally using repositories.
        public async Task<string?> CreateAdmin(CreateEmployee adm, string createdBy) // Admin
        {
            try
            {
                string? path = null;
                if (adm.File != null)
                    path = Upload.UploadFile("Files", adm.File);
                Employee admin = new Employee(UserType.Admin, adm.FName, adm.MidName, adm.LName, adm.Ssn,
                            adm.Gender, adm.BirthDate, path, adm.Salary,
                            adm.YearsOfExperience, adm.HiringDate, adm.MgrId,
                            adm.AdmId, adm.DeptId, createdBy
                            );

                await _employeeRepo.Add(admin);
                await _employeeRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> CreateEmployee(CreateEmployee mgr, string createdBy) // Manager
        {
            try
            {
                string? path = null;
                if (mgr.File != null)
                    path = Upload.UploadFile("Files", mgr.File);
                Employee manager = new Employee(UserType.Manager, mgr.FName, mgr.MidName, mgr.LName, mgr.Ssn,
                            mgr.Gender, mgr.BirthDate, path, mgr.Salary, mgr.YearsOfExperience,
                            mgr.HiringDate, mgr.MgrId, mgr.AdmId, mgr.DeptId, createdBy
                            );

                await _employeeRepo.Add(manager);
                await _employeeRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> CreateEmployee(CreateDoctor doc, string createdBy) // Doctor
        {
            try
            {
                string? path = null;
                if (doc.File != null)
                    path = Upload.UploadFile("Files", doc.File);
                Doctor doctor = new Doctor(UserType.Doctor, doc.FName, doc.MidName, doc.LName,
                    doc.Ssn, doc.Gender, doc.BirthDate, path, doc.Salary,
                            doc.YearsOfExperience, doc.HiringDate, doc.MgrId,
                            doc.AdmId, doc.DeptId, doc.major, createdBy
                            );

                await _doctorRepo.Add(doctor);
                await _doctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> CreateEmployee(CreateLabDoctor lDoc, string createdBy) // LabDoctor
        {
            try
            {
                string? path = null;
                if (lDoc.File != null)
                    path = Upload.UploadFile("Files", lDoc.File);
                LabDoctor labDoctor = new LabDoctor(UserType.LabDoctor, lDoc.FName, lDoc.MidName, lDoc.LName, lDoc.Ssn,
                            lDoc.Gender, lDoc.BirthDate, path, lDoc.Salary,
                            lDoc.YearsOfExperience, lDoc.HiringDate, lDoc.MgrId,
                            lDoc.AdmId, lDoc.DeptId, createdBy
                            );

                await _labDoctorRepo.Add(labDoctor);
                await _labDoctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> CreateEmployee(CreateBiomedicalEngineer bioEng, string createdBy) // BiomedicalEngineer
        {
            try
            {
                string? path = null;
                if (bioEng.File != null)
                    path = Upload.UploadFile("Files", bioEng.File);
                BiomedicalEngineer biomedicalEngineer = new BiomedicalEngineer(UserType.BiomedicalEngineer, bioEng.FName, bioEng.MidName,
                    bioEng.LName, bioEng.Ssn, bioEng.Gender, bioEng.BirthDate, path,
                    bioEng.Salary, bioEng.YearsOfExperience, bioEng.HiringDate,
                    bioEng.MgrId, bioEng.AdmId, bioEng.DeptId, createdBy
                    );

                await _biomedicalEngineerRepo.Add(biomedicalEngineer);
                await _biomedicalEngineerRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllAdmins()
        {
            try
            {
                List<Employee> admins = await _employeeRepo.GetAllAdmins();

                if (admins.Count == 0)
                    return (null, "No data found.");

                List<EmployeeDTO> adms = employeeMapper.ToListResponseDto(admins);

                return (adms, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllManagers()
        {
            try
            {
                List<Employee> managers = await _employeeRepo.GetAllManagers();

                if (managers.Count == 0)
                    return (null, "No data found.");

                List<EmployeeDTO> mgrs = employeeMapper.ToListResponseDto(managers);

                return (mgrs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(EmployeeDTO?, string?)> GetAdminByID(string id)
        {
            try
            {
                Employee employee = await _employeeRepo.GetEmployeeById(id);

                EmployeeDTO emp = employeeMapper.ToResponseDto(employee);

                return (emp, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllEmployeesCrearedBy(string id)
        {
            try
            {
                List<Employee> employees = await _employeeRepo.GetAllEmployeesCrearedByAdmin(id);

                if (employees.Count == 0)
                    return (null, "No data found");

                List<EmployeeDTO> emps = employeeMapper.ToListResponseDto(employees);

                return (emps, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<string?> Update(EmployeeDTO emp, string modifiedBy)
        {
            try
            {
                Employee employee = await _employeeRepo.GetEmployeeById(emp.Id);

                employee.Edit(emp.FName, emp.MidName, emp.LName, emp.Ssn, emp.Gender, emp.BirthDate, emp.path,
                    emp.Salary, emp.YearsOfExperience, emp.HiringDate, emp.MgrId, emp.DeptId, modifiedBy);
                await _employeeRepo.Save();

                return null;
            }
            catch (Exception ex) { return (ex.Message); }
        }

        public async Task<string?> Delete(string id, string modifiedBy)
        {
            try
            {
                Employee employee = await _employeeRepo.GetEmployeeById(id);

                employee.Delete(modifiedBy);
                await _employeeRepo.Save();

                return null;
            }
            catch (Exception ex) { return (ex.Message); }
        }

        public async Task<(List<PatientDTO>?, string?)> GetAllPatients()
        {
            try
            {
                List<Patient> patients = await _patientRepo.GetAll();

                if (patients.Count == 0)
                    return (null, "No data found");

                List<PatientDTO> patientDTOs = patientMapper.ToDTOList(patients);

                return (patientDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<DoctorDTO>?, string?)> GetAllDoctors()
        {
            try
            {
                List<Doctor> doctors = await _doctorRepo.GetAll();

                if (doctors.Count == 0)
                    return (null, "No data found");

                List<DoctorDTO> docs = doctorMapper.ToListResponseDto(doctors);

                return (docs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<LabDoctorDTO>?, string?)> GetAllLabDoctors()
        {
            try
            {
                List<LabDoctor> labDoctors = await _labDoctorRepo.GetAll();

                if (labDoctors.Count == 0)
                    return (null, "No data found");

                List<LabDoctorDTO> labDocs = labDoctorMapper.ToListResponseDto(labDoctors);

                return (labDocs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = await _employeeRepo.GetAllEmployees();

                if (employees.Count == 0)
                    return (null, "No data found");

                List<EmployeeDTO> emps = employeeMapper.ToListResponseDto(employees);

                return (emps, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<BookDTO>?, string?)> GetAllAppointments()
        {
            try
            {
                List<Book> books = await _bookRepo.GetAll();

                if (books.Count == 0)
                    return (null, "No data found");

                List<BookDTO> bookDTOs = bookMapper.ToDTOList(books);

                return (bookDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<ScanDTO>?, string?)> GetAllScans()
        {
            try
            {
                List<Scan> scans = await _scanRepo.GetAll();

                if (scans.Count == 0)
                    return (null, "No data found");

                List<ScanDTO> scanDTOs = scanMapper.ToDTOList(scans);

                return (scanDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<MedicalHistoryDTO>?, string?)> GetAllMedicalHistories()
        {
            try
            {
                List<MedicalHistory> medicalHistories = await _medicalHistoryRepo.GetAll();

                if (medicalHistories.Count == 0)
                    return (null, "No data found");

                List<MedicalHistoryDTO> mhDTOs = medicalHistoryMapper.ToDTOList(medicalHistories);

                return (mhDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<string?> DeletePatient(string patientId, string modifiedBy)
        {
            try
            {
                Patient patient = await _patientRepo.GetById(patientId);

                patient.Delete(modifiedBy);
                await _patientRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> DeleteDoctor(string doctorId, string modifiedBy)
        {
            try
            {
                Doctor doctor = await _doctorRepo.GetById(doctorId);

                doctor.Delete(modifiedBy);
                await _doctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> DeleteLabDoctor(string labDoctorId, string modifiedBy)
        {
            try
            {
                LabDoctor labDoctor = await _labDoctorRepo.GetById(labDoctorId);

                labDoctor.Delete(modifiedBy);
                await _labDoctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<(string?, IdentityResult?)> CreateRole(CreateRoleVM roleVM)
        {
            try
            {
                IdentityRole? getRoleByName = await _roleManager.FindByNameAsync(roleVM.Name);

                if (getRoleByName != null)
                    return ($"Role with name {roleVM.Name} already exists", null);

                IdentityRole role = new IdentityRole()
                {
                    Name = roleVM.Name
                };

                IdentityResult result = await _roleManager.CreateAsync(role);

                return result.Succeeded ? (role.Name, result) : (null, result);
            }
            catch (Exception ex) { return (ex.Message, null); }
        }
    }
}
