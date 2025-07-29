/*using CCMS.BLL.ModelVM.Employee;*/
using CCMS.BLL.ModelVM.MedicalDevice;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Repository.Implementation;

namespace CCMS.BLL.Services.Implementation
{
    public class MedicalDeviceService : IMedicalDeviceService
    {
        private readonly IMedicalDeviceRepo medicalDeviceRepo = new MedicalDeviceRepo();

        public string? Create(CreateMedicalDevice md, string creatingUser)
        {
            throw new NotImplementedException();
        }

        public (List<MedicalDeviceDTO>?, string?) GetAllMedicalDevices()
        {
            throw new NotImplementedException();
        }

        public (MedicalDeviceDTO?, string?) GetMedicalDeviceBySerialNumber(string serialNum)
        {
            throw new NotImplementedException();
        }

        // From table BiomedicalEngineer_MedicalDevice
        //public (int, List<BiomedicalEngineerDTO>?, string) GetAllBiomedicalEngineersWorksOn(string serialNum)
        //{
        //    throw new NotImplementedException();
        //}

        public string? UpdateStatus(string serialNum, MedicalDeviceStatus newStatus, string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? UpdateAll(MedicalDeviceDTO emp, string modifyingUser)
        {
            throw new NotImplementedException();
        }

        public string? Delete(string serialNum, string modifyingUser)
        {
            throw new NotImplementedException();
        }
    }
}
