using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class MedicalDeviceRepo : IMedicalDeviceRepo
    {
        //private readonly CcmsDbContext medicalDeviceCcmsDbContext = new();

        public void Add(MedicalDevice md)
        {
            throw new NotImplementedException();
        }

        public List<MedicalDevice> GetAllMedicalDevices()
        {
            throw new NotImplementedException();
        }

        public MedicalDevice GetMedicalDeviceBySerialNumber(string serialNum)
        {
            throw new NotImplementedException();
        }

        public List<BiomedicalEngineer> GetAllBiomedicalEngineersWorksOn(string serialNum)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
