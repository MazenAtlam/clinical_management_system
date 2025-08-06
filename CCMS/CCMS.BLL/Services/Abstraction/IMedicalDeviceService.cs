using CCMS.BLL.ModelVM.Employee;
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IMedicalDeviceService
    {
        public Task<string?> Create(MedicalDeviceDTO md, string creatingUser);

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevices();

        public Task<(MedicalDeviceDTO?, string?)> GetMedicalDeviceBySerialNumber(string serialNum);

        // From table BiomedicalEngineer_MedicalDevice
        public Task<(List<EmployeeDTO>?, string?)> GetAllBiomedicalEngineersWorkOn(string serialNum);

        public Task<string?> UpdateStatus(string serialNum, MedicalDeviceStatus newStatus, string modifyingUser);

        public Task<string?> UpdateAll(MedicalDeviceDTO md, string modifyingUser);

        public Task<string?> Delete(string serialNum, string modifyingUser);
    }
}
