using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.BLL.ModelVM.MedicalDevice;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IBiomedicalEngineerService
    {
        public Task<string?> Create(CreateBiomedicalEngineer emp, string createdBy);

        public Task<(List<BiomedicalEngineerDTO>?, string?)> GetAllBiomedicalEngineers();

        public Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesWorksOn(int id);

        public Task<(BiomedicalEngineerDTO?, string?)> GetBiomedicalEngineerByID(int id);

        public Task<string?> Update(BiomedicalEngineerDTO emp, string modifiedBy);

        public Task<string?> Delete(int id, string modifiedBy);
    }
}
