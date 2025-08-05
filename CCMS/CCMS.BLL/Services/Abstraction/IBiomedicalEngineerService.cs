using CCMS.BLL.ModelVM.MedicalDevice;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IBiomedicalEngineerService
    {
        public Task<string?> Create(/*EmployeeDTO emp, */string creatingUser);

        public Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllBiomedicalEngineers();

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesWorksOn(int id);

        public Task</*(EmployeeDTO?, */string?/*)*/> GetBiomedicalEngineerByID(int id);

        public Task<string?> Update(/*EmployeeDTO emp, */string modifyingUser);

        public Task<string?> Delete(int id, string modifyingUser);
    }
}
