using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class MedicalDeviceRepo : IMedicalDeviceRepo
    {
        private readonly CcmsDbContext medicalDeviceDbContext;
        private readonly CcmsDbContext biomedicalEngineer_medicalDeviceDbContext;

        public MedicalDeviceRepo(CcmsDbContext db) => medicalDeviceDbContext = biomedicalEngineer_medicalDeviceDbContext = db;

        public async Task Add(MedicalDevice md) => medicalDeviceDbContext.Add(md);

        public async Task<List<MedicalDevice>> GetAllMedicalDevices()
            => medicalDeviceDbContext.MedicalDevices.Where(device => !device.IsDeleted).ToList();

        public async Task<MedicalDevice> GetMedicalDeviceBySerialNumber(string serialNum)
        {
            MedicalDevice? medicalDevice = medicalDeviceDbContext.MedicalDevices.Where(device => device.SerialNumber == serialNum && !device.IsDeleted).FirstOrDefault();

            return medicalDevice == null
                ? throw new ArgumentException($"There is no medical device with the serial number = {serialNum} .", "serialNum")
                : medicalDevice;
        }

        public async Task<List<BiomedicalEngineer>> GetAllBiomedicalEngineersWorksOn(string serialNum)
            => biomedicalEngineer_medicalDeviceDbContext.BiomedicalEngineers_MedicalDevices
            .Where( join => join.SerialNumber == serialNum && !join.MedicalDevice.IsDeleted)
            .Select(join => join.BiomedicalEngineer)
            .ToList();

        public async Task Save() => medicalDeviceDbContext.SaveChanges();
    }
}
