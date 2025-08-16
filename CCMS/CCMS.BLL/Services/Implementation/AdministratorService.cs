using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.LabDoctor;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

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
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        private readonly EmployeeMapper employeeMapper = new EmployeeMapper();
        private readonly PatientMapper patientMapper = new PatientMapper();
        private readonly DoctorMapper doctorMapper = new DoctorMapper();
        private readonly LabDoctorMapper labDoctorMapper = new LabDoctorMapper();
        private readonly BookMapper bookMapper = new BookMapper();

        public AdministratorService(
            IPatientRepo patientRepo,
            IDoctorRepo doctorRepo,
            ILabDoctorRepo labDoctorRepo,
            IEmployeeRepo employeeRepo,
            IBiomedicalEngineerRepo biomedicalEngineerRepo,
            IBookRepo bookRepo,
            IScanRepo scanRepo,
            IMedicalHistoryRepo medicalHistoryRepo/*,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager*/)
        {
            _patientRepo = patientRepo;
            _doctorRepo = doctorRepo;
            _labDoctorRepo = labDoctorRepo;
            _employeeRepo = employeeRepo;
            _biomedicalEngineerRepo = biomedicalEngineerRepo;
            _bookRepo = bookRepo;
            _scanRepo = scanRepo;
            _medicalHistoryRepo = medicalHistoryRepo;
            //_userManager = userManager;
            //_roleManager = roleManager;
        }

        // The IAdministratorService interface in this project uses async Task<string?> signatures.
        // Provide minimal wrappers to satisfy interface while internally using repositories.
        public async Task<string?> CreateAdmin(CreateEmployee adm, string createdBy) // Admin
        {
            try
            {
                Employee admin = new Employee(adm.FName, adm.MidName, adm.LName, adm.Ssn,
                            adm.Gender, adm.BirthDate, adm.PType, adm.Salary, EmployeeType.Admin,
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
                Employee manager = new Employee(mgr.FName, mgr.MidName, mgr.LName, mgr.Ssn,
                            mgr.Gender, mgr.BirthDate, PersonType.Employee, mgr.Salary,
                            EmployeeType.Manager, mgr.YearsOfExperience, mgr.HiringDate,
                            mgr.MgrId, mgr.AdmId, mgr.DeptId, createdBy
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
                Doctor doctor = new Doctor(doc.FName, doc.MidName, doc.LName, doc.Ssn,
                            doc.Gender, doc.BirthDate, PersonType.Employee, doc.Salary,
                            EmployeeType.Doctor, doc.YearsOfExperience, doc.HiringDate,
                            doc.MgrId, doc.AdmId, doc.DeptId, doc.major, doc.rating, createdBy
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
                LabDoctor labDoctor = new LabDoctor(lDoc.FName, lDoc.MidName, lDoc.LName, lDoc.Ssn,
                            lDoc.Gender, lDoc.BirthDate, PersonType.Employee, lDoc.Salary,
                            EmployeeType.LabDoctor, lDoc.YearsOfExperience, lDoc.HiringDate,
                            lDoc.MgrId, lDoc.AdmId, lDoc.DeptId, createdBy
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
                BiomedicalEngineer biomedicalEngineer = new BiomedicalEngineer(bioEng.FName, bioEng.MidName,
                    bioEng.LName, bioEng.Ssn, bioEng.Gender, bioEng.BirthDate,
                    PersonType.Employee, bioEng.Salary, EmployeeType.BiomedicalEngineer,
                    bioEng.YearsOfExperience, bioEng.HiringDate, bioEng.MgrId,
                    bioEng.AdmId, bioEng.DeptId, createdBy
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

        public async Task<(EmployeeDTO?, string?)> GetAdminByID(int id)
        {
            try
            {
                Employee employee = await _employeeRepo.GetEmployeeById(id);

                EmployeeDTO emp = employeeMapper.ToResponseDto(employee);

                return (emp, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllEmployeesCrearedBy(int id)
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
                Employee employee = await _employeeRepo.GetEmployeeById(emp.UID);

                employee.Edit(emp.FName, emp.MidName, emp.LName, emp.Ssn, emp.Gender, emp.BirthDate,
                    emp.Salary, emp.YearsOfExperience, emp.HiringDate, emp.MgrId, emp.DeptId, modifiedBy);
                await _employeeRepo.Save();

                return null;
            }
            catch (Exception ex) { return (ex.Message); }
        }

        public async Task<string?> Delete(int id, string modifiedBy)
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

        public List<Scan> GetAllScans() => new List<Scan>();

        public List<MedicalHistory> GetAllMedicalHistories() => new List<MedicalHistory>();

        public bool DeletePatient(int patientId)
        {
            try
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDoctor(int doctorId)
        {
            try
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLabDoctor(int labDoctorId)
        {
            try
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateRole(string roleName)
        {
            try
            {
                //if (await _roleManager.RoleExistsAsync(roleName))
                //    return false;

                //var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                //return result.Succeeded;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(string roleName)
        {
            try
            {
                //var role = await _roleManager.FindByNameAsync(roleName);
                //if (role == null) return false;

                //var result = await _roleManager.DeleteAsync(role);
                //return result.Succeeded;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AssignRoleToUser(string userId, string roleName)
        {
            try
            {
                //var user = await _userManager.FindByIdAsync(userId);
                //if (user == null) return false;

                //var result = await _userManager.AddToRoleAsync(user, roleName);
                //return result.Succeeded;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveRoleFromUser(string userId, string roleName)
        {
            try
            {
                //var user = await _userManager.FindByIdAsync(userId);
                //if (user == null) return false;

                //var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                //return result.Succeeded;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<string>> GetUserRoles(string userId)
        {
            try
            {
                //var user = await _userManager.FindByIdAsync(userId);
                //if (user == null) return new List<string>();

                //var roles = await _userManager.GetRolesAsync(user);
                //return roles.ToList();
                return new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        //public async Task<List<ApplicationUser>> GetAllUsers()
        //{
        //    try
        //    {
        //        return _userManager.Users.ToList();
        //    }
        //    catch
        //    {
        //        return new List<ApplicationUser>();
        //    }
        //}
    }
}
