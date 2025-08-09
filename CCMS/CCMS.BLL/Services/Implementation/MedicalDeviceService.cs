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

        public async Task<string?> Create(MedicalDeviceDTO md, string createdBy)
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

        public async Task<(MedicalDeviceDTO?, string?)> GetMedicalDeviceBySerialNumber(string serialNumber)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNumber);

                MedicalDeviceDTO mdDevice = MedicalDeviceMapper.ToResponseDto(medicalDevice);

                return (mdDevice, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<EmployeeDTO>?, string?)> GetAllBiomedicalEngineersWorkOn(string serialNumber)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNumber);

                List<BiomedicalEngineer> biomedicalEngineers = medicalDevice.BiomedicalEngineers;

                if (biomedicalEngineers.Count == 0)
                    return (null, "No data found.");

                List<EmployeeDTO> bioEngs = BiomedicalEngineerMapper.ToListResponseDto(biomedicalEngineers);

                return (bioEngs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<string?> UpdateStatus(string serialNumber, MedicalDeviceStatus newStatus, string modifiedBy)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNumber);

                medicalDevice.UpdateStatus(newStatus, modifiedBy);
                await medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> UpdateAll(MedicalDeviceDTO md, string modifiedBy)
        {
            throw new NotImplementedException();
            //try
            //{
            //    MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(md.SerialNumber);

            //    //medicalDevice.UpdateAll(md.SerialNumber, md.MDName, md.Company, md.ExpirationHours, md.MDStatus, modifiedBy);
            //    await medicalDeviceRepo.Save();

            //    return null;
            //}
            //catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> Delete(string serialNumber, string modifiedBy)
        {
            try
            {
                MedicalDevice medicalDevice = await medicalDeviceRepo.GetMedicalDeviceBySerialNumber(serialNumber);

                medicalDevice.Delete(modifiedBy);
                await medicalDeviceRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; };
        }
    }
}
