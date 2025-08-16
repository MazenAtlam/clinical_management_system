using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class BiomedicalEngineerService : IBiomedicalEngineerService
    {
        private readonly IBiomedicalEngineerRepo _biomedicalEngineerRepo;

        private readonly BiomedicalEngineerMapper biomedicalEngineerMapper = new BiomedicalEngineerMapper();
        private readonly MedicalDeviceMapper medicalDeviceMapper = new MedicalDeviceMapper();

        public BiomedicalEngineerService(IBiomedicalEngineerRepo biomedicalEngineerRepo)
            => _biomedicalEngineerRepo = biomedicalEngineerRepo;

        public async Task<string?> Create(CreateBiomedicalEngineer emp, string createdBy)
        {
            try
            {
                BiomedicalEngineer biomedicalEngineer = new BiomedicalEngineer(
                    emp.FName, emp.MidName, emp.LName, emp.Ssn, emp.Gender,
                    emp.BirthDate, PersonType.Employee, emp.Salary,
                    EmployeeType.BiomedicalEngineer, emp.YearsOfExperience, emp.HiringDate,
                    emp.MgrId, emp.AdmId, emp.DeptId, createdBy
                    );

                await _biomedicalEngineerRepo.Add(biomedicalEngineer);
                await _biomedicalEngineerRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<(List<BiomedicalEngineerDTO>?, string?)> GetAllBiomedicalEngineers()
        {
            try
            {
                List<BiomedicalEngineer> biomedicalEngineers = await _biomedicalEngineerRepo.GetAll();

                if (biomedicalEngineers.Count == 0)
                    return (null, "No data found");

                List<BiomedicalEngineerDTO> bioEngs = biomedicalEngineerMapper.ToListResponseDto(biomedicalEngineers);

                return (bioEngs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesWorksOn(int id)
        {
            try
            {
                BiomedicalEngineer biomedicalEngineer = await _biomedicalEngineerRepo.GetById(id);

                List<MedicalDevice> medicalDevices = biomedicalEngineer.MedicalDevices;

                if (medicalDevices.Count == 0)
                    return (null, "No data found");

                List<MedicalDeviceDTO> mdDTOs = medicalDeviceMapper.ToListResponseDto(medicalDevices);

                return (mdDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(BiomedicalEngineerDTO?, string?)> GetBiomedicalEngineerByID(int id)
        {
            try
            {
                BiomedicalEngineer biomedicalEngineer = await _biomedicalEngineerRepo.GetById(id);

                BiomedicalEngineerDTO bioEng = biomedicalEngineerMapper.ToResponseDto(biomedicalEngineer);

                return (bioEng, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<string?> Update(BiomedicalEngineerDTO emp, string modifiedBy)
        {
            try
            {
                BiomedicalEngineer biomedicalEngineer = await _biomedicalEngineerRepo.GetById(emp.UID);

                biomedicalEngineer.Edit(emp.FName, emp.MidName, emp.LName, emp.Ssn,
                    emp.Gender, emp.BirthDate, modifiedBy);
                await _biomedicalEngineerRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> Delete(int id, string modifiedBy)
        {
            try
            {
                BiomedicalEngineer biomedicalEngineer = await _biomedicalEngineerRepo.GetById(id);

                biomedicalEngineer.Delete(modifiedBy);
                await _biomedicalEngineerRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}
