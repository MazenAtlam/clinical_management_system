using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalDevicesRoomsRepo
    {
        public Task Add(MedicalDevice_Room medicalDeviceRoom);
        public Task<MedicalDevice_Room> GetByIds(string serialNumberd, string rNumber);
        public Task Save();
    }
}
