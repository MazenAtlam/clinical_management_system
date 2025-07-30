using CCMS.BLL.ModelVM.MedicalDevice;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IBiomedicalEngineerService
    {
        public string? Create(/*CreateEmployee emp, */string creatingUser);

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllBiomedicalEngineers();

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevicesWorksOn(int id);

        public /*(EmployeeDTO?, */string?/*)*/ GetBiomedicalEngineerByID(int id);

        public string? Update(/*EmployeeDTO emp, */string modifyingUser);

        public string? Delete(int id, string modifyingUser);
    }
}
