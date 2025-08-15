using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Repository.Implementation;

namespace CCMS.BLL.Services.Implementation
{
    public class BiomedicalEngineerService : IBiomedicalEngineerService
    {
        //private readonly IBiomedicalEngineerRepo biomedicalEngineerRepo = new BiomedicalEngineerRepo();
        private readonly BiomedicalEngineerMapper mapper = new BiomedicalEngineerMapper();

        public async Task<string?> Create(/*EmployeeDTO emp, */string createdBy)
        {
            throw new NotImplementedException();
        }

        public async Task</*(List<EmployeeDTO>?, */string?/*)*/> GetAllBiomedicalEngineers()
        {
            throw new NotImplementedException();
        }

        public async Task<(List<MedicalDeviceDTO>?, string?)> GetAllMedicalDevicesWorksOn(int id)
        {
            throw new NotImplementedException();
        }

        public async Task</*(EmployeeDTO?, */string?/*)*/> GetBiomedicalEngineerByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Update(/*EmployeeDTO emp, */string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Delete(int id, string modifiedBy)
        {
            throw new NotImplementedException();
        }
    }
}
