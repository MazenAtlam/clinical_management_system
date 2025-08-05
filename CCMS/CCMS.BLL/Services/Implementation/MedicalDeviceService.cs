using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class MedicalDeviceService : IMedicalDeviceService
    {
        private readonly IMedicalDeviceRepo medicalDeviceRepo;

        public MedicalDeviceService(IMedicalDeviceRepo MDRepo)
        {
            medicalDeviceRepo = MDRepo;
        }

        public async Task<string?> Create(MedicalDeviceDTO md, string creatingUser)
        {
            try
            {
                MedicalDevice mdDevice = MedicalDeviceMapper.ToEntity(md);

                await medicalDeviceRepo.Add(mdDevice);
                await medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevices()
        {
            try
            {
                List<MedicalDevice> medicalDevices = await medicalDeviceRepo.GetAllMedicalDevices();

                if (medicalDevices.Count == 0)
                    return (null, "No data found.");

                List<MedicalDeviceDTO> mdDevices = MedicalDeviceMapper.ToListResponseDto(medicalDevices);

                return (mdDevices, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(MedicalDeviceDTO?, string?)> GetMedicalDeviceBySerialNumber(string serialNum)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                MedicalDeviceDTO mdDevice = MedicalDeviceMapper.ToResponseDto(medicalDevice);

                return (mdDevice, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllBiomedicalEngineersWorkOn(string serialNum)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                List<BiomedicalEngineer> biomedicalEngineers = medicalDevice.BiomedicalEngineers;

                if (biomedicalEngineers.Count == 0)
                    return (null, "No data found.");

                List<EmployeeDTO> bioEngs = BiomedicalEngineerMapper.ToListResponseDto(biomedicalEngineers);

                return (bioEngs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<string?> UpdateStatus(string serialNum, MedicalDeviceStatus newStatus, string modifyingUser)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                medicalDevice.UpdateStatus(newStatus, modifyingUser);
                await medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> UpdateAll(MedicalDeviceDTO md, string modifyingUser)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(md.SerialNumber);

                medicalDevice.UpdateAll(md.SerialNumber, md.MDName, md.Company, md.ExpirationHours, md.MDStatus, modifyingUser);
                await medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> Delete(string serialNum, string modifyingUser)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                medicalDevice.Delete(modifyingUser);
                await medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; };
        }
    }
}
