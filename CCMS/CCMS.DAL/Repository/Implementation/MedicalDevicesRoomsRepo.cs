using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class MedicalDevicesRoomsRepo : IMedicalDevicesRoomsRepo
    {
        private readonly CcmsDbContext MedicalDevicesRoomsDbContext;

        public MedicalDevicesRoomsRepo(CcmsDbContext db) => MedicalDevicesRoomsDbContext = db;

        public async Task Add(MedicalDevice_Room medicalDeviceRoom) => MedicalDevicesRoomsDbContext.MedicalDevices_Rooms.Add(medicalDeviceRoom);

        public async Task<MedicalDevice_Room> GetByIds(string serialNumber, string rNumber)
        {
            MedicalDevice_Room? medicalDeviceRoom = MedicalDevicesRoomsDbContext.MedicalDevices_Rooms
                .Where(md_Room => md_Room.RNumber == rNumber && md_Room.SerialNumber == serialNumber && !md_Room.IsDeleted)
                .FirstOrDefault();

            return medicalDeviceRoom == null
                ? throw new ArgumentException($"The medical device with serial number = {serialNumber} has no relation with the room with number = {rNumber} Or one of them does not exist.")
                : medicalDeviceRoom;
        }

        public async Task Save() => MedicalDevicesRoomsDbContext.SaveChanges();
    }
}
