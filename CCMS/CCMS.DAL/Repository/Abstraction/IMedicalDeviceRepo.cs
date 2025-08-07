using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalDeviceRepo
    {
        public Task Add(MedicalDevice md);

        public Task<List<MedicalDevice>> GetAllMedicalDevices();

        public Task<MedicalDevice> GetMedicalDeviceBySerialNumber(string serialNumber);

        public Task Save();
    }
}
