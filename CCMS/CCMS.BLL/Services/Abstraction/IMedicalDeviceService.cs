/*using CCMS.BLL.ModelVM.Employee;*/
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IMedicalDeviceService
    {
        public string? Create(CreateMedicalDevice md, string creatingUser);

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevices();

        public (MedicalDeviceDTO?, string?) GetMedicalDeviceBySerialNumber(string serialNum);

        // From table BiomedicalEngineer_MedicalDevice
        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllBiomedicalEngineersWorkOn(string serialNum);

        public string? UpdateStatus(string serialNum, MedicalDeviceStatus newStatus, string modifyingUser);

        public string? UpdateAll(MedicalDeviceDTO emp, string modifyingUser);

        public string? Delete(string serialNum, string modifyingUser);
    }
}
