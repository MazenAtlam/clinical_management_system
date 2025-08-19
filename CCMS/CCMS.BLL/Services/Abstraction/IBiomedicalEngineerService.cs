using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.BLL.ModelVM.MedicalDevice;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IBiomedicalEngineerService
    {
        public Task<(List<BiomedicalEngineerDTO>?, string?)> GetAllBiomedicalEngineers();

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesWorksOn(string id);

        public Task<(BiomedicalEngineerDTO?, string?)> GetBiomedicalEngineerByID(string id);

        public Task<string?> Update(BiomedicalEngineerDTO emp, string modifiedBy);

        public Task<string?> Delete(string id, string modifiedBy);
    }
}
