using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalDeviceRepo
    {
        public Task Add(MedicalDevice md);

        public Task<List<MedicalDevice>> GetAllMedicalDevices();

        public Task<MedicalDevice> GetMedicalDeviceBySerialNumber(string serialNum);

        public Task<List<BiomedicalEngineer>> GetAllBiomedicalEngineersWorksOn(string serialNum);

        public Task Save();
    }
}
