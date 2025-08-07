using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IMedicalDeviceService
    {
        public Task<string?> Create(MedicalDeviceDTO md, string createdBy);

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevices();

        public Task<(MedicalDeviceDTO?, string?)> GetMedicalDeviceBySerialNumber(string serialNumber);

        // From table BiomedicalEngineer_MedicalDevice
        public Task<(List<EmployeeDTO>?, string?)> GetAllBiomedicalEngineersWorkOn(string serialNumber);

        public Task<string?> UpdateStatus(string serialNumber, MedicalDeviceStatus newStatus, string modifiedBy);

        public Task<string?> UpdateAll(MedicalDeviceDTO md, string modifiedBy);

        public Task<string?> Delete(string serialNumber, string modifiedBy);
    }
}
