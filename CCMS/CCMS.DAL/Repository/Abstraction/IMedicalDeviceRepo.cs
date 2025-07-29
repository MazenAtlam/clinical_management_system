using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalDeviceRepo
    {
        public void Add(MedicalDevice md);

        public List<MedicalDevice> GetAllMedicalDevices();

        public MedicalDevice GetMedicalDeviceBySerialNumber(string serialNum);

        public List<BiomedicalEngineer> GetAllBiomedicalEngineersWorksOn(string serialNum);

        public void Save();
    }
}
