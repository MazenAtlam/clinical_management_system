using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Repository.Implementation;

namespace CCMS.BLL.Services.Implementation
{
    public class BiomedicalEngineerService : IBiomedicalEngineerService
    {
        //private readonly IBiomedicalEngineerRepo biomedicalEngineerRepo = new BiomedicalEngineerRepo();

        public string? Create(/*CreateEmployee emp, */string creatingUser)
        {
            throw new NotImplementedException();
        }

        public /*(List<EmployeeDTO>?, */string?/*)*/ GetAllBiomedicalEngineers()
        {
            throw new NotImplementedException();
        }

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevicesWorksOn(int id)
        {
            throw new NotImplementedException();
        }

        public /*(EmployeeDTO?, */string?/*)*/ GetBiomedicalEngineerByID(int id)
        {
            throw new NotImplementedException();
        }

        public string? Update(/*EmployeeDTO emp, */string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? Delete(int id, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
