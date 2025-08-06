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

        public string? Create(MedicalDeviceDTO md, string creatingUser)
        {
            try
            {
                MedicalDevice mdDevice = MedicalDeviceMapper.ToEntity(md);

                medicalDeviceRepo.Add(mdDevice);
                medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevices()
        {
            try
            {
                List<MedicalDevice> medicalDevices = medicalDeviceRepo.GetAllMedicalDevices();

                if (medicalDevices.Count == 0)
                    return (null, "No data found.");

                List<MedicalDeviceDTO> mdDevices = MedicalDeviceMapper.ToListResponseDto(medicalDevices);

                return (mdDevices, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public (MedicalDeviceDTO?, string?) GetMedicalDeviceBySerialNumber(string serialNum)
        {
            try
            {
                MedicalDevice medicalDevice = medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                MedicalDeviceDTO mdDevice = MedicalDeviceMapper.ToResponseDto(medicalDevice);

                return (mdDevice, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        // From table BiomedicalEngineer_MedicalDevice
        public (List<EmployeeDTO>?, string?) GetAllBiomedicalEngineersWorkOn(string serialNum)
        {
            try
            {
                List<BiomedicalEngineer> biomedicalEngineers = medicalDeviceRepo.GetAllBiomedicalEngineersWorksOn(serialNum);

                if (biomedicalEngineers.Count == 0)
                    return (null, "No data found.");

                List<EmployeeDTO> bioEngs = BiomedicalEngineerMapper.ToListResponseDto(biomedicalEngineers);

                return (bioEngs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public string? UpdateStatus(string serialNum, MedicalDeviceStatus newStatus, string modifyingUser)
        {
            try
            {
                MedicalDevice medicalDevice = medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                medicalDevice.UpdateStatus(newStatus, modifyingUser);
                medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string? UpdateAll(MedicalDeviceDTO md, string modifyingUser)
        {
            try
            {
                MedicalDevice medicalDevice = medicalDeviceRepo.GetMedicalDeviceBySerialNumber(md.SerialNumber);

                medicalDevice.UpdateAll(md.SerialNumber, md.MDName, md.Company, md.ExpirationHours, md.MDStatus, modifyingUser);
                medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string? Delete(string serialNum, string modifyingUser)
        {
            try
            {
                MedicalDevice medicalDevice = medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNum);

                medicalDevice.Delete(modifyingUser);
                medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; };
        }
    }
}
